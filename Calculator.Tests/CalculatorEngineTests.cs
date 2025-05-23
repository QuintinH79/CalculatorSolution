using Calculator.Core;
using Calculator.Core.Operations;
using Xunit;

namespace Calculator.Tests
{
    public class CalculatorEngineTests
    {
        private readonly CalculatorEngine _engine;

        public CalculatorEngineTests()
        {
            // Initialize the CalculatorEngine with the OperationFactory
            var operationFactory = new OperationFactory();
            _engine = new CalculatorEngine(operationFactory);
        }

        [Theory]
        [InlineData(3, 2, "+", 5)]
        [InlineData(3, 2, "−", 1)]
        [InlineData(3, 2, "×", 6)]
        [InlineData(3, 2, "÷", 1.5)]
        [InlineData(5.5, 2.5, "+", 8)]
        [InlineData(5.5, 2.5, "−", 3)]
        [InlineData(5.5, 2.5, "×", 13.75)]
        [InlineData(5.5, 2.5, "÷", 2.2)]
        [InlineData(0, 0, "+", 0)]
        [InlineData(0, 5, "−", -5)]
        [InlineData(5, 0, "−", 5)]
        [InlineData(0, 5, "×", 0)]
        [InlineData(5, 0, "×", 0)]
        public void Evaluate_ValidOperations_ReturnsCorrectResult(double left, double right, string op, double expected)
        {
            var result = _engine.Evaluate(left, right, op);
            Assert.Equal(expected, result, 2); // Use a precision of 2 decimal places for comparison
        }

        [Fact]
        public void Evaluate_DivideByZero_ThrowsDivideByZeroException()
        {
            var exception = Assert.Throws<DivideByZeroException>(() => _engine.Evaluate(5, 0, "÷"));
            Assert.Equal("Cannot divide by zero.", exception.Message);
        }

        [Fact]
        public void Evaluate_UnknownOperation_ThrowsInvalidOperationException()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => _engine.Evaluate(5, 2, "%"));
            Assert.Equal("Unknown operation", exception.Message);
        }
    }
}
