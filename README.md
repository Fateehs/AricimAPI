# AricimAPI

**AricimAPI** is a backend RESTful API built with **.NET 8** that powers a beekeeping management platform. It provides secure endpoints for managing users, hives, inspections, and related data.

---

## 🛠 Tech Stack

- **.NET 8 / ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server**
- **Layered Architecture (Domain, Application, Infrastructure, WebAPI)**
- **JWT Authentication**

---

## 📦 Features

- User registration and login
- Hive management (CRUD)
- Inspection scheduling and tracking
- Role-based authorization
- Structured and scalable architecture
- DTO mapping and validation

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)

### Setup

1. Clone the repository:
   ```
   bash
   git clone https://github.com/Fateehs/AricimAPI.git
   cd AricimAPI
   ```

2. Update the connection string in ```appsettings.Development.json```

3. Apply database migrations: ```dotnet ef database update```

4. Run the project: ```dotnet run --project src/Aricim.WebApi```

📁 Project Structure
```
src/
│
├── Aricim.Domain          # Entity models and interfaces
├── Aricim.Application     # DTOs, business logic, use cases
├── Aricim.Infrastructure  # EF Core DbContext and persistence
├── Aricim.WebApi          # API layer and controllers
```

🔐 Authentication
This API uses JWT Bearer Tokens for secure authentication. Users must be authenticated to access protected endpoints.

📄 License
This project is licensed under the MIT License.


