using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary.Exceptions
{

    public class CartEmptyException : Exception
    {
        string message;
        public CartEmptyException() {

            message = "Cart is Empty";

        }
        public override string Message => message;
    }
}
