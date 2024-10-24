SportsScoreboard-SignalR
This project is a real-time sports scoreboard built with ASP.NET Core and SignalR. It allows users to submit, view, and manage sports scores dynamically without refreshing the page.

Features
Real-time Updates using SignalR: Scores update live for all connected users as soon as they are submitted or modified.
Submit, Edit, and Delete Scores: Users can submit new game entries with team names, scores, dates, game types, locations, and players of the game. They can also edit or delete past game entries.
Filter Past Games: Users can filter past games by date and team name to quickly find relevant game results.
Responsive UI: The scoreboard is styled for a seamless experience across both desktop and mobile devices.

## How to Run Locally
1. Clone the repository:
   ```bash
   git clone https://github.com/seanwryan/SportsScoreboard-SignalR.git
2. Navigate to the project directory:
cd SportsScoreboard-SignalR
3. Run the project:
dotnet run
4. Open your browser and go to http://localhost:5048 (or the specified port).

Future Enhancements
User Authentication: Implement user authentication to allow users to manage only their own score entries.
Advanced Filtering: Add more filtering options based on additional metrics, such as team rankings, or introduce date-based visualizations.
Enhanced Styling: Improve the user interface with a more polished design and better mobile responsiveness.
Game Statistics: Provide additional statistics for each game, such as top players, audience count, or referee information.

Acknowledgements
I would like to acknowledge the assistance of OpenAI's ChatGPT in providing guidance and code snippets for developing features such as real-time updates, database integration, and design of the project.

License
This project is licensed under the MIT License - see the LICENSE file for details.
