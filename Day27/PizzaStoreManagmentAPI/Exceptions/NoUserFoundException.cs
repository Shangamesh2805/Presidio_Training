namespace PizzaStoreManagmentAPI.Exceptions
{
    public class NoUserFoundException:Exception
    {
        string message;

        public NoUserFoundException()
        {
            message = "User not found";
        }

        public override string Message => message;
    }
}
