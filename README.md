# Truck Management System

This project is a Truck Management System built using ASP.NET Core with a Blazor WebAssembly (WASM) front end, demonstrating the application of Clean Architecture, the Repository Pattern, and Unit of Work. The backend leverages Entity Framework Core with MS SQL Express as the database. The solution also incorporates advanced state management using the State Pattern and ensures data integrity through transaction management.
# Table of Contents

- [Overview](#overview)
- [Technologies Used](#technologies-used)
- [Architecture](#architecture)
- [Features](#features)
- [Setup and Installation](#setup-and-installation)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [API Endpoints](#api-endpoints)
- [Entity Relationships](#entity-relationships)
- [Future Improvements](#future-improvements)
- [Acknowledgments](#acknowledgments)

# Overview

The Truck Management System enables users to:

* Register new trucks by providing license plate, raw material type, and weight.
* Modify truck details, including the weight during different weighing stages.
* Track the state of trucks using a state pattern, ensuring proper state transitions based on predefined rules.
* View a list of trucks and their statuses.
* Log virtually all operations (excluding read operations) with timestamps to maintain an audit trail.

# Technologies Used

* .NET 8.0: Backend framework for building RESTful APIs.
* Blazor WebAssembly (WASM): For creating a modern, responsive UI.
* Entity Framework Core: Object-relational mapper (ORM) for database operations.
* MS SQL Express: Relational database to persist data.
* Clean Architecture: Ensures a separation of concerns between the different layers.
* Repository Pattern: Facilitates testability and abstraction over database operations.
* Unit of Work: Manages transaction scope and ensures data integrity.
* State Pattern: Manages truck states systematically within the application.

# Architecture

The application is designed following the principles of Clean Architecture to keep a clear separation of concerns:

1. Domain Layer: Contains business entities, and interfaces.
2. Application Layer: Implements business logic, use cases, and service contracts. Utilizes the state pattern to handle truck state changes.
3. Infrastructure Layer: Contains the database context (AppDbContext), repository implementations, and EF Core configurations.
4. Web API Layer: Provides RESTful endpoints for client interactions and handles request routing.
5. Blazor Client: A separate project that provides a user interface for interacting with the truck management system.
6. Shared Library: A library project to be referenced by other layers to access common objects like enums and DTOs.

# Features

* Truck Management: Create, read, update trucks.
* State Management: Tracks truck states using the State Pattern to handle state transitions.
* Operation Logging: Logs all modifications with timestamps.
* Transaction Management: Ensures database operations are executed within a transaction using Unit of Work.
* Enum Handling: Enum properties like TruckState and RawMaterialType are stored as integers in the database.

# Setup and Installation
## Prerequisites

* .NET 8.0 SDK
* MS SQL Express
* Postman or any other API testing tool (for testing APIs)

## Installation Steps

1. Clone the repository:

    ```bash
    git clone https://github.com/TheZeta/truck-tracking.git
    cd truck-tracking
    ```
2. Set up the Database:

* Update the connection string in appsettings.json (found in the WebAPI project):

    ```bash
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=truck_tracking;Trusted_Connection=True;TrustServerCertificate=True;"
    }
    ```
* Make sure to create a database named *truck_tracking* in your local database server.
* Run the Application:

    * Start the Web API:
    ```bash
    cd WebAPI
    dotnet run
    ```
    * Start the Blazor WebAssembly client:
    ```bash
    cd BlazorWasmClient
    dotnet run
    ```

    * Test the APIs: Use Postman or another tool to interact with the Web API. Example endpoints are listed below.

# Usage

* Visit the Blazor WebAssembly client URL (usually https://localhost:5067) in your browser.
* Use the registration form to add a new truck or update existing trucks.
* Access various pages to view the list of trucks and their states.

# API Endpoints

* POST /api/trucks - Registers a new truck.
* GET /api/trucks/visible - Retrieves a list of all active trucks.
* GET /api/trucks/editable - Retrieves a list of all active trucks pending for an edit of weight.
* GET /api/trucks/{plate} - Retrieves details of a specific truck.
* PUT /api/trucks/{plate} - Updates a truck's details.
* GET /api/trucks/{plate}/state - Changes the state of a truck.

# Entity Relationships

* Truck: Main entity representing a truck, which has properties like Plate, RawMaterialType, Weight, and State.

* OperationLog: Tracks all non-read operations, linked with the truck entity via AffectedEntityId.

# Future Improvements

* Authentication and Authorization: Integrate with Keycloak for user authentication.
* User-specific roles
* Global Exception Handler Middleware
* Testing: Implement unit and integration tests.
* Logging: Enhance logging using Serilog.


# Acknowledgments

* Inspired by the Clean Architecture pattern.
* Uses Blazored Toast for in-app notifications in the Blazor client.