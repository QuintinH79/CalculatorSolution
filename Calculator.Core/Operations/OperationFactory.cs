using System;
using System.Collections.Generic;
namespace Calculator.Core.Operations
{
    public class OperationFactory : IOperationFactory
    {
        private readonly Dictionary<string, Type> _operations = new Dictionary<string, Type>
        {
            { "+", typeof(AddOperation) },
            { "−", typeof(SubtractOperation) },
            { "×", typeof(MultiplyOperation) },
            { "÷", typeof(DivideOperation) }
        };
        public IOperation CreateOperation(string operationType)
        {
            if (!_operations.TryGetValue(operationType, out var operationTypeValue))
                throw new InvalidOperationException("Unknown operation");
            // Create the instance and check for null
            var operation = Activator.CreateInstance(operationTypeValue) as IOperation;
            if (operation == null)
                throw new InvalidOperationException("Failed to create operation instance.");
            return operation;
        }
    }
}