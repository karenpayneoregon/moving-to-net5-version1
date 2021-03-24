# About

VS2019 solution for teaching working with SQL-Server databases. Rather than place all code in the front-end project or split code between front-end/back-end, code has been broken out to smaller class projects which allows code to be used in other projects.

|Project|Purpose   |
| :---         |  :---  |
|ConfigurationHelper|Provides code to read `appsettings.json` for connection strings   |
|DataGridViewHelpers|Language extensions for DataGridView control   |
|DataTableHelpers|Language extensions for DataTable class   |
|SqlOperations|Provides code to interact with SQL-Server using SqlClient data provider   |
|SqlOperationsEntityFrameworkCore|Provides code to interact with SQL-Server using Entity Framework Core |
|StopWatchLibrary| Contains class to record elapsed time using a StopWatch component |
|WinFormHelpers| Classes for working with Window forms projects (non-visual) |
|BasicRead| Utilizes <kbd>SqlOperations</kbd>c to read data into a DataGridView |
|BasicReadEntityFrameworkCore| Utilizes <kbd>SqlOperationsEntityFrameworkCore</kbd> to read data into a DataGridView |


<br/>

:purple_circle: Entity Framework Core

:yellow_circle: SQL client data provider

![vers](assets/Versions.png) 
![ef](assets/efcore.png)
![sql](assets/sql-server.png)


# Database 

:heavy_check_mark: Modified [NorthWind database](https://gist.github.com/karenpayneoregon/40a6e1158ff29819286a39b7f1ed1ae8)

:heavy_check_mark: Connections are obtained from appsetting.json