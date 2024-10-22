# SportsScoreboard-SignalR

This project is a real-time sports scoreboard built with ASP.NET Core and SignalR. It allows users to submit and view scores dynamically without refreshing the page.

## Features
- **Real-time Updates:** Uses SignalR to update the live scoreboard across all open sessions, ensuring users get immediate updates without needing to refresh the page.
- **Past Games Section:** A "Past Games" section has been added to display previously submitted scores, organized from oldest to newest.
- **Database Integration:** The scores are now persisted in a SQLite database, allowing the scoreboard to retain game history across sessions.
- **Simple and User-Friendly UI:** Includes a clean and minimalistic form to submit team names and scores, with easy-to-read live updates.

## Future Enhancements
- **Filter by Date:** Add the ability to filter the past games section by specific dates.
- **Game History Export:** Introduce a feature to download the past games data as a CSV file.
- **More Game Statistics:** Expand the scoreboard to track additional game statistics like home runs, fouls, or other relevant metrics.
- **UI Styling:** Enhance the UI with team logos, custom color schemes, and a more dynamic scoreboard layout.

## How to Run Locally
1. Clone the repository:
   ```bash
   git clone https://github.com/seanwryan/SportsScoreboard-SignalR.git
2. Navigate to the project directory:
cd SportsScoreboard-SignalR
3. Run the project:
dotnet run
4. Open your browser and go to http://localhost:5048 (or the specified port).
Acknowledgements
I would like to acknowledge the assistance of OpenAI's ChatGPT in providing guidance and code snippets for developing features such as real-time updates, database integration, and the overall design of the project.

License
This project is licensed under the MIT License - see the LICENSE file for details.
