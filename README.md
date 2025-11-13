# ExpressionEvaluator

Problem statement:
REST API service to calculate expression.
User passes expression as string (i.e. "3+4*6 - 12"), service calculates expression and returns result.
Each request and response is stored in DB table. Service also provides endpoint to find expressions by the results they generate

## Overview

The **ExpressionEvaluator** solution is designed to safely parse and evaluate string-based mathematical and logical expressions without the risks associated with direct code execution. It's built using the industry-standard expression parsing library **NCalc**, allowing for robust and performant expression evaluation with minimal computational overhead.

## Features

- **Expression Parsing**: Converts string expressions into evaluable format
- **Mathematical Operations**: Full support for arithmetic operations (+, -, *, /, %, ^)
- **Error Handling**: Validation and error reporting for invalid expressions

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

Install the dependencies:

```bash
dotnet add package NCalc
```



## Security Considerations

- **Sandboxing**: Expressions are evaluated in a sandboxed environment and cannot execute arbitrary code
- **Whitelist Functions**: Only predefined functions are available; custom code execution is not possible
- **Parameter Isolation**: Parameters are isolated and cannot access system resources
- **Input Validation**: All expressions should be validated before evaluation

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
