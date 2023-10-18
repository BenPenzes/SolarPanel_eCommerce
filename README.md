# SolarPanel_eCommerce (C#)
- A team project I participated in at University of Pannonia.
- This is an eCommerce application that manages a storage of solar panel parts. Solar panel specialists can create and manage the lifecycle of their projects, they also order parts from the storage. Storage Managers can supply parts to the storage and add parts to the database. Storage workers can view the layout of the storage, collect parts and fullfill orders.
- Credit to the team who worked on this project: **sadani0725**, **KovKri**, **BenPenzes**, **RoncsAlex** 
- The applictation is based on a project assignment where the task was to create a client-server application using a REST API service and some kind of object orineted progamming language!
- The frontend is made using Windows Forms, the backend is an ASP.NET Core Web API project, and it uses a MSSQL database!
- The requirements of the system are laid out in a pdf document (`requirements/hu/requirements_hu.pdf`), the document itself is in hungarian. Each of the 3 main roles have a set of functions to be implemented, each marked with a letter and a number: 
    - A# = Specialist
    - B# = Storage Manager
    - C# = Storage Worker.
- There are references for the different requirements throughout the C# and TSQL codes!

## How to build and run the project
- First, a connection to an SQL server instance is needed where the database can be created. [Here is a guide to set up SQL Server locally](https://learn.microsoft.com/en-us/sql/database-engine/install-windows/install-sql-server).
- To create the database the whole of `database_init.sql` has to be run. This file can be found in the main project folder. **NOTE:** First the database has to be created and used with the `USE` stament! This script sets up the tables of the database!
- The backend logic is entirely handled with stored procedures. Each API endpoint uses repository classes that call these stored procedures. To set these up, the file `stored_procedures.sql` can be used! First, to create the main procedures select the code from line 66 - 880 (from the sp's of `SetupStorage` and `FullfillOrder`, both included) and press F5 (or right click and "Execute"). Then, create the stored procedure called `HardResetAndSetupDatabase` starting around line 15. To do the reset, run `EXEC HardResetAndSetupDatabase`! **NOTE:** This deletes all tables and resets the content in each of them including the users. Most Importantly:
    - It clears the content from the tables, including reseting the inventory.
    - Sets up the storage structure.
    - Inserts a few solar panel parts to the database.
    - Creates the admin profile.
- In the application, to add more users to the database, we have to login as admin (email: *admin@nomail.com*, pw: *admin*). Any number of users can be added of the 3 main roles, but there is only 1 admin in the system.
- The stored procedures can be tested locally as well. After each of the stored procedures there are some tests for them. These are commented out by default.
- After the database is setup, the application can be run! In Visual Studio, the *Multiple startup projects* option have to be selected in the properties window of the solution. This way both the Windows From and ASP.NET Core projects start up.
- To connect to the database the `Data Source` has to be named in the "DefaultConnection" field of the `SolarPanelBackend/appsettings.json` file. By default this field is just `Data Source = str; Initial Cat..`. Replace `str` with the proper value!
- After running the project, login as *admin*, then create at least 1 of each user role (*Specialist*, *Storage Manager* and *Storage Worker*). Login as a *Specialist* to create projects and send orders, then handle the orders as *Storage Manager* and *Storage Worker*. By default the storage is empty, so parts need to be supplied as *Storage Manager* by clicking on the *Supply Parts* button.

### Other Notes:
- This project is far from optimized, and lacks some basic error handling features, among other things.
- There are some unused stored procedures. These don't have to be created for the app to run!
- If we want to start the Swagger UI through the browser, set the value of `launchBrowser` to `true` in `SolarPanelBackend/Properties/launchSettings.json`!
