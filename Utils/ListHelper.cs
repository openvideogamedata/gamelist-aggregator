public static class ListHelper {
    public static string DisplayMedalForFirstPositions(int position) {
        return position switch
        {
            1 => "1. 🥇",
            2 => "2. 🥈",
            3 => "3. 🥉",
            _ => $"{position.ToString()}."
        };
    }
}