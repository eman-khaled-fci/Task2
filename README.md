# Task2BackEnd

A backend project developed in ASP.NET, featuring authentication, CSV file handling, and user management.

## Table of Contents
- [Demo](#demo)
- [Overview](#overview)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Authentication and Authorization](#authentication-and-authorization)
  - [Authentication Process](#authentication-process)
  - [Authorization Process](#authorization-process)
- [CSV Handling](#csv-handling)
- [User Management](#user-management)
- [Endpoints](#endpoints)
- [Project Structure](#project-structure)
- [Dependencies](#dependencies)

## Demo


https://github.com/eman-khaled-fci/Task2/assets/90774185/8aa5c48a-5031-4b14-b927-be3065ce7889


## Overview
This project provides a robust backend solution with authentication, CSV file handling, and user management. It utilizes ASP.NET and includes features like custom authorization attributes, middleware, and Swagger documentation.

## Getting Started

### Prerequisites
- [.NET 8.0](https://dotnet.microsoft.com/download) or later

### Installation
1. Clone the repository.
   ```bash
   git clone https://github.com/eman-khaled-fci/Task2.git
2. Navigate to the project directory:
    ```bash
    cd Task2
3. Build and run the project.
# Authentication and Authorization
## Authentication Process
The project implements basic authentication using a custom middleware, [BasicAuthMiddleware](WebApi/Authorization/BasicAuthMiddleware.cs). The process involves the following steps:

1. **User Credentials**: The user provides credentials (username and password) using the "Authorization" header with the "Basic" scheme.

2. **Middleware Processing**: The middleware parses and extracts the credentials from the header.

3. **User Authentication**: The extracted credentials are used to create an [AuthenticateLoginModel](WebApi/Models/AuthenticateLoginModel.cs). The [UserService](WebApi/Services/UserService.cs) then authenticates the user by matching the credentials against a hardcoded list of users.

4. **User Information in Context**: If authentication is successful, the user information is attached to the HttpContext for further authorization.

## Authorization Process
Authorization is handled through custom authorization attributes, specifically [AllowAnonymousAttribute](WebApi/Authorization/AllowAnonymousAttribute.cs) and [AuthorizeAttribute](WebApi/Authorization/AuthorizeAttribute.cs). The process includes:

1. **Attribute Checks**: The attributes are applied to controllers and methods to control access. The `[AllowAnonymous]` attribute allows unrestricted access, while the `[Authorize]` attribute requires authentication.

2. **Authorization Filter**: The [AuthorizeAttribute](WebApi/Authorization/AuthorizeAttribute.cs) implements the `IAuthorizationFilter` interface and checks for the presence of the `[AllowAnonymous]` attribute. If found, authorization is skipped.

3. **User Presence Check**: If `[AllowAnonymous]` is not present, the middleware checks if a user is present in the HttpContext. If not, a 401 Unauthorized response is returned.

4. **WWW-Authenticate Header**: In case of unauthorized access, a 401 response is returned with a "WWW-Authenticate" header, triggering a login popup in browsers.
# CSV Handling

The `CsvReaderController` manages CSV file uploads and processing using the [CsvHelper](https://joshclose.github.io/CsvHelper/) library. It supports both standard CSV files and a specific CSV format, providing JSON results.

## User Management

User authentication and registration are handled through the `UsersController` and `UserService`. It includes endpoints for login, registration, and retrieving user information.

## Endpoints

- **POST /api/users/authenticateLogin**: Authenticate user login.
- **POST /api/users/authenticateRegister**: Register a new user.
- **GET /api/users**: Retrieve all users.
- **POST /api/csv/upload**: Upload and process a CSV file.

## Project Structure

- **WebApi/Authorization**: Contains custom authorization attributes and middleware.
- **WebApi/Controllers**: Controllers handling various endpoints.
- **WebApi/Entities**: Entity classes representing the data model.
- **WebApi/Models**: Models for authentication and CSV processing.
- **WebApi/Services**: Service layer handling user authentication and management.

## Dependencies

- **CsvHelper**: Library for reading and writing CSV files.
- **Microsoft.AspNetCore.OpenApi**: Swagger for API documentation.
- **Newtonsoft.Json**: JSON framework for .NET.
- **Swashbuckle.AspNetCore**: Swagger tools for documenting APIs.
