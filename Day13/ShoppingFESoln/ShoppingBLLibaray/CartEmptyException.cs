using System.Runtime.Serialization;

namespace ShoppingBLLibrary
{
    [Serializable]
    internal class CartEmptyException : Exception
    {
        public CartEmptyException()
        {
        }

        public CartEmptyException(string? message) : base(message)
        {
        }

        public CartEmptyException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CartEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}