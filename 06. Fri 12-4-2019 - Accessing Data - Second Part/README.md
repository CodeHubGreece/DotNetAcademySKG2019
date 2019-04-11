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
