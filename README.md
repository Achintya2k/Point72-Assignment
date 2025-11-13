# ExpressionEvaluator

Problem statement:
REST API service to calculate expression.
User passes expression as string (i.e. "3+4*6 - 12"), service calculates expression and returns result.
Each request and response is stored in DB table. Service also provides endpoint to find expressions by the results they generate

## Overview

The **ExpressionEvaluator** solution is designed to safely parse and evaluate string-based mathematical and logical expressions without the risks associated with direct code execution. It's built using the industry-standard expression parsing library **NCalc**, allowing for robust and performant expression evaluation with minimal computational overhead.

## Features

- **Calculate Mathematical Expressions**: Submit expressions as strings (e.g., `"3+4*6-12"`) and receive computed results
- **Persistent Storage**: All calculations are automatically saved to a SQLite database
- **Search by Result**: Find all expressions that produced a specific result
- **Secure Expression Parsing**: Uses NCalc library to safely evaluate expressions without code injection risks
- **API Documentation**: Interactive Swagger UI for testing endpoints

## Usage Examples

### Basic Mathematical Expression

```csharp
using ExpressionEvaluator;

var expression = new Expression("2 + 3 * 5");
var result = expression.Evaluate();
// Result: 17
```

## Supported Operators

### Arithmetic Operators

| Operator | Description | Example |
|----------|-------------|---------|
| `+` | Addition | `5 + 3` → 8 |
| `-` | Subtraction | `10 - 4` → 6 |
| `*` | Multiplication | `6 * 7` → 42 |
| `/` | Division | `20 / 4` → 5 |
| `%` | Modulo | `17 % 5` → 2 |


## NuGet Dependencies

This component leverages the following NuGet packages:

- **NCalc**: Core expression parsing and evaluation library
- **Microsoft.EntityFrameworkCore.Sqlite**: SQLite database provider for Entity Framework Core
- **Microsoft.EntityFrameworkCore.Tools**: CLI tooling for EF Core migrations (`dotnet ef` commands)
- **Microsoft.EntityFrameworkCore.Design**: Design-time components for EF Core scaffolding and migrations
- **Swashbuckle.AspNetCore**: OpenAPI/Swagger documentation and UI for ASP.NET Core APIs

## Running the code
1. Clone the Repository
```bash
git clone https://github.com/yourusername/expression-calculator-api.git
cd ExpressionEvaluator
```

2. Install the dependencies:
Use
```bash
dotnet restore
```

If you run into any issues, manually install dependencies: 
```bash
dotnet add package NCalc
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Swashbuckle.AspNetCore
```
3. Run the following command to setup the SQlite DB:
```bash
dotnet ef database update
```
This creates the SQLite database (`ExpressionCalculator.db`) with the required schema.
If you want to view the DB (in VSCode), install the plugin - SQLite (by alexcvzz)
Open Command Palette -> Type "SQLite: Open Database" -> Select the ExpressionCalculator.db -> Open SQLite Panel in VSCode -> Righ-click on Epressions Table -> Show Table
Example:
| Id | ExpressionString | Result | CreatedAt |
|----|------------------|--------|---------------------------|
| 16 | 1+5-3*(5-2)*7 | -57.0 | 2025-11-13 13:43:22.086064 |
| 17 | 3+4*6 - 12 | 15.0 | 2025-11-13 13:45:07.195573 |
| 18 | 75-6+1 | 70.0 | 2025-11-13 13:45:15.380134 |

4. Run the Application
```bash
dotnet run
```

### Usage Examples
## Using cURL

Calculate an expression
```bash
curl -X POST http://localhost:5250/api/v1/expressions/calculate -H "Content-Type: application/json" -d '{"expression": "3+4*6-12"}'
```
Find expressions by result
```bash
curl http://localhost:5250/api/v1/expressions/by-result/15
```
## Using Swagger UI

Navigate to `http://localhost:5250/swagger/index.html` in your browser for an interactive API testing interface.

## Resources

- [NCalc GitHub Repository](https://github.com/ncalc/ncalc)
- [NCalc Documentation](https://github.com/ncalc/ncalc/wiki)
- [Expression Parsing Theory](https://en.wikipedia.org/wiki/Parsing_expression_grammar)
- [Abstract Syntax Trees](https://en.wikipedia.org/wiki/Abstract_syntax_tree)

## Troubleshooting

### Common Issues

**Issue: "Unknown function" error**

Solution: Ensure the function name is correctly spelled and is one of the supported functions. For custom functions, ensure they are registered before evaluation.

**Issue: "Type mismatch" during evaluation**

Solution: Verify parameter types match what the expression expects. Use explicit type conversion if needed.

**Issue: "Parameter not found" error**

Solution: Check that all parameters referenced in the expression are bound with the exact same names (case-sensitive).



## Author

**Achintya**
- GitHub: [@Achintya2k](https://github.com/Achintya2k)

---

**Last Updated**: November 2025

For questions or issues related to this component, refer to the main project README or create an issue in the repository.
