# Team Bicep Frontend

A Blazor (.NET 8) web frontend for the Team Bicep demo Todo application. It renders a list of todos from a backend API
and lets you toggle completion and delete items.

This project is intended to be used alongside a backend API that exposes REST endpoints under `api/todos`.

- View todos
- Toggle a todo between Complete/Incomplete
- Delete a todo

## Tech stack

- .NET 8
- ASP.NET Core Blazor

## Repository layout

```
team-bicep-frontend/
├─ README.md
└─ src/TeamBicep.WebApp/
   ├─ TeamBicep.WebApp.csproj
   ├─ Program.cs                 # App bootstrap, DI, CORS, HttpClient base URL
   ├─ Dockerfile                 # Container build for the frontend
   ├─ Models/                    # TodoItem, InputTodoItem
   ├─ Services/
   │  ├─ Interface/ITodosService.cs
   │  └─ TodosApiService.cs     # Calls backend: GET/POST/PUT/DELETE api/todos
   ├─ UI/
   │  ├─ Pages/Home.razor       # Fetches todos and renders TodoList
   │  ├─ Components/
   │  │  ├─ TodoList.razor      # Toggle/Delete logic
   │  │  └─ TodoItemCard.razor  # Card UI for a single item
   │  └─ Shared/                 # App shell, routing, layout
   ├─ appsettings.json
   └─ appsettings.Development.json
```

## Prerequisites

- .NET 8 SDK
- A running backend API that implements the following endpoints at the configured base URL:
    - `GET    api/todos`
    - `POST   api/todos`
    - `PUT    api/todos/{id}`
    - `DELETE api/todos/{id}`

## Configuration

The frontend needs the backend API base URL.

- Development (default when running locally):
    - Set `ApiBaseUrl` in `src/TeamBicep.WebApp/appsettings.Development.json`.
    - The repository ships with:
      ```json
      {
        "ApiBaseUrl": "https://localhost:7001"
      }
      ```
- Production (or when `ASPNETCORE_ENVIRONMENT != Development`):
    - Use configuration key `BackendApi` or environment variable `BackendApi`.
    - Example environment variable:
        - `BackendApi=https://api.example.com`

CORS: The app currently allows any origin, method, and header (suitable for demos; tighten for production).
