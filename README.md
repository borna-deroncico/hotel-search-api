# Hotel Search API

A simple REST API built with **ASP.NET Core** for managing and searching hotel data.

## Features

* Retrieve hotel information through REST endpoints
* Search and filter hotels
* Store and access hotel data using a PostgreSQL database
* Built with Entity Framework Core and .NET

## Controllers

### HotelsController

The `HotelsController` handles all hotel-related operations:

* Get all hotels
* Get a hotel by ID
* Create new hotel entries
* Update existing hotel information
* Delete hotels

## Technologies

* C# / ASP.NET Core Web API
* Entity Framework Core
* PostgreSQL
* REST JSON API

## Running the Project

1. Clone the repository
2. Configure the database connection in `appsettings.json`
3. Run database migrations
4. Start the API:

```bash
dotnet run
```

The API will start and provide available endpoints through Swagger/OpenAPI.
