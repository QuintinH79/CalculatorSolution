# Calculator.Core

A modular, extensible core library for performing basic arithmetic operations in a calculator application.  
Designed for use in .NET 8.0 projects.

---

## Overview

`Calculator.Core` implements a clean, object-oriented design for arithmetic operations and calculation evaluation. It uses the Strategy pattern to separate operations and supports easy extension with new operations.

---

## Features

- Supports basic arithmetic operations:  
  - Addition (`+`)  
  - Subtraction (`−`)  
  - Multiplication (`×`)  
  - Division (`÷`) (with division-by-zero protection)
- Operation abstraction with `IOperation` interface and base class `BaseOperation`
- Factory pattern implementation (`OperationFactory`) to create operations based on symbols
- Central `CalculatorEngine` to evaluate expressions by delegating to the proper operation instance
- Designed for testability and extensibility

---

## Project Details

### Target Framework

- .NET 8.0 (`net8.0`)

### Core Interfaces and Classes

#### `IOperation`

public interface IOperation
{
    double Apply(double left, double right);
}

Defines a contract for arithmetic operations.

#### `BaseOperation`

public abstract class BaseOperation : IOperation
{
    public abstract double Apply(double left, double right);
}

Abstract base class to implement common operation logic.

#### Concrete Operations

* `AddOperation` - Adds two numbers.
* `SubtractOperation` - Subtracts right operand from left.
* `MultiplyOperation` - Multiplies two numbers.
* `DivideOperation` - Divides left by right, throws on division by zero.

Each overrides `Apply(left, right)` accordingly.

#### `IOperationFactory`

public interface IOperationFactory
{
    IOperation CreateOperation(string operationType);
}

Factory interface for creating operation instances based on operator symbol.

#### `OperationFactory`

public class OperationFactory : IOperationFactory
{
    private readonly Dictionary<string, Type> _operations = new()
    {
        { "+", typeof(AddOperation) },
        { "−", typeof(SubtractOperation) },
        { "×", typeof(MultiplyOperation) },
        { "÷", typeof(DivideOperation) }
    };

    public IOperation CreateOperation(string operationType)
    {
        if (!_operations.TryGetValue(operationType, out var operationTypeValue))
            throw new InvalidOperationException("Unknown operation");

        var operation = Activator.CreateInstance(operationTypeValue) as IOperation
            ?? throw new InvalidOperationException("Failed to create operation instance.");

        return operation;
    }
}

Maps operator symbols to operation classes and creates instances dynamically.

#### `CalculatorEngine`

public class CalculatorEngine
{
    private readonly IOperationFactory _operationFactory;

    public CalculatorEngine(IOperationFactory operationFactory)
    {
        _operationFactory = operationFactory ?? throw new ArgumentNullException(nameof(operationFactory));
    }

    public double Evaluate(double left, double right, string op)
    {
        var operation = _operationFactory.CreateOperation(op);
        return operation.Apply(left, right);
    }
}

Central class to evaluate expressions by delegating to the appropriate operation.

---

## Usage Example

var factory = new OperationFactory();
var engine = new CalculatorEngine(factory);

double result = engine.Evaluate(5, 3, "+");  // result = 8
double quotient = engine.Evaluate(10, 2, "÷");  // quotient = 5

---

## Notes

* Division by zero will throw a `DivideByZeroException`.
* To extend with new operations, implement `IOperation` and register in `OperationFactory`.

---