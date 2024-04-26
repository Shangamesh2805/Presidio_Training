using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary.Exceptions
{
    public class ProductNotFoundException:Exception
    {
        string message;
        public ProductNotFoundException() 
        {
            message = "Product with given ID not found ";
        }
        public override string Message => message;

    }
}
