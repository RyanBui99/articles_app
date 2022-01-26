# GigaBlog

## Overview
This is a simple blog application created for a code test from uBIT.
It has a seperate frontend and backend where the frontend uses React and the backed ASP .NET Core. 
The application consists of 3 different users
- logged out visitors that only can read blog posts,
- logged in regular users (user) who can edit and delete posts,
- Logged in admin who has the same authorities as a regular user in addtion can create users.

## Getting started
To run this application you can either download or fork it. 
When downloaded or forked you can open the project in the terminal, by changing the directory (cd) to the application folder.
You can also open it in Visual Studio Code (vsc) or Visual Studio
### Note!
To start the application you need the following installed and/or configured:
- .NET, this will be installed if you have Visual Studio
- .NET Entity Framework Tools CLI, which can be installed with this command: dotnet tool install --global dotnet-ef
- In the ClientApp folder, run npm install
- In the ClientApp folder, configure .env file, as the example in .env.sample
- In the root folder, configure the "ConnectionStrings" to connect to your database in the file appsettings.json.

If you are on a Windows machine you can use: 
- "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=Articles_app;Trusted_Connection=True;MultipleActiveResultSets=true"
in "ConnectionStrings".

If you are on Mac or Linux, you need to run your MSSQL server with a Docker Image.
- The following link will guide you: https://medium.com/@ifeanyilawrence/setup-run-net-core-applications-and-mssql-server-on-macos-f055b570c35b
After that you can "DefaultConnection": "Server=exampleserver;Database=Articles_app;User=exampleuser;Password=examplepass" in "ConnectionStrings"



### Terminal:
If you are in the terminal, 
- Run the command: dotnet ef database update. This is to initialize the database
- Run the command dotnet build, and after that dotnet run.

### Visual Studio:
Press the play button :)
