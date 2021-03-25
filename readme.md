# About

VS2019 solution for teaching working with SQL-Server databases. Rather than place all code in the front-end project or split code between front-end/back-end, code has been broken out to smaller class projects which allows code to be used in other projects.

:stop_sign: **Important**

- Before working with this code, create and populate the database via [this script](https://gist.github.com/karenpayneoregon/40a6e1158ff29819286a39b7f1ed1ae8) using SSMS (SQL-Server Managment Studio)
- Ensure .NET5 is installed, if not install from [here](https://dotnet.microsoft.com/download).
- From Solution Explorer, right click the top node, right click, select rebuild
  - If the build fails, open the Visual Studio `Output window` from Visual Studio menu <kbd>View</kbd>, <kbd>Output window</kbd> see what the error is. Most of the time it will be apprarent e.g. missing an NuGet package (if some run NuGet Restore packages by right clicking on the top node of solution explorer `Restore NuGet packages` followed by building the solution again.)
- Run BasicReadEntityFrameworkCore project.

|Project|Purpose   |
| :---         |  :---  |
|ConfigurationHelper|Provides code to read `appsettings.json` for connection strings   |
|BasicRead :yellow_circle:| Utilizes <kbd>SqlOperations</kbd> to read data into a DataGridView |
|BasicReadEntityFrameworkCore :purple_circle:| Utilizes <kbd>SqlOperationsEntityFrameworkCore</kbd> to read data into a DataGridView |
|SqlOperations :yellow_circle:|Provides code to interact with SQL-Server using SqlClient data provider   |
|SqlOperationsEntityFrameworkCore :purple_circle:|Provides code to interact with SQL-Server using Entity Framework Core |
|EntityCoreExtensions :purple_circle:| Various language extensions for a [DbContext](https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.dbcontext?view=entity-framework-6.2.0) |
|DataGridViewHelpers|Language extensions for DataGridView control   |
|DataTableHelpers|Language extensions for DataTable class   |
|StopWatchLibrary| Contains class to record elapsed time using a StopWatch component |
|WinFormHelpers| Classes for working with Window forms projects (non-visual) |




<br/>

:purple_circle: Entity Framework Core

:yellow_circle: SQL client data provider

![vers](assets/Versions.png) 
![ef](assets/efcore.png)
![sql](assets/sql-server.png)


# Database 

:heavy_check_mark: Modified [NorthWind database](https://gist.github.com/karenpayneoregon/40a6e1158ff29819286a39b7f1ed1ae8)

:heavy_check_mark: Connections are obtained from appsetting.json

# See also

👉 [ef-core-find-csharp](https://github.com/karenpayneoregon/ef-core-find-csharp) repository using Visual Studio 2017