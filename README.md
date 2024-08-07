## Key Technologies

- **.NET 8**
- **Minimal APIs**
- **Entity Framework Core**
- **Carter**
- **Mapster**
- **CQRS with Mediatr**
- **Pipeline Behaviors (Mediatr)**
- **Health Check**
- **Docker**

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)

## Running the Application

1. Clone the repository and navigate to the directory:
   ```bash
   git clone https://github.com/frnndlima/products-api.git
   cd products-api

2. Start Docker containers using Docker Compose:
    ```bash
    docker-compose up -d
    
3. Access the API locally. Depending on the configuration, access it at http://localhost:8080 (HTTP) or https://localhost:8081 (HTTPS), as defined in Docker Compose.

### Configuration
Adjust settings in the appsettings.json file as needed.
