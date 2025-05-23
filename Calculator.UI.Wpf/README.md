# Calculator.UI.Wpf

This project implements the user interface for the Calculator application using Windows Presentation Foundation (WPF).

---

## Overview

The WPF UI provides a sleek, dark-themed calculator interface with support for:

- Basic arithmetic operations: addition, subtraction, multiplication, and division.
- Number input with decimal support.
- Negation (±) and percentage (%) functions.
- Keyboard input support for all operations and digits.
- Clear function to reset the calculator.
- Real-time display of input and results.

---

## User Interface

- The main window is centered on the screen with a dark background (`#FF121212`).
- Buttons use a consistent modern style with rounded corners and hover/press effects.
- The display is a large read-only textbox aligned right, showing current input or result.

### Layout

- The calculator layout uses a `UniformGrid` with 4 columns and 5 rows.
- Buttons are organized logically for easy user input.
- The "=" button spans two columns for prominence.

---

## Key Components & Features

### MainWindow.xaml.cs

- Handles button click events for numbers, operations, decimal, clear, negate, percent, and equals.
- Maintains internal state for current value, last value, selected operation, and input mode.
- Uses `Calculator.Core.Operations` for applying arithmetic logic via the `IOperation` interface.
- Keyboard events map keys to corresponding calculator functions for efficient input.

### Supported Operations

- Addition (`+`)
- Subtraction (`−`)
- Multiplication (`×`)
- Division (`÷`)

### Special Features

- Error handling shows "Error" on invalid operations (e.g., division by zero).
- Decimal points are managed to prevent invalid input.
- Negation toggles the sign of the current input.
- Percent converts the current input to a fraction of 1 (divides by 100).

---

## Keyboard Shortcuts

| Key                | Action               |
|--------------------|----------------------|
| 0-9, NumPad0-9     | Input digits         |
| Decimal            | Insert decimal point |
| Add                | Addition (+)         |
| Subtract           | Subtraction (−)      |
| Multiply           | Multiplication (×)   |
| Divide             | Division (÷)         |
| Enter              | Calculate (=)        |
| Escape             | Clear (C)            |


---

## How to Run

- Build and run the WPF project in Visual Studio.
- The calculator window will open centered with full keyboard and mouse support.

---

## Extensibility

- Operations are implemented using the `IOperation` interface from the core project, making it easy to add new operations.
- The UI and logic are cleanly separated; UI logic manages input and display, while the core handles calculations.

---

## Example Usage

- Click number buttons or type digits on the keyboard.
- Click or type an operation symbol.
- Click "=" or press Enter to calculate.
- Use "C" or Escape to clear.
- Use "±" to negate the current input.
- Use "%" to convert the current input to a percentage.

---