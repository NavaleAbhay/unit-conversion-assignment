# unit-conversion-assignment

## Description

A simple unit conversion API that converts values between different units across multiple categories.

- Supports length, weight, and temperature conversions
- Easy to extend with new unit categories
- Built with .NET and follows clean architecture principles

## How to Run Locally

### Prerequisites
- .NET 10.0 or higher installed

### Steps

1. Clone or download the project
2. Navigate to the project folder:
   ```
   cd UnitConversion.API
   ```
3. Restore dependencies:
   ```
   dotnet restore
   ```
4. Run the application:
   ```
   dotnet run
   ```
5. The API will be available at `http://localhost:5145`

## API Endpoint

- **POST** `/api/conversion/convert`
- Send JSON with `fromUnit`, `toUnit`, and `value`

### Example Request
```json
{
  "fromUnit": "meter",
  "toUnit": "foot",
  "value": 10
}
```

## Design Decisions

- **Strategy Pattern** - Each conversion type (length, weight, temperature) has its own strategy for flexibility
- **Factory Pattern** - Central factory manages strategy selection based on category
- **Separate Layers** - Provider, Service, and Controller layers keep concerns separated
- **Base Unit Conversion** - Length and weight use base units to avoid complex conversion matrices

## Trade-offs

- Strategy instances are created fresh each time (could be cached for performance if needed)
- Simple in-memory provider (could be replaced with database in future)
