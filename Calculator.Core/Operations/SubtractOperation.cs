using Calculator.Core.Operations;

public class SubtractOperation : BaseOperation
{
    public override double Apply(double left, double right) => left - right;
}