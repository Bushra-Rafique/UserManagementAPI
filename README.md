# UserManagementAPI

**UserManagementAPI** is a simple **ASP.NET Core Web API** for managing users. It supports **CRUD operations**, includes **data validation**, and is secured using **API key authentication**. The project demonstrates the use of **middleware**, **dependency injection**, and **logging**, developed and debugged with **GitHub Copilot**.

This project is submitted as a **Coursera assignment** for peer review.


## Features

- **CRUD Endpoints**:
  - `GET /api/Users` – Retrieve all users
  - `GET /api/Users/{id}` – Retrieve user by ID
  - `POST /api/Users` – Create new user
  - `PUT /api/Users/{id}` – Update user
  - `DELETE /api/Users/{id}` – Delete user

- **Data Validation** to ensure only valid user data is processed
- **Custom Middleware**:
  - Logging requests and responses
  - API key authentication (`X-Api-Key`)
  - Global error handling
- **Swagger UI** for interactive API testing


## Technologies Used

- ASP.NET Core 8.0
- C#
- Swashbuckle / Swagger
- Git & GitHub
- VS Code

---

## How to Run

1. Clone the repository:

```bash
git clone https://github.com/Bushra-Rafique/UserManagementAPI.git
cd UserManagementAPI

2. Restore dependencies:
```bash
dotnet restore

3. Build the project:
```bash
dotnet build

4. Run the application:
```bash
dotnet watch run

## Authentication
All endpoints require an API key:
```bash
X-Api-Key: mysecret
You can provide it in headers or as a query parameter:
```bash
http://localhost:5000/api/Users?api_key=mysecret

---

## Assignment Requirements Covered

| Requirement                                   | Status |
|-----------------------------------------------|--------|
| GitHub repository created                      | ✅     |
| CRUD endpoints implemented                     | ✅     |
| Debugged with Copilot                           | ✅     |
| Data validation implemented                    | ✅     |
| Middleware integrated (Logging & Authentication) | ✅     |


