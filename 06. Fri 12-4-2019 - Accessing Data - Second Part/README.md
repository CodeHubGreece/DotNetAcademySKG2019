# Accessing Data - Second Part

## Enable migrations and create the database

- Replace connection string with the local values
  ```
  const string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB16;Initial Catalog=Vidly;Integrated Security=True";
  ```

- Open Package Manager Console in Visual studio (View -> Other Windows -> Package Manager Console)

   - Execute command
      ```
        Enable-Migrations
      ```
      that enables database migrations for our project
   - Execute command
     ```
     Add-Migration Initial
     ```
     which adds a migration to our project with name `Initial`. This one contains the logic to create the required tables to the database.
   - Execute command
     ```
     Update-Database
     ```
     which creates the database and then the required tables.

## Create controller and views for Genres

- Right click on `Controllers` folder -> Add -> New Scaffolded Item and select `MVC 5 Controller with views, using Entity Framework` and then hit `Add`

- In the next screen make the following selections
   - Model class -> `Genre`
   - Data Context Class -> `VidlyContext`
   - Verify that Controller name at the bottom is `GenresController`
   - Let the rest to the default values

## Steps when adding a new entity

When there is a need to add a new entity to our system we need to follow certain steps.
- Add a class representing the entity in Models folder
- Add a DbSet property in the class that inherits from `DbContext` e.g. `VidlyContext`
- Create a new controller as described in the steps above for `Genres`
- Add a database migration so Entity Framework can create the commands to update the database. One migration could contain the changes required for multiple entities at the same time.
- Update the database by running the command `Update-Database`

## Install Entity Framework in a new project

When creating a new project in Visual Studio Entity Framework is not included by default, so we have to install it. To do this we need to execute the command
```
Install-Package EntityFramework -Version 6.2.0
```
from the Package Manager Console as above.
