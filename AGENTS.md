# Hotel Management System — Agent Instructions

## Project Overview
ASP.NET Core 10 hotel management system using **Clean Architecture** with SQLite (EF Core 10.0.9).
The solution is early-stage: architecture is scaffolded and documented, but domain/entities, application services, infrastructure, and API endpoints are not yet implemented.

**Before modifying domain entities, relationships, or adding new features, read [docs/rules.md](./docs/rules.md) and [docs/erd.mmd](./docs/erd.mmd) for constraints and the full ERD.**

## Solution Structure
```
HotelManagement.slnx       # XML solution format (.slnx)
├── Domain/                # Entities, value objects, enums, domain interfaces (no dependencies)
├── Application/           # Use cases, DTOs (records), FluentValidation, service interfaces (→ Domain)
├── Infrastructure/        # EF Core DbContext, repositories (→ Application)
└── API/                   # ASP.NET Core minimal API entry point (→ Application, → Infrastructure)
```

**Dependency direction:** API → Infrastructure → Application → Domain. Domain has zero external dependencies.

## Light Modular Structure
All layers follow a **light modular folder structure** grouped by domain category. The 5 modules are: `Room`, `Booking`, `Staff`, `Service`, `Housekeeping`.

```
Domain/Entities/Room/          Application/Services/Booking/
Domain/Entities/Booking/        Application/Contracts/Room/
Domain/Entities/Staff/         Application/DTOs/Staff/
Domain/Entities/Service/       Infrastructure/Repositories/Service/
Domain/Entities/Housekeeping/  API/Controllers/Housekeeping/
```

Each module folder contains only its own types. Cross-module communication uses IDs (FKs) and service interfaces — never direct entity references across modules.

## Build & Run Commands
```bash
dotnet build                        # Build entire solution
dotnet build Domain/                # Build single project
dotnet run --project API           # Run the API (listens on http://localhost:5234)
dotnet ef migrations add <Name> --project Infrastructure --startup-project API  # Add migration
dotnet ef database update --project Infrastructure --startup-project API        # Apply migration
```

## Architecture & Layer Rules
- **Clean Architecture** — domain logic never leaks into outer layers.
- **Base entity class** — all entities inherit from `BaseEntity` (`Domain/Entities/BaseEntity.cs`) which provides audit fields (`Id`, `CreatedAt`, `UpdatedAt`, `CreatedBy`, `UpdatedBy`, `DeletedAt`). Never repeat these fields on individual entities.
- **Soft delete** — entities are never hard-deleted; set `DeletedAt` to mark as deleted. Use a global query filter in DbContext to auto-filter soft-deleted entities.
- **Base repository pattern** — use a generic `Repository<T>` base class; concrete repositories only add query-specific methods.
- **DbContext configuration** — configure DbSet rules (fluent API) in `OnModelCreating`, not data annotations.
- **DTOs are `record` types** — immutable, defined in the Application layer.
- **Validation** — use FluentValidation (not DataAnnotations) for DTO validation.
- **DI registration** — each layer exposes a `ServiceCollection` extension method (e.g., `services.AddDomain()`, `services.AddApplication()`, `services.AddInfrastructure()`).
- **Project references** — outer layers reference inward only. Domain never references any other project.

## Conventions
- Target framework: `net10.0` for all projects.
- `ImplicitUsings` and `Nullable` are enabled in all projects.
- No global using files — rely on implicit usings.
- No HTTPS profile configured — the app runs on HTTP only (port 5234).
- Solution file format is `.slnx` (XML), not the legacy `.sln` format.

## Key Documentation
| File | Purpose |
|---|---|
| [docs/rules.md](./docs/rules.md) | Architecture rules and coding conventions |
| [docs/erd.mmd](./docs/erd.mmd) | Entity-Relationship diagram (Mermaid) — 15 entities with full attribute definitions and relationships |

## Gotchas
- Domain, Application, and Infrastructure projects are currently **empty** (no .cs files) — implementation is pending.
- There are **no test projects** in the solution yet.
- FluentValidation NuGet package has not been added yet — will be needed when DTOs are implemented.
