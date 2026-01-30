SPA - Single Page Application
.NET NET CORE 10 CLI, ANGULAR CLI 21 (typescript) and MSSQL 2025 start-up project

Requirements:
1. Knowledge in C#, @vue/cli 5.0.8 and typescript
2. Node 24.13.0 and NPM 11.16.2
3. Angular CLI 21.1.2
4. Dotnet Core v8.0.204 CLI
5. MSSQL 2025 Server Docker Container
6. Bootstrap 5.3.7 and JQuery
7. FontAwesome @fortawesome/free-solid-svg-icons@7.0.0
8. Visual Studio Code
9. Install Google Authenticator in your Mobile Phone

Features :
1. Authentication and Authorization
   BryCrypt, JWT
2. Time Based One Time Password Authenticator
3. User Profile Picture upload/update
4. Product Listings and Pagination
5. User Account Activation via Email
6. Swagger RESTful API Documentation, https://localhost:5270/swagger/index.html
7. Products Report - PDF
8. Annual Sales Chart

If you want to test, do the following:
1. Setup MSSQL 2025 DOCKER
2. Change Username and Password in appsettings.json, MySql connection settings
3. Run, dotnet ef migrations add InitialIdentitySchema and dotnet ef database 