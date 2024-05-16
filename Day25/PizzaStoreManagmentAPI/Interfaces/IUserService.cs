using PizzaStoreManagmentAPI.Models;
using PizzaStoreManagmentAPI.Models.DTO;

namespace PizzaStoreManagmentAPI.Interfaces
{
    public interface IUserService
    {
        public Task<User> Login(UserLoginDTO loginDTO);
        public Task<User> Register(UserRegisterDTO registerDTO);
    }
}
