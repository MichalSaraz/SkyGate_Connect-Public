# SkyGate Connect

SkyGate Connect is a modern airport check‑in system designed to optimize and streamline pre‑flight processes. It provides REST APIs to manage passengers, baggage, seats, travel documents and flight‑management / boarding operations.

---

## Important (public version)

This repository is a public, trimmed version of the SkyGate Connect project. It contains only selected classes, data, and parts of the configuration. Other components located in the private repository have been removed.
The complete file and folder tree of this public version can be found in the `PROJECT_TREE.md` file.

## Key features

- Passenger check‑in and baggage management
- Travel document (APIS / TravelDocument) validation
- Seat allocation, seat change and swap operations
- Special Service Requests (SSR) and comments
- Action history / audit logging
- Boarding and load control workflows

---

## Tech stack

- .NET 7 / ASP.NET Core Web API
- Entity Framework Core 7
- PostgreSQL (primary relational database)
- MongoDB (used in this solution for action history)
- AutoMapper for object mapping
- xUnit + Moq for unit tests
- Docker / Docker Compose for local dependencies

---

## Prerequisites

- .NET 7 SDK installed
- Docker & Docker Compose (recommended for local DB services)
- Git

---

## Quick start (local development)

Follow these steps. Adjust paths and project names if you changed the solution layout.

1. Open the project folder

```bash
# This README documents the full project. The repository URL is intentionally omitted from this public snapshot.
cd SkyGate_Connect
```

2. Restore NuGet packages

```bash
dotnet restore
```

3. Copy environment template and edit values

```bash
cp .env.example .env
# edit .env with connection strings, secrets and environment settings
```

4. Start local dependencies (Postgres + MongoDB) with Docker Compose

```bash
docker compose up -d
```

5. Apply EF migrations (only when DB schema changes are made)

```bash
dotnet ef database update --project Infrastructure/Infrastructure.csproj --startup-project Web/Web.csproj
```

6. Run the application

```bash
dotnet run --project Web/Web.csproj
```

Default URL: `http://localhost:5000` (or the port configured in `launchSettings.json` / environment variables).

---

## Docker Compose (included file)

This repository contains a `docker-compose.yml` that brings up PostgreSQL and MongoDB for local development. For details, see the "Quick start" section.

---

## Environment variables (.env)

Create a local `.env` from `.env.example` when running with Docker, or use `dotnet user-secrets` for local development (recommended).

- For containerized runs (on other machines) copy and edit `.env.example` → `.env` and start docker compose (`docker compose up -d`).
- For local development you can keep secrets out of files and use the .NET user secrets store:
  - `cd Web`
  - `dotnet user-secrets init`
  - `dotnet user-secrets set "ConnectionStrings:DefaultConnection" "<your-conn>"`

---

## Tests

Run all tests:

```bash
dotnet test
```

Run a specific test project (example):

```bash
dotnet test AppTest/TestProject.csproj
```

---

## Project structure (simplified)

```
SkyGate_Connect/
├─ Application/        # Application services, validators, queries, facades
├─ Core/               # Domain entities, DTOs, interfaces
├─ Infrastructure/     # EF Core implementations, repositories, migrations
├─ Web/                # ASP.NET Core Web API (controllers, Program.cs)
├─ AppTest/            # Unit and integration tests (xUnit + Moq)
├─ Shared/             # Shared helpers, types
├─ docker-compose.yml  # Local services for development (Postgres, Mongo)
├─ .env.example        # Example environment variables
└─ README.md
```

## Architecture overview

The solution follows Clean Architecture principles:

- `Web` (presentation): HTTP API surface, model binding, controllers
- `Application`: use‑case orchestration, services, validators, queries and facades
- `Infrastructure`: database access (EF Core), repositories, concrete implementations
- `Core`: domain entities, DTOs, shared contracts/interfaces

This separation improves testability and makes business logic independent from framework concerns.

---

## Docker Compose (how it helps)

The included `docker-compose.yml` spins up PostgreSQL and MongoDB. Use it to have reproducible local DB dependencies. Services are configured to persist data in local Docker volumes so short restarts don't lose state.

---

## Notes on migration & renaming DB objects

- When renaming entities/tables consider using EF Core `RenameTable` / `RenameColumn` in migrations to preserve existing data. Dropping and recreating tables will delete data.
- Back up your database before applying destructive migrations in production.

---

## Concurrency, uniqueness and race conditions

- For concurrency‑sensitive operations (comments, seat assignment), prefer database constraints (unique indexes) and handle conflicts in the service layer. This is more robust than broad application locks.
- When high contention is expected, consider optimistic concurrency tokens (rowversion / timestamp) or explicit database transactions.

---

## Troubleshooting

- "Unable to resolve service ..." at startup: check service registrations in `Web/Program.cs` and `AddApplicationServices`.
- Database connection refused: ensure Docker services are up or your connection string points to an accessible DB.
- EF migrations: if you renamed entities, inspect generated migration code and adjust `RenameTable` / `RenameColumn` instead of dropping tables.

---

## Contact

- Author: Michal Sáraz

---

## License

This project is published under the MIT license (adjust per company policy).
