using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary.Exceptions
{
    public class NoCustomerWithGivenIDException:Exception
    {
        string message;
        public NoCustomerWithGivenIDException()
        {

            message = "Cart is Empty";

        }
        public override string Message => message;
    }
}
