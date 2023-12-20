# Shelf Layout Manager

Shelf layout management system for stores, developed in .NET 6.0 and Web API, focusing on CRUD operations and efficient frontend-backend integration. Created by Ramon Valerio da Silva.

## Requirements

1. Install the last version of [Docker Desktop](https://www.docker.com/products/docker-desktop).
2. Install a tool to open SQL Server database like SQL Management Studio or Azure Studio.
3. Install [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) from the official Microsoft website.
4. Install [Postman](https://www.postman.com/downloads/) or something similar to test the application when the environment is ready.

## Installation and Setup

### 1. Build and Start the Docker Containers
   In the solution directory, execute:
   ```bash
   docker compose build
   docker compose up
   ```

### 2. Configure SQL Server Connection
```bash
Connection type: Microsoft SQL Server
Server: localhost,1433
Authentication type: SQL Login
User name: sa
Password: Test@123
Database: shelf_db
Encrypt: Mandatory (True)
Trust server certificate: True
```

## How to Run using Postman
### 1. Open Swagger to check the endpoints
Copy the localhost URL from the Docker container to run in the browser:
```bash
http://localhost:3500/swagger
```

### 2. Register an User
In the Auth section, open POST/Register and input in the Request body:
```bash
{
  "userName": "YourUserName",
  "password": "YourPassword"
}
```

### 3. Login
In the Auth section, open POST/Login and input:
```bash
{
  "userName": "YourUserName",
  "password": "YourPassword"
}
```
>Note: If your username and password were found in the database, you would receive a Token.

#### 4. Use Token
Copy this token to use on a tool to create an HttpPost Request using the token on 'Postman' or something similar.

#### 5. Create a Post Request to Create Cabinet
```bash
POST:
http://localhost:3500/cabinet
```
```bash
Authorization:
Type: Bearer Token
Token: "past your token here"
```
```bash
Headers:
Key: Authorization / Value: "past your token here"
Key: Content-Type / Value: application/json
```
>Note: Just an example template to test it!
Currently, initial available 3 cabinets Number(1, 2, 3).

### License
This project is licensed under the MIT License - see the [LICENSE](LICENSE.md) file for details.

### Contact
Ramon Valerio da Silva - ramonvalerios@gmail.com
