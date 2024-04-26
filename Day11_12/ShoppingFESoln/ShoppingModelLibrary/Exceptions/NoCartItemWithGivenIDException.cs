using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class NoCartItemWithGivenIDException:Exception
    {
        string message;
        public NoCartItemWithGivenIDException()
        {
            message = "CartItem with the given Id is not present";
        }
        public override string Message => message;
    }
}
    
