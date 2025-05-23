using Calculator.Core.Operations;
namespace Calculator.Core
{
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
}