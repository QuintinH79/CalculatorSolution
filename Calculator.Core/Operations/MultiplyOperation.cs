using Calculator.Core.Operations;

public class MultiplyOperation : BaseOperation
{
    public override double Apply(double left, double right) => left * right;
}