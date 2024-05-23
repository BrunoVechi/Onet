# Multi-User Task Manager Application

This application is a multi-user task manager built with .NET MAUI 8, designed to help users manage tasks efficiently. The app supports task creation, editing, and deletion, and it utilizes a local SQLite database for data storage. The application follows the MVVM architecture with the Microsoft.Toolkit.Mvvm package to ensure a clean separation of concerns and maintainable code.

## Features

- **Multi-User Support**: Multiple users can manage their tasks independently.
- **Task Management**: Users can create, edit, and delete tasks.
- **Task Details**: Each task includes a title, description, and status.
- **Task Status**: Tasks can have one of the following statuses: Waiting, In Progress, or Completed.
- **Date Fields**: Each task records the date of creation, start date, and end date.
- **Local Database**: Uses SQLite for local data storage.

## Technologies Used

- **.NET MAUI 8**: For cross-platform application development.
- **SQLite**: For local database management.
- **MVVM Architecture**: Ensures a clean separation between the UI and business logic.
- **Microsoft.Toolkit.Mvvm**: Provides MVVM components and utilities.

## Installation

To run this application, you need to have .NET MAUI 8 installed. Follow these steps to set up and run the application:

1. **Clone the repository**:

   ```sh
   git clone https://github.com/BrunoVechi/Onet.git
   cd Onet
   ```

2. **Restore NuGet packages**:

   ```sh
   dotnet restore
   ```

3. **Run the application**:
   ```sh
   dotnet build
   dotnet run
   ```
