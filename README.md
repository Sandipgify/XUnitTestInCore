# XUnittestInCore

## Overview

XUnittestInCore is a .NET solution comprising three class libraries, a main API project, and a dedicated test project. This project follows best practices for modularity and testability.

## Libraries

- **Domain:** Defines core entities, serving as the foundation for the data layer.
  
- **Service:** Manages business logic and includes DTOs, mapping, service interfaces, and implementations.
  
- **Data:** Handles data retrieval from the database, encompassing entity configurations, repositories, and data seeding.

## Frameworks

- **Moq:** Utilized in the test project for setting up mock behaviors, enabling controlled testing of the service layer.

## Components

- **Main API Project:** Exposes CRUD operations for client entities within controllers, acting as the primary entry point for application interaction.
  
- **Test Project:** Dedicated to testing services, covering both success and failure scenarios.

## Running Tests

1. Build the solution.
2. Navigate to the test project.
3. Run the tests using your preferred test runner.
