# Zoho CRM Integration API

A RESTful ASP.NET Core Web API that integrates with **Zoho CRM** using OAuth 2.0. The project demonstrates how to authenticate with Zoho, manage Contacts, create Deals, and synchronize customer data using a clean and modular architecture.

---

## Features

- OAuth 2.0 Authentication with Zoho CRM
- Generate Access Token using Refresh Token
- Create Contact
- Search Contact by Email
- Create Deal linked to an existing Contact
- Retrieve All Deals
- Retrieve Orders (Service Layer)
- Swagger API Documentation
- Clean Architecture
- Dependency Injection
- HttpClientFactory

---

## Tech Stack

- ASP.NET Core 8 Web API
- C#
- Zoho CRM REST API v8
- HttpClientFactory
- Swagger (OpenAPI)
- Clean Architecture

---

## Project Structure

```
ZohoIntegration
│
├── API
│   ├── Controllers
│   └── Program.cs
│
├── Application
│   ├── DTOs
│   ├── Interfaces
│   └── Services
│
├── Domain
│
└── Infrastructure
    ├── Configurations
    ├── Services
    └── Http
```

---

## Configuration

Update your `appsettings.json`

```json
{
  "Zoho": {
    "ClientId": "YOUR_CLIENT_ID",
    "ClientSecret": "YOUR_CLIENT_SECRET",
    "RefreshToken": "YOUR_REFRESH_TOKEN",
    "AccountsUrl": "https://accounts.zoho.com",
    "ApiUrl": "https://www.zohoapis.com/crm/v8"
  }
}
```

---

## API Endpoints

### Authentication

| Method | Endpoint | Description |
|---------|----------|-------------|
| GET | `/api/auth/token` | Generate Access Token |

---

### Contacts

| Method | Endpoint | Description |
|---------|----------|-------------|
| POST | `/api/contacts/create` | Create Contact |

---

### Deals

| Method | Endpoint | Description |
|---------|----------|-------------|
| POST | `/api/deal/create` | Create Deal |

---

### Orders

| Method | Endpoint | Description |
|---------|----------|-------------|
| PST | `/api/orders/create` | Create Order |

---

## Authentication Flow

```
Client
   │
   ▼
ASP.NET Core API
   │
   ▼
Zoho OAuth
   │
   ▼
Access Token
   │
   ▼
Zoho CRM
```

---

## Contact & Deal Workflow

```
Client Request
       │
       ▼
Search Contact
       │
 ┌─────┴─────┐
 │           │
Found     Not Found
 │           │
 │      Create Contact
 └─────┬─────┘
       ▼
Create Deal
       ▼
Return Success
```

---

## Example Request

### Create Contact

```http
POST /api/contacts
```

```json
{
  "firstName": "Ashraf",
  "lastName": "Abu Elrai",
  "email": "ashraf@test.com",
  "phone": "01012345678"
}
```

---

### Create Deal

```http
POST /api/deals
```

```json
{
  "dealName": "Laptop Order",
  "amount": 2500,
  "stage": "Qualification",
  "contactId": "7539270000000693001"
}
```

---

## Future Improvements

- Update Contact
- Delete Contact
- Retrieve Deal by Id
- WooCommerce Integration
- Global Exception Handling
- FluentValidation
- AutoMapper
- Serilog Logging
- Unit Testing

---

## Author

**Ashraf Abu Elrai**

Software Engineer (.NET)

- ASP.NET Core
- REST APIs
- Clean Architecture
- Zoho CRM Integration
