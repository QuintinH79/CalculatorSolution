namespace Calculator.Core.Operations
{
    public interface IOperation
    {
        double Apply(double left, double right);
    }
}