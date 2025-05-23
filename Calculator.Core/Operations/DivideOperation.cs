using Calculator.Core.Operations;

public class DivideOperation : BaseOperation
{
    public override double Apply(double left, double right)
    {
        if (right == 0)
            throw new DivideByZeroException("Cannot divide by zero.");
        return left / right;
    }
}