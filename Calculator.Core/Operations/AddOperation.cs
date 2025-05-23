using Calculator.Core.Operations;

public class AddOperation : BaseOperation
{
    public override double Apply(double left, double right) => left + right;
}