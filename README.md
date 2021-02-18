# Benefits

How to run:
1) Verify your connection string is accurate in appsettings.json under Web project. I configured EF to point to SQL Server so you will need that DB.
2) Run the code first migration command for DataAccess project using Package Manager Console command "update-database --verbose", or use CLI command "dotnet ef database update".
3) Start IIS Express and it should start up the site. Note: First run will take a bit.
