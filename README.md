# MessageBoardApp
Message Board using websockets and SignalR in .NET Core

## Setting up the database

1. Install localdb for your platform (Mac, Windows)
2. Point the MessagingContext connection string in the messageboardapi project to your local db
3. In the data project, run the following: dotnet ef database update -s ../messageboardapi

## Setting up the web server

1. Setup the database see above.
2. Install all the packages in the base folder using: dotnet restore
3. Start the server by doing the following in the base folder: dotnet build, dotnet run

## Setting up the client application

1. In the messageboard-client folder do the following: npm i
2. To start the server, type: ng s
