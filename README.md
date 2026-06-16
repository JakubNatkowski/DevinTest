# CardDemo - C# Migration

This is a modern C# ASP.NET Core migration of the CardDemo mainframe credit card management application.

## Overview

The original CardDemo application was a comprehensive mainframe application written in COBOL that simulates a credit card management system. This migration modernizes the application using:

- **.NET 8.0** with ASP.NET Core for the web framework
- **Entity Framework Core** for data access
- **SQL Server** replacing VSAM/DB2/IMS databases
- **Clean Architecture** with separation of concerns

## Architecture

The solution is organized into three projects:

### CardDemo.Core
Contains the core business logic and domain entities:
- **Entities**: Customer, Account, Card, Transaction, User, CardAccountCrossReference
- **Services**: Business logic layer (Authentication, Account, Card, Transaction, Customer, User)
- **Interfaces**: Repository and service contracts

### CardDemo.Infrastructure
Contains data access and infrastructure implementations:
- **DbContext**: Entity Framework Core database context
- **Repositories**: Data access implementations for all entities

### CardDemo.Web
ASP.NET Core web application:
- **Controllers**: MVC controllers for web UI
- **Views**: Razor views for user interface
- **Configuration**: Application settings and dependency injection

## Features Migrated

### Core Application
- ✅ User authentication and signon (migrated from COSGN00C)
- ✅ Account management (migrated from COACTUPC, COACTVWC)
- ✅ Credit card management (migrated from COCRDUPC, COCRDLIC, COCRDSLC)
- ✅ Transaction processing (migrated from COTRN00C, COTRN01C, COTRN02C)
- ✅ Customer management
- ✅ User management (migrated from COUSR00C, COUSR01C, COUSR02C, COUSR03C)

### Optional Modules (Not Yet Migrated)
- ⏳ Credit Card Authorizations with IMS, DB2, and MQ
- ⏳ Transaction Type Management with DB2
- ⏳ Account Extractions using MQ and VSAM
- ⏳ Batch processing modules

## Getting Started

### Prerequisites
- .NET 8.0 SDK
- SQL Server (or SQL Server Express)
- Visual Studio 2022 or VS Code

### Database Setup

1. Update the connection string in `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=CardDemoDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

2. Run Entity Framework migrations to create the database:
```bash
cd src/CardDemo.Infrastructure
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Running the Application

1. Restore NuGet packages:
```bash
dotnet restore
```

2. Build the solution:
```bash
dotnet build
```

3. Run the application:
```bash
cd src/CardDemo.Web
dotnet run
```

4. Access the application at `https://localhost:5001`

### Demo Credentials

The application comes with demo users (these would need to be seeded in the database):

- **Admin User**: USER ID: `ADMIN001`, Password: `PASSWORD`
- **Regular User**: USER ID: `USER0001`, Password: `PASSWORD`

## Project Structure

```
CardDemo/
├── src/
│   ├── CardDemo.Core/           # Domain entities and business logic
│   │   ├── Entities/            # Domain models
│   │   ├── Interfaces/          # Repository and service interfaces
│   │   └── Services/           # Business logic implementations
│   ├── CardDemo.Infrastructure/ # Data access layer
│   │   ├── Data/               # DbContext
│   │   └── Repositories/       # Repository implementations
│   └── CardDemo.Web/           # Web application
│       ├── Controllers/        # MVC controllers
│       └── Views/              # Razor views
└── CardDemo.sln                # Solution file
```

## COBOL to C# Mapping

| COBOL Program | C# Equivalent | Description |
|--------------|---------------|-------------|
| COSGN00C | AccountController | Signon screen |
| COMEN01C | HomeController | Main menu |
| COACTUPC | AccountService | Account update |
| COACTVWC | AccountService | Account view |
| COCRDUPC | CardService | Card update |
| COCRDLIC | CardService | Card list |
| COCRDSLC | CardService | Card details |
| COTRN00C | TransactionService | Transaction list |
| COTRN01C | TransactionService | Transaction view |
| COTRN02C | TransactionService | Transaction add |
| COUSR00C | UserService | User list |
| COUSR01C | UserService | User add |
| COUSR02C | UserService | User update |
| COUSR03C | UserService | User delete |

## Database Schema

The application uses the following main tables:

- **Customers**: Customer information
- **Accounts**: Account details and balances
- **Cards**: Credit card information
- **Transactions**: Transaction records
- **Users**: User authentication and authorization
- **CardAccountCrossReferences**: Mapping between cards and accounts

## Future Enhancements

- [ ] Complete migration of optional modules (IMS/DB2/MQ)
- [ ] Implement batch processing jobs
- [ ] Add API endpoints for REST services
- [ ] Implement comprehensive logging and monitoring
- [ ] Add unit and integration tests
- [ ] Implement role-based access control
- [ ] Add data seeding for demo data
- [ ] Implement transaction reporting
- [ ] Add bill payment processing

## License

This project is licensed under the Apache License 2.0, same as the original CardDemo application.

## Acknowledgments

This migration is based on the AWS Mainframe Modernization CardDemo sample application.
