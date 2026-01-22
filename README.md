# Open Video Game Data

Welcome to the **GameList Aggregator** project! This open-source initiative aggregates data about video games from various trusted sources, making it freely accessible and user-driven. The project is powered by ASP.NET Blazor, providing a dynamic, interactive user experience.

---

## 🌟 Overview

- **Goal**: Collect curated lists (from journalists and critics) in a single platform.
- **Contribution**: Anyone can add their personal lists or submit lists from reputable sources.
- **Ranking**: The site generates a final ranked list for each category based on aggregated community submissions.

---

## 🚀 Tech Stack

- **Frontend**: ASP.NET Blazor
- **Backend**: .NET Core
- **Database**: PostgreSQL
- **Authentication**: Google OAuth
- **External API**: [IGDB](https://www.igdb.com/)
- **Hosting**: [Render](https://render.com/)

---

## 🏗️ Installation

1. **Clone the repo**:
   ```bash
   git clone https://github.com/YOUR_USERNAME/OpenVideoGameData.git
   cd OpenVideoGameData

2. Install .NET 8 SDK

3. Configure `Properties\launchSettings.json` with:
    1. ConnectionStrings PostgreSQL: Provide your PostgreSQL database details here.
        - Host: The database host (e.g., localhost or an IP address).
        - Database: The name of your PostgreSQL database (e.g., OpenVideoGameDataDB).
        - Username: Your PostgreSQL username.
        - Password: Your PostgreSQL password.

    2. IGDB
        - ClientId: Your IGDB Client ID, obtained after registering an application at [IGDB](https://www.igdb.com/).
        - ClientSecret: The client secret associated with your IGDB account. This is used to authenticate calls to the IGDB API.

    3. GoogleAuth
        - ClientId: Your Google OAuth client ID, usually from the Google Cloud Console.
        - ClientSecret: The client secret for your Google OAuth application.
        - These credentials enable Google sign-in for user authentication on Open Video Game Data.

    *Important*: Keep your credentials private and never commit them to a public repository. Whenever possible, use environment variables or another secure method to store sensitive information.
    
3. Build and run:
    ```bash
    dotnet build
    dotnet run
    ```
The application will be available at https://localhost:5124.

## 🛠️ Database Migrations
If you plan to modify database schema, you may install the .NET EF tool globally:
    
```bash
dotnet tool install --global dotnet-ef
```
Then create and apply migrations:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## 📝 How It Works
1. Login via Google: All accounts use Google OAuth for simplicity.
2. Find a Category: Example: “Best PlayStation 5 Games.”
3. Add a List:
    Click on “Critic Lists.”
    Enter the URL of the list you want to add.
    If the list is new, continue to add games (max 15 per list).
4. Vote & Approval: Submissions are visible to users for upvotes/downvotes; admins review them before final acceptance.

## 🔐 Google Login via API (step by step)
These endpoints allow a front-end (or a human) to complete Google login using the API routes.

1. Open the login URL in your browser:
   - `https://www.openvideogamedata.com/api/auth/login?returnUrl=/`
2. You will be sent to Google. Log in and approve access.
3. Google redirects back to `/api/auth/callback` automatically.
4. After the callback, you are redirected to the `returnUrl` you sent in step 1.
5. Confirm the session is active:
   - `https://www.openvideogamedata.com/api/auth/session`
6. To log out:
   - `https://www.openvideogamedata.com/api/auth/logout?returnUrl=/`

Notes:
- `returnUrl` must be a path inside the site (examples: `/`, `/list/best-games-of-all-time`, `/users/dan`).
- If you do not pass `returnUrl`, the app redirects to the home page.

## 📋 Rules for Submitting Critic Lists
- Must represent a journalist’s/critic’s opinion (not personal).
- Must be enumerated and ranked.
- Must not be based on another aggregate list (e.g., “based on Metacritic”).
- Maximum of 15 games per list. If the source has fewer than 15, include the entire list.

## 🎨 Resources & Icons
- We use icons from various packs, including OpenIconic Cheat Sheet to enhance the UI.

## 🤝 Contributing
1. Fork this repository.
2. Create a new branch for your feature or fix.
3. Commit and push your changes.
4. Open a Pull Request and describe your changes.
5. Feel free to open issues for bugs or feature requests.

## 🔒 License

This project is licensed under the MIT License — enjoy and feel free to contribute!

## ❤️ Thanks
- Together, [André](https://github.com/andredarcie) and [Diego](https://github.com/diguifi) are the driving forces behind OpenVideoGameData, combining technical expertise, creativity, and a shared commitment to open-source.
- IGDB for providing the game database API.
- Our community for continued support and contribution.
- Everyone who helps to keep the project running!
