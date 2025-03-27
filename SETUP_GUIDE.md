# Setup Guide for Modern Hotel Management System

This guide provides detailed instructions for setting up and running the Modern Hotel Management System on your local machine.

## Prerequisites

Before you begin, ensure you have the following installed:

1. **Visual Studio 2022** or later (Community, Professional, or Enterprise edition)
2. **.NET 6 SDK** or later
3. **SQL Server** (LocalDB, Express, or higher)
4. **Entity Framework Core Tools** (can be installed via NuGet Package Manager)

## Setup Steps

### 1. Clone or Download the Repository

If you haven't already, clone the repository to your local machine:

```bash
git clone https://github.com/AyhamJo7/ModernHotel.git
cd modern-hotel-management
```

### 2. Set Up the Database

#### Option 1: Using Visual Studio

1. Open the solution in Visual Studio by double-clicking on `ModernHotel.sln`
2. Open the Package Manager Console (Tools > NuGet Package Manager > Package Manager Console)
3. Set the default project to `ModernHotel.Infrastructure`
4. Run the following command to create the database:

```
Update-Database
```

#### Option 2: Using .NET CLI

1. Open a command prompt or terminal
2. Navigate to the solution directory
3. Run the following command:

```bash
dotnet ef database update --project ModernHotel.Infrastructure --startup-project ModernHotel.Presentation
```

### 3. Configure the Connection String (if needed)

If you're not using LocalDB or need to customize the connection string:

1. Open `ModernHotel.Presentation/appsettings.json`
2. Modify the `DefaultConnection` string to match your SQL Server instance:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=ModernHotelDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

### 4. Build the Solution

#### Using Visual Studio

1. In Visual Studio, select `Build > Build Solution` or press `Ctrl+Shift+B`

#### Using .NET CLI

1. In a command prompt or terminal, navigate to the solution directory
2. Run the following command:

```bash
dotnet build
```

### 5. Run the Application

#### Using Visual Studio

1. Set `ModernHotel.Presentation` as the startup project (right-click on the project in Solution Explorer and select "Set as Startup Project")
2. Press `F5` or click the "Start" button to run the application

#### Using .NET CLI

1. In a command prompt or terminal, navigate to the solution directory
2. Run the following command:

```bash
dotnet run --project ModernHotel.Presentation
```

### 6. Login to the Application

When the application starts, you'll be presented with a login screen. Use the following default credentials:

- **Username**: admin
- **Password**: Admin@123

## Troubleshooting

### Database Connection Issues

If you encounter database connection issues:

1. Verify that SQL Server is running
2. Check that the connection string in `appsettings.json` is correct
3. Ensure that the database has been created using Entity Framework migrations
4. Check that the user specified in the connection string has appropriate permissions

### Build Errors

If you encounter build errors:

1. Make sure you have the correct version of .NET SDK installed
2. Restore NuGet packages (right-click on the solution in Solution Explorer and select "Restore NuGet Packages")
3. Clean the solution and rebuild (Build > Clean Solution, then Build > Build Solution)

### Runtime Errors

If you encounter runtime errors:

1. Check the application logs in the `Logs` directory
2. Verify that all required services are running
3. Ensure that the database schema is up to date

## Testing the Application

### Manual Testing

After logging in, you can test the various features of the application:

1. **Room Management**: Create room types and rooms
2. **Customer Management**: Add customers to the system
3. **Booking Management**: Create bookings for customers
4. **Service Management**: Add services and assign them to bookings
5. **Billing**: Generate bills for bookings and process payments
6. **Reporting**: Generate various reports

### Automated Testing (for Developers)

If you want to run the automated tests:

#### Using Visual Studio

1. Open Test Explorer (Test > Test Explorer)
2. Click "Run All" to run all tests

#### Using .NET CLI

1. In a command prompt or terminal, navigate to the solution directory
2. Run the following command:

```bash
dotnet test
```

## Development Environment Setup

If you plan to contribute to the project, here are some additional setup steps:

1. Install the following Visual Studio extensions:
   - CodeMaid (for code cleanup)
   - ReSharper or Visual Studio Productivity Tools (for code analysis)

2. Configure code style settings:
   - Use the `.editorconfig` file included in the repository

3. Set up Git hooks (optional):
   - Install Husky.NET for pre-commit hooks

## Next Steps

Once you have the application running, you might want to:

1. Explore the codebase to understand the architecture
2. Add sample data to test different scenarios
3. Customize the application to fit your specific needs
4. Contribute to the project by fixing bugs or adding features

## Support

If you encounter any issues not covered in this guide, please:

1. Check the project's GitHub Issues page for known issues
2. Create a new issue if your problem hasn't been reported
3. Contact the project maintainers for additional support
