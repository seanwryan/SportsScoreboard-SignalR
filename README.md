# SportsScoreboard-SignalR

This project is a real-time sports scoreboard built with ASP.NET Core and SignalR. It allows users to submit, view, and manage scores dynamically without refreshing the page.

## Features
- **Real-time updates using SignalR**: Scores update live for all connected users.
- **Submit and Edit Scores**: Users can submit new scores with team names, scores, and a date. Users can also edit or delete past game entries.
- **Filter Past Games**: Users can filter past games by date range or team name.
- **Responsive UI**: The scoreboard is styled and easily viewable on desktop and mobile devices.

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
Authentication: Implement user authentication to allow users to manage only their own score entries.
More Advanced Filters: Filtering options based on additional metrics or date-based visualizations.
Improved Styling: More comprehensive UI improvements and better mobile responsiveness.

Acknowledgements
I would like to acknowledge the assistance of OpenAI's ChatGPT in providing guidance and code snippets for developing features such as real-time updates, database integration, and the overall design of the project.

License
This project is licensed under the MIT License - see the LICENSE file for details.
