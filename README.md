# Bogracz Sample Project

This repository contains a minimal ASP.NET Core solution with:

- **BograczApi**: Web API providing REST endpoints for `User`, `Product` and `Order` entities using an in-memory database. It exposes a gRPC service for product management and demonstrates JWT authentication, Swagger documentation and a simple middleware that logs request headers.
- **BograczUI**: Razor Pages application acting as a simple front-end with a login form and basic pages.
- **BograczApi.Tests**: xUnit test project with a sample controller test.

The solution is intended as a starting point for further development and does not represent a production-ready application.
