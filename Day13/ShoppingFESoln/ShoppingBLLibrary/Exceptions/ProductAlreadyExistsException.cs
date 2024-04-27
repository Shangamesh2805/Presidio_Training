using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary.Exceptions
{
    public class ProductAlreadyExistsException:Exception
    {
        string message;
        public ProductAlreadyExistsException()
        {
            message = "Product Already Exists";
        }
        public override string Message => message; 
    }
}
