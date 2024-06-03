# Chinook Application

## Overview

The Chinook application is a full-stack Razor project built using .NET 8, SQLite 3, and a Code-First approach. The project is structured into separate class projects, each handling distinct functionality to ensure modularity and maintainability.

## Technology Stack

- **.NET 8**
- **SQLite 3**
- **Entity Framework Core 8 (Code-First)**

## Project Structure

The solution is divided into several class projects, each with a specific role:

1. **Chinook.Core**
   - **Description**: Contains the base models that replicate the database structure.
   - **Components**: 
     - Base Models

2. **Chinook.Infrastructure**
   - **Description**: Manages the database and migrations.
   - **Components**: 
     - Database Context
     - Migrations

3. **Chinook.Services**
   - **Description**: Contains the business logic of the application.
   - **Components**:
     - Service Interfaces and Implementations for Artists, Playlists, Tracks, and User Playlists

4. **Chinook**
   - **Description**: The Razor application that includes the Razor pages, components, error handling logics, and dependency injection setup.
   - **Components**:
     - Razor Pages
     - Razor Components
     - Error Handling
     - Dependency Injection Configuration (built in)

## Features

- **Modular Architecture**: Separation of concerns into different class projects for better maintainability.
- **Built-in Dependency Injection**: Utilizes .NET Core's built-in dependency injection.
- **Error Handling**: Centralized error handling using custom middleware and Razor pages.
- **Entity Framework Core Migrations**: Manages database schema changes through migrations.

## Setting Up the Project

### Prerequisites

- .NET 8 SDK
- SQLite 3

### Migration and Database Setup

1. **Point to Chinook.Infrastructure**: Ensure your migration commands target the `Chinook.Infrastructure` class project.
2. **Run Migrations**: Use the following commands to apply migrations and update the database.

 ```sh
 cd Chinook.Infrastructure
 dotnet ef migrations add InitialCreate
 dotnet ef database update
```

### Running the Application
1. Build the Solution: Build the entire solution to restore all dependencies and compile the projects.
```sh
dotnet build
```

2. Run the Application: Start the Razor application.
 ```sh
cd Chinook
dotnet run
```

### Summary
The Chinook application is a well-structured Razor project leveraging .NET 8 and SQLite 3, with a clear separation of concerns through the use of different class projects. This approach ensures modularity and ease of maintenance, while built-in dependency injection and centralized error handling enhance the robustness of the application.

# Chinook Tasks

This application is unfinished. Please complete below tasks. Spend max 2 hours.
We would like to have a short written explanation of the changes you made.

1. Move data retrieval methods to separate class / classes (use dependency injection)
2. Favorite / unfavorite tracks. An automatic playlist should be created named "My favorite tracks"
3. Search for artist name

Optional:
4. The user's playlists should be listed in the left navbar. If a playlist is added (or modified), this should reflect in the left navbar (NavMenu.razor). Preferrably, this list should be refreshed without a full page reload. (suggestion: you can use Event, Reactive.NET, SectionOutlet, or any other method you prefer)
5. Add tracks to a playlist (existing or new one). The dialog is already created but not yet finished.

When creating a user account, you will see this:
"This app does not currently have a real email sender registered, see these docs for how to configure a real email sender. Normally this would be emailed: Click here to confirm your account."
After you click 'Click here to confirm your account' you should be able to login.

Please send us a zip file with the modified solution when you are done. You can also upload it to your own GitHub account and send us the link.
