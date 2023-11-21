# Note Management Application

## Overview

This ASP.NET Core web application is designed for efficient note creation and management, utilizing a microservices architecture. The application incorporates ASP.NET MVC for creating views and controllers, ASP.NET Web API for implementing CRUD operations on notes, and a Class Library for shared model classes.

## Features

- **Microservices Architecture:** The application is built on a microservices architecture, allowing for modular and scalable development.

- **ASP.NET Web API Service:** The microservices architecture includes an ASP.NET Web API service dedicated to handling CRUD operations on notes. This provides a robust and efficient way to manage note-related functionalities.

- **ASP.NET MVC:** The MVC pattern is employed for creating views and controllers, ensuring a separation of concerns and a clean and maintainable codebase.

- **Entity Framework with Local SQL Server Database:** The application uses Entity Framework for data access, with a local SQL Server database. This ensures efficient and reliable data storage and retrieval.

- **Dependency Injection:** Dependency Injection is implemented throughout the application, promoting a loosely coupled and testable design. This facilitates easier maintenance and future enhancements.

- **Data Seeding:** Entity Framework is utilized for database seeding, ensuring a consistent and initial set of data for the application.

- **Shared Library:** Providing an efficient storage for shared models and services between each microservice.

- **AutoMapper:** AutoMapper is employed for efficient mapping between the Notes and NotesDTO classes. It is employed to facilitate the mapping between the real model (entity) and its DTO (Data Transfer Object). 

## Getting Started

1. Clone the repository.
2. Set up the local SQL Server database using Entity Framework migrations.
3. Run the application.

## Dependencies

- ASP.NET Core
- Entity Framework
- AutoMapper
- Newtonsoft.Json

## Usage

1. Navigate to the ASP.NET MVC views for note management.
2. Use the ASP.NET Web API endpoints for CRUD operations on notes.
3. Leverage Dependency Injection for scalable and maintainable design.

