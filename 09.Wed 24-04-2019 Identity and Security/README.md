# Asp.net Identity and Security

[Official documentation](https://docs.microsoft.com/en-us/aspnet/identity/overview/getting-started/introduction-to-aspnet-identity)

## Create a blank new project with identity

In order to create a new MVC application that has out of the box support for identity and security we need to follow the steps below

- From the add new project dialog select `ASP.NET Web Application` item. Be careful to also select .net framework 4.7.2.
 ![new project](media/newProject.jpg)

 - After filing a meaningful name we click on `OK` and in the next screen we select `MVC` as project type
 ![project type](media/projectType.jpg)

 - Before clicking `OK` we need to also choose the Authentication type by clicking `Change Authentication` button. From the pop up dialog we choose `Individual User Accounts`
 ![authentication type](media/authenticationType.jpg)

 - After this we select `OK` in both pop up and the main dialog. At this point Visual Studio is ready to create the project with all required references and nuget packages.

 - One last step is to update the connection string to the database. To do this we need to open `IdentityModel` file, and inside `ApplicationDbContext` class to add a string with the connection string value. After this the class should look like
   ```
    const string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB16;Initial Catalog=Greenfield.Identity;Integrated Security=True";

		public ApplicationDbContext()
			: base(connectionString, throwIfV1Schema: false)
		{
		}

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
   ```

## Add Identity to an existing project