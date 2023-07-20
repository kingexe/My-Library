# My-Library
Library Manager


This is a simple bookstore application built with Vue.js for the frontend and ASP.NET for the backend. The backend uses SQL as the database.

## Getting Started

To run this application locally, you'll need to have Node.js, npm (Node Package Manager), and ASP.NET Core SDK installed on your machine.

### Back-End Setup

Create the Library database:

Open SQL Server Management Studio (SSMS) or any other SQL client tool.
Connect to the SQL Server instance.
Right-click on "Databases" and select "New Database".
Provide a name for the database, such as "LibraryDb", and click "OK" to create it.
Update the connection string:

Open the "appsettings.json" file in your ASP.NET Core project.
Update the value of the "DefaultConnection" key in the "ConnectionStrings" section with your SQL Server connection details.
Make sure to replace <ServerName> with the actual name or IP address of your SQL Server instance.

json
"ConnectionStrings": {
  "DefaultConnection": "Server=<ServerName>;Database=LibraryDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}


Open the Package Manager Console in Visual Studio.
Run the following command to apply the migrations and create the necessary tables in the database:

- Update-Database

run the App with F5 Or with the run button 

### Front-End Setup

Navigate to the frontend directory:

bash
Copy code
-cd My-Library-main.zip\My-Library-main\Front-end\My-library

Install the dependencies:
bash

Copy code

-npm install

Make sure the Api Link same as the back .

Add bootstrap for the views

-npm install bootstrap

To run The app in Bash

-npm run dev
