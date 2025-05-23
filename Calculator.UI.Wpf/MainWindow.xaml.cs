using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Calculator.Core.Operations;

namespace Calculator.UI.Wpf
{
    public partial class MainWindow : Window
    {
        private double _currentValue = 0;
        private double _lastValue = 0;
        private double _lastRightValue = 0;
        private IOperation? _currentOperation = null;
        private bool _isNewEntry = true;
        private bool _repeatLastOperation = false;

        public MainWindow()
        {
            InitializeComponent();
            Display.Text = "0";
            Loaded += (_, _) => Keyboard.Focus(this);
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
                AppendNumber(button.Content.ToString());
        }

        private void AppendNumber(string? number)
        {
            if (_isNewEntry || Display.Text == "0")
            {
                Display.Text = number;
                _isNewEntry = false;
            }
            else
            {
                Display.Text += number;
            }
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
                SetOperation(button.Content.ToString());
        }

        private void SetOperation(string? op)
        {
            if (!_isNewEntry && double.TryParse(Display.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
            {
                if (_currentOperation != null)
                {
                    _lastValue = _currentOperation.Apply(_lastValue, value);
                    Display.Text = _lastValue.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    _lastValue = value;
                }
            }

            _currentOperation = op switch
            {
                "+" => new AddOperation(),
                "−" => new SubtractOperation(),
                "×" => new MultiplyOperation(),
                "÷" => new DivideOperation(),
                _ => null
            };

            _isNewEntry = true;
            _repeatLastOperation = false;
        }

        private void Equals_Click(object sender, RoutedEventArgs e) => Calculate();

        private void Calculate()
        {
            if (double.TryParse(Display.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double right))
            {
                try
                {
                    if (_repeatLastOperation && _currentOperation != null)
                    {
                        _lastValue = _currentValue;
                        right = _lastRightValue;
                    }
                    else if (_currentOperation != null)
                    {
                        _lastRightValue = right;
                    }

                    if (_currentOperation != null)
                    {
                        _currentValue = _currentOperation.Apply(_lastValue, _lastRightValue);
                        Display.Text = _currentValue.ToString(CultureInfo.InvariantCulture);
                        _repeatLastOperation = true;
                    }
                }
                catch
                {
                    Display.Text = "Error";
                }
            }
            _isNewEntry = true;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            _currentValue = 0;
            _lastValue = 0;
            _lastRightValue = 0;
            _currentOperation = null;
            Display.Text = "0";
            _isNewEntry = true;
            _repeatLastOperation = false;
        }

        private void Decimal_Click(object sender, RoutedEventArgs e) => AppendDecimal();

        private void AppendDecimal()
        {
            if (_isNewEntry)
            {
                Display.Text = "0";
                _isNewEntry = false;
            }

            if (!Display.Text.Contains("."))
                Display.Text += ".";
        }

        private void Negate_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Display.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
            {
                value = -value;
                Display.Text = value.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void Percent_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Display.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
            {
                value /= 100;
                Display.Text = value.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                AppendNumber((e.Key - Key.D0).ToString());
            }
            else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                AppendNumber((e.Key - Key.NumPad0).ToString());
            }
            else
            {
                switch (e.Key)
                {
                    case Key.Decimal:
                    case Key.OemPeriod:
                        AppendDecimal();
                        break;
                    case Key.Add:
                    case Key.OemPlus when Keyboard.Modifiers == ModifierKeys.None:
                        SetOperation("+");
                        break;
                    case Key.Subtract:
                    case Key.OemMinus:
                        SetOperation("−");
                        break;
                    case Key.Multiply:
                        SetOperation("×");
                        break;
                    case Key.Divide:
                    case Key.Oem2:
                        SetOperation("÷");
                        break;
                    case Key.Enter:
                        Calculate();
                        break;
                    case Key.Escape:
                        Clear_Click(null!, null!);
                        break;
                    case Key.F9:
                        Negate_Click(null!, null!);
                        break;
                    case Key.Oem5:
                    case Key.D5 when Keyboard.Modifiers == ModifierKeys.Shift:
                        Percent_Click(null!, null!);
                        break;
                }
            }
        }
    }
}
