using System.Runtime.Serialization;

namespace ShoppingBLLibrary
{
    [Serializable]
    internal class CartLimitExceededException : Exception
    {
        public CartLimitExceededException()
        {
        }

        public CartLimitExceededException(string? message) : base(message)
        {
        }

        public CartLimitExceededException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CartLimitExceededException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}