using System.Runtime.Serialization;

namespace PizzaStoreManagmentAPI.Exceptions
{
    [Serializable]
    internal class UnauthorizedUserException : Exception
    {
        string message;
        public UnauthorizedUserException(string data)
        {

            message = data;
        }
        public override string Message => message;


    }
}