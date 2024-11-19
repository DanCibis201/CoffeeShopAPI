# CoffeeShop Ecommerce Backend API

This repository contains the Backend API for the CoffeeShop Ecommerce application. The application uses the CQRS (Command Query Responsibility Segregation) architecture pattern along with the MediatR library to handle requests. This setup ensures a clean separation of concerns and improves the maintainability of the codebase.

## Table of Contents

- [Technologies Used](#technologies-used)
- [Architecture](#architecture)
- [Getting Started](#getting-started)
- [Endpoints](#endpoints)
- [License](#license)

## Technologies Used

- **.NET 8** - Web framework for building modern web applications.
- **Entity Framework Core** - Object-relational mapper (ORM) for database interactions.
- **MediatR** - Library to implement the Mediator pattern, used for handling commands and queries.
- **CQRS** - Architectural pattern for separating read and write operations.
- **SQL Server** - Database engine.

## Architecture

The application follows the CQRS architecture pattern, which separates the read and write operations. It uses the MediatR library to handle the commands (for write operations) and queries (for read operations). This separation improves the scalability and maintainability of the application.

### Key Components

- **Commands**: Handle write operations such as Create, Update, and Delete.
- **Queries**: Handle read operations.
- **Handlers**: Process the commands and queries.
- **Entities**: Represent the data models.
- **Repositories**: Handle data access logic.

## Getting Started

### Prerequisites

- .NET SDK
- SQL Server

### Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/DanCibis201/CoffeeShopAPI.git
    ```
2. Navigate to the project directory:
    ```bash
    cd coffeeshop
    ```
3. Restore dependencies:
    ```bash
    dotnet restore
    ```
4. Update the database connection string in `appsettings.json`.

5. Apply migrations:
    ```bash
    dotnet ef database update
    ```

6. Run the application:
    ```bash
    dotnet run
    ```

## Endpoints

### Coffee Endpoints

- **Get All Coffees**
  - **Endpoint**: `GET /api/coffees`
  - **Description**: Retrieves all coffees.
  
- **Get Coffee by ID**
  - **Endpoint**: `GET /api/coffees/{id}`
  - **Description**: Retrieves a specific coffee by ID.
  
- **Create Coffee**
  - **Endpoint**: `POST /api/coffees`
  - **Description**: Creates a new coffee.
  - **Body**:
    ```json
    {
      "name": "Espresso",
      "price": 2.5,
      "description": "Rich and strong coffee",
      "intensity": 5,
      "imageUrl": "http://example.com/image.jpg",
      "type": 1,
      "brand": 1
    }
    ```
  
- **Update Coffee**
  - **Endpoint**: `PUT /api/coffees/{id}`
  - **Description**: Updates an existing coffee.
  - **Body**:
    ```json
    {
      "id": "guid",
      "name": "Espresso",
      "price": 2.5,
      "description": "Rich and strong coffee",
      "intensity": 5,
      "imageUrl": "http://example.com/image.jpg",
      "type": 1,
      "brand": 1
    }
    ```

- **Delete Coffee**
  - **Endpoint**: `DELETE /api/coffees/{id}`
  - **Description**: Deletes a coffee by ID.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
