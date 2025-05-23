using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Operations
{
    public interface IOperationFactory
    {
        IOperation CreateOperation(string operationType);
    }
}
