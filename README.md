# OpsDesk

OpsDesk is an enterprise service desk and asset management platform scaffolded with ASP.NET Core, C#, SQL Server, Entity Framework Core, MVC/Razor, REST APIs, Identity, background jobs, reporting, Docker, and automated tests in mind.

## Overview

The application will combine ticket management, IT asset inventory, asset request approvals, audit logging, dashboards, exports, and REST API access in a clean layered architecture.

## Tech Stack

- C# and ASP.NET Core targeting `net9.0`
- ASP.NET Core MVC with Razor Views
- ASP.NET Core Web API
- SQL Server planned through Entity Framework Core
- ASP.NET Core Identity planned for authentication and roles
- xUnit test projects
- Docker Compose for local SQL Server
- GitHub Actions CI

## Architecture

```text
src/OpsDesk.Web            MVC/Razor UI
src/OpsDesk.Api            REST API surface
src/OpsDesk.Application    Use cases, DTOs, interfaces, business rules
src/OpsDesk.Domain         Entities, enums, value objects, domain constants
src/OpsDesk.Infrastructure EF Core, Identity, repositories, reporting, jobs
src/OpsDesk.Shared         Shared pagination and error contracts
tests/OpsDesk.UnitTests
tests/OpsDesk.IntegrationTests
```

Dependency direction:

```text
Web/API -> Application -> Domain
Web/API -> Infrastructure -> Application/Domain
Shared can be used by application-facing projects
```

## Getting Started

```bash
dotnet restore OpsDesk.sln
dotnet build OpsDesk.sln
dotnet test OpsDesk.sln
```

Run the MVC app:

```bash
dotnet run --project src/OpsDesk.Web/OpsDesk.Web.csproj
```

Run the API:

```bash
dotnet run --project src/OpsDesk.Api/OpsDesk.Api.csproj
```

## Running with Docker

Start SQL Server:

```bash
docker compose up -d sqlserver
```

The default development password is supplied through `MSSQL_SA_PASSWORD` in `docker-compose.yml`. Override it in your shell or a local `.env` file before starting the container.

## Roadmap

- Phase 1: domain entities, enums, EF Core DbContext, configurations, migrations, and seed data
- Phase 2: Identity, roles, policies, login, and demo accounts
- Phase 3: ticket management MVP
- Phase 4: asset management MVP
- Phase 5: asset request workflow
- Phase 6: REST API and Swagger/OpenAPI
- Phase 7: reporting, exports, Hangfire jobs, and notifications
- Phase 8: polish, screenshots, and deployment preparation
