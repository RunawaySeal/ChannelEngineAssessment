# ChannelEngine Assessment

A .NET application demonstrating integration with the ChannelEngine REST API, featuring both console and web interfaces for managing orders and products.

## 📋 Overview

This project implements a multi-entry point application that connects to the ChannelEngine API to:
- Fetch orders with filter for status
- Identify top 5 best-selling products
- Update product stock levels
- Display results in both console and web interfaces

## 🏗️ Architecture

The solution follows a clean architecture pattern with the following projects:

```
ChannelEngineAssessment/
├── ChannelEngineAssessment.ConsoleApp/     # Console application entry point
├── ChannelEngineAssessment.WebApp/         # ASP.NET Core web application
├── ChannelEngineAssessment.Domain/         # Shared business logic and models
└── ChannelEngineAssessment.Tests/          # Unit tests
```

### Key Components

- **Domain Layer**: Contains business logic, models, and repository interfaces
- **Console App**: Command-line interface for executing business operations
- **Web App**: ASP.NET Core MVC application with HTML table displays
- **Tests**: Unit tests using xUnit framework

## ⚙️ Setup and Installation

### Prerequisites
- .NET 9.0 SDK
- Visual Studio 2022 or VS Code
- Internet connection (for ChannelEngine API access)

### Getting Started

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/ChannelEngineAssessment.git
   cd ChannelEngineAssessment
   ```

2. **Restore packages (or use visual studion interface)**
   ```bash
   dotnet restore
   ```

3. **Run the console application (or use visual studion interface)**
   ```bash
   dotnet run --project ChannelEngineAssessment.ConsoleApp
   ```

4. **Run the web application (or use visual studion interface)**
   ```bash
   dotnet run --project ChannelEngineAssessment.WebApp
   ```
   Then navigate to `https://localhost:7199` or `http://localhost:5056`

5. **Run tests (or use visual studion interface)**
   ```bash
   dotnet test
   ```
