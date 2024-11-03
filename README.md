# PersonManagement - Simple CRUD Using ADO.NET

## Description

This project implements a simple Create, Read, Update, Delete (CRUD) application for managing person records using ADO.NET. It showcases fundamental operations like adding, modifying, displaying, and deleting records from a database, providing a practical example of database interaction in .NET applications.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (version 8.0 or later)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/) (ensure you have the C# Dev Kit extension installed for Visual Studio Code)
- **SQL Server** (ensure you have a SQL Server instance running)

### Connection String

Make sure you have the following connection string set up in your application:

Server=.\SQLEXPRESS;Database=MyDatabase;Integrated Security=True;

## Getting Started

### 1. Clone the Repository

Clone the repository to your local machine with the following command:

```bash
git clone https://github.com/SamirJsx/PersonManagement---Simple-CRUD-Using-ADO.NET.git
cd PersonManagement
```

### 2. Restore Dependencies

To restore the necessary dependencies for your project, run:

```bash
dotnet restore
```

This command reads the project file (`.csproj`) and downloads all required NuGet packages, ensuring that all dependencies are available for your application to run properly.

### 3. Build the Project

After restoring dependencies, build your project to compile the code:

```bash
dotnet build
```

This command compiles the project and generates output in the `bin` directory. If the build is successful, you will see messages indicating that the build completed without errors. If there are any issues, the terminal will display error messages to assist you in troubleshooting.

### 4. Run the Application

Once the project is built, you can run the application with the following command:

```bash
dotnet run
```

This command starts the application and runs it in your terminal. If your application is a console app, you will see output in the terminal. For web applications, it may provide a URL where you can access the app in your browser.

### 5. Usage

After running the application, you can perform the following operations:

- **Add a Person**: Follow the prompts to enter person details.
- **Display Persons**: View all the records currently in the database.
- **Modify a Person**: Select a person to update their details.
- **Delete a Person**: Remove a record from the database.

## License

You are free to use, modify, and distribute this software.
