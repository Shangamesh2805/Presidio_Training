using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary.Exceptions
{
    public class CartLimitExceededException:Exception
    {
        string message;
        public CartLimitExceededException()
        {

            message = "Only Five items can be added to the Cart";

        }
        public override string Message => message;
    }
}
