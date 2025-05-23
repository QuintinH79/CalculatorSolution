# Calculator.Tests

Unit tests project for the `Calculator.Core` library.  
This project uses **xUnit** to verify the correctness and robustness of the calculator engine and its operations.

---

## Overview

The `Calculator.Tests` project validates the behavior of the core calculator engine by running tests against the arithmetic operations and their integration via the factory pattern.

---

## Features

- Tests basic arithmetic operations: addition, subtraction, multiplication, and division.
- Validates correct results for a variety of numeric inputs.
- Ensures proper exception handling for:
  - Division by zero (throws `DivideByZeroException`)
  - Unknown/unsupported operations (throws `InvalidOperationException`)
- Uses parameterized tests (`[Theory]` with `[InlineData]`) to cover multiple cases succinctly.

---

## Testing Framework

- **xUnit** is used as the test framework.
- Tests are written in C# targeting .NET 8.0.

---

## Important Test Classes and Methods

### `CalculatorEngineTests`

- Initializes `CalculatorEngine` with `OperationFactory`.
- `Evaluate_ValidOperations_ReturnsCorrectResult`  
  Tests that correct results are returned for addition, subtraction, multiplication, and division, including decimals and zero.
  
- `Evaluate_DivideByZero_ThrowsDivideByZeroException`  
  Confirms that dividing by zero throws the expected exception with the correct message.
  
- `Evaluate_UnknownOperation_ThrowsInvalidOperationException`  
  Ensures that attempting an unsupported operation symbol throws an exception.

---

## Example Test Snippet

[Theory]
[InlineData(3, 2, "+", 5)]
[InlineData(3, 2, "−", 1)]
[InlineData(3, 2, "×", 6)]
[InlineData(3, 2, "÷", 1.5)]
public void Evaluate_ValidOperations_ReturnsCorrectResult(double left, double right, string op, double expected)
{
    var result = _engine.Evaluate(left, right, op);
    Assert.Equal(expected, result, 2);
}

---

## Running Tests

* Tests can be run using Visual Studio Test Explorer or the `dotnet test` CLI command targeting this project.
* Ensure the `Calculator.Core` project is referenced by the test project.

---

## Notes

* Tests cover basic operation correctness and critical failure modes.
* Additional tests can be added to cover new operations if extended.
* Test precision allows for small floating-point rounding errors by using a tolerance of 2 decimal places.

---