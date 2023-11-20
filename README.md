# Task Project

Version used .NET 7.0

## Project info:
this is a basic ASP.NET MVC web app that manages the CRUD operations for tasks.
database name: TaskProjectDb
note: users input is validated using ASP.NET validation to prevent runtime errors and exceptions. 

## To run this application:

- you need to have Visual Studio installed.
- open the project from Visual Studio, then open the solution.
- update the database to create the database in your local machine, using this command (in the package manager console)
```
update-database
```
- the latest migration file is already added, but if any issue is faced you can add a new migration, using this command:
```
add-migration MigrationName
```
- install the required packages:
1. Microsoft.EntityFrameworkCore
2. Microsoft.EntityFrameworkCore.Tools	
3. Microsoft.EntityFrameworkCore.SqlServer

