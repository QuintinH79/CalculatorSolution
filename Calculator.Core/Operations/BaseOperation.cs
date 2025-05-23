namespace Calculator.Core.Operations
{
    public abstract class BaseOperation : IOperation
    {
        public abstract double Apply(double left, double right);
    }
}
