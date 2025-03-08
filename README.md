# Customer and Order Management API

This project is an API built with .NET 9 that provides functionality for managing customers and their associated orders. The API follows a clean architecture with the **Repository Pattern** and **Unit of Work** pattern for effective data access and manipulation. It also implements **CORS** to allow unrestricted access for external clients and applications, making it suitable for testing and integration.

## Features:
- **Customer Management**: Allows you to retrieve customer information such as name, email, phone, address, and associated orders.
- **Order Management**: Provides details of each order including order ID, number, date, and total amount.
- **Repository Pattern**: Implements a generic repository for managing CRUD operations efficiently.
- **Unit of Work**: Combines multiple repository operations into a single transaction, ensuring data consistency.
- **Cross-Origin Resource Sharing (CORS)**: Configured to allow API consumption from any origin, enabling testing from external sources.

## Technologies Used:
- **.NET 9**: The latest version of the .NET framework.
- **Entity Framework Core**: ORM used for interacting with the database.
- **Swagger/OpenAPI**: For testing the API via an interactive UI.
- **CORS**: Configured to allow external applications to make requests to the API.

## Getting Started:
1. Clone the repository.
2. Install dependencies.
3. Run the API locally or deploy it to your desired environment.
4. Use the Swagger UI or Postman to interact with the API.
