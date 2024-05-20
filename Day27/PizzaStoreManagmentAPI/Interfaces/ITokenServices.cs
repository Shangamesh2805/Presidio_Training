using PizzaStoreManagmentAPI.Models;

namespace PizzaStoreManagmentAPI.Interfaces
{
    public interface ITokenServices
    {
        public string GenerateToken(User user);
    }
}
