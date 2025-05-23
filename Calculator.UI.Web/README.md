# Calculator.UI.Web

This is a simple web-based calculator implemented with ASP.NET Core MVC for backend logic and plain HTML, CSS, and JavaScript for the frontend UI.

## Features

- Basic arithmetic operations: Addition (+), Subtraction (−), Multiplication (×), and Division (÷)
- Clear display, negate number, and percentage functions
- Keyboard support for digits, operators, Enter (equals), Escape (clear), and others
- Responsive, styled calculator UI using CSS Grid
- Server-side calculation handled in the MVC controller with validation

## Project Structure

- **Calculator.UI.Mvc.Controllers.HomeController**  
  Handles input GET and result POST requests.  
  - `Input` action displays the calculator input view  
  - `Result` action performs calculations and returns the result view

- **Views**  
  HTML markup and client-side JavaScript handle user interaction and display.

## How It Works

- The user inputs numbers and selects operations using buttons or keyboard.
- The UI script manages display and user input.
- When calculation is requested (pressing `=`), the UI computes the result locally.
- Alternatively, on form submission, the MVC controller performs the calculation on the server and returns the result view.

## Usage

1. Run the ASP.NET Core MVC project.
2. Navigate to `/Home/Input` in your browser.
3. Use the on-screen buttons or your keyboard to enter numbers and operations.
4. Press `=` or Enter to see the result.
5. Use `C` or Escape to clear the display.
6. Use `%` to convert the current value to a percentage.
7. Use `±` or `N` key to negate the current value.

## Technologies Used

- ASP.NET Core MVC
- C#
- HTML5 / CSS3
- JavaScript (vanilla)

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