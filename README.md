# SportsScoreboard-SignalR

A real-time sports scoreboard web application developed with C# and .NET, using SignalR for live updates. This project allows users to view, submit, edit, and delete scores for various sports games. The app is designed to showcase skills in C#, .NET, Git, and real-time data handling, with plans to integrate a predictive model for game outcomes.

## Features

- **Live Scoreboard**: View real-time updates of games with SignalR.
- **Game Entry Management**: Add new games with detailed information:
  - Home Team, Away Team
  - Scores for both teams
  - Date and Location
  - Game Type (e.g., Regular Season, Playoffs)
  - Sport (currently supports Football, Baseball, Hockey, Basketball)
- **Edit and Delete Entries**: Modify or remove entries in the past games list.
- **Filter Games**: Filter past games by date or team.
  
## Planned Features

- **Predictive Model**: Incorporate a predictive model to forecast scores for future games based on historical data.
- **Advanced Statistics**: Introduce more statistical fields and in-depth analytics for each game.

## Technologies Used

- **C# and .NET Core**: Backend development.
- **SignalR**: Real-time communication for live updates.
- **Bootstrap**: Frontend styling.
- **Entity Framework Core**: Database operations.

## Getting Started

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [SQL Server or SQLite](https://www.sqlite.org/download.html) (or another database compatible with Entity Framework Core)

### Setup

1. **Clone the repository**:
    ```bash
    git clone https://github.com/seanwryan/SportsScoreboard-SignalR.git
    cd SportsScoreboard-SignalR
    ```

2. **Restore dependencies**:
    ```bash
    dotnet restore
    ```

3. **Setup the database**:
   - Update the database with Entity Framework migrations:
     ```bash
     dotnet ef database update
     ```

4. **Run the application**:
    ```bash
    dotnet run
    ```
   The application will be available at `http://localhost:5048'.

### Usage

- **Add a Game**: Use the “Submit New Game” form on the homepage to enter a game’s details.
- **View Past Games**: See the list of past games with scores and details. Edit or delete games directly from this list.
- **Filter Games**: Filter the list of past games by date or team name.
- **Live Score Updates**: Observe real-time updates to scores with SignalR.

### Project Structure

- **Controllers**: Handles HTTP requests, primarily for CRUD operations on game entries.
- **Models**: Defines data structures, including the `Score` model for storing game data.
- **Services**: Contains business logic, including data access and SignalR communication.
- **Views**: Contains Razor views, including pages for game management and real-time updates.

### Contributing

Contributions are welcome! Please fork the repository and create a pull request with any improvements.

---

**Author**: Sean Ryan  
**GitHub**: [https://github.com/seanwryan](https://github.com/seanwryan)

Acknowledgements
I would like to acknowledge the assistance of OpenAI's ChatGPT in providing guidance and code snippets for developing features such as real-time updates, database integration, and design of the project.

License
This project is licensed under the MIT License - see the LICENSE file for details.
