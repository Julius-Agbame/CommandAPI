# CommandAPI

A simple ASP.NET Core Web API for managing command-line commands.

## Description

This API allows you to store and retrieve command-line commands with their descriptions and platforms.

## Prerequisites

- .NET 10.0 SDK

## Installation

Clone the repository and navigate to the project directory.

## Running the Application

1. Navigate to `src/CommandAPI`
2. Run `dotnet run`

The API will be available at `https://localhost:5001` or `http://localhost:5000` (check launchSettings.json for exact ports).

## API Endpoints

- `GET /api/command` - Retrieve all commands
- `GET /api/command/{id}` - Retrieve a specific command by ID

### Command Model

```json
{
  "id": 1,
  "howTo": "Description of the command",
  "commandLine": "The actual command",
  "platform": "Windows/Linux/etc."
}
```

## Testing

1. Navigate to `test/CommandAPI.Tests`
2. Run `dotnet test`

## Project Structure

- `src/CommandAPI/` - Main API project
- `test/CommandAPI.Tests/` - Unit tests