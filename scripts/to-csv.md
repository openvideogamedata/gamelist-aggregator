@code {
    private void RunCsvCreator()
    {
        Console.WriteLine("Iniciando criação do CSV...");

        var gameLists = dbContext.GameLists
            .Where(gameLists => gameLists.Source != null)
            .Include(gameLists => gameLists.Source)
            .Include(gameList => gameList.FinalGameList)
            .Include(gameList => gameList.Items)
                .ThenInclude(item => item.Game)
            .ToList();

        Console.WriteLine($"Total de registros carregados: {gameLists.Count}");

        var rootFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "CSVExports");

        if (!Directory.Exists(rootFolderPath))
        {
            Directory.CreateDirectory(rootFolderPath);
            Console.WriteLine($"Pasta criada: {rootFolderPath}");
        }
        else
        {
            Console.WriteLine($"Pasta já existia: {rootFolderPath}");
        }

        foreach (var gameList in gameLists)
        {
            if (gameList.FinalGameList is null)
                continue;

            var folderName = SanitizeFileName($"{gameList.FinalGameList.GetFullName()}");
            folderName = folderName.Replace(" ", "_").ToLower();
            var listFolderPath = Path.Combine(rootFolderPath, folderName);

            if (!Directory.Exists(listFolderPath))
                Directory.CreateDirectory(listFolderPath);

            // Criação do arquivo About.csv com os dados da lista
            var aboutFilePath = Path.Combine(listFolderPath, "about.csv");
            using (var aboutWriter = new StreamWriter(aboutFilePath))
            {
                // Cabeçalho
                aboutWriter.WriteLine("Title,Year,Tags,SourceURL");

                // Conteúdo
                var title = EscapeForCsv(gameList.FinalGameList.GetFullName());
                var year = gameList.FinalGameList.Year;
                var tags = EscapeForCsv(gameList.FinalGameList.Tags);
                var sourceUrl = EscapeForCsv(gameList.SourceListUrl);

                aboutWriter.WriteLine($"{title},{year},{tags},{sourceUrl}");
            }

            var date = (gameList.DateLastUpdated ?? gameList.DateAdded).ToString("yyyy-MM-dd_HH-mm-ss");
            var listCreator = $"{SanitizeFileName(gameList.Source.Name.ToLower())} - {date}";
            var fileName = $"{listCreator}.csv";
            var filePath = Path.Combine(listFolderPath, fileName);

            Console.WriteLine($"Tentando salvar em: {filePath}");

            var games = gameList.Items.OrderBy(item => item.Position).ToList();

            using var writer = new StreamWriter(filePath);
            writer.WriteLine("Position,Title,ReleaseDate,ExternalId,Score,GameId,CoverImageId");

            foreach (var game in games)
            {
                var gameRow = $"{game.Position},{game.GameTitle},{game.Game.FirstReleaseDate.ToString("yyyy-MM-dd")},{game.Game.ExternalId},{game.Score},{game.GameId},{game.Game.ExternalCoverImageId}";
                writer.WriteLine(gameRow);
            }

            Console.WriteLine($"Arquivo salvo: {filePath}");
        }

        Console.WriteLine("Todos os arquivos CSV foram gerados com sucesso.");
    }

    private string SanitizeFileName(string name)
    {
        foreach (char c in Path.GetInvalidFileNameChars())
            name = name.Replace(c, '_');
        return name.Trim();
    }

    string EscapeForCsv(string? input)
    {
        if (string.IsNullOrEmpty(input)) return "";

        if (input.Contains(",") || input.Contains("\"") || input.Contains("\n"))
        {
            input = input.Replace("\"", "\"\"");
            return $"\"{input}\"";
        }

        return input;
    }
}