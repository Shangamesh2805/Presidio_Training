using PizzaStoreManagmentAPI.Models.DTO;
using PizzaStoreManagmentAPI.Models;

namespace PizzaStoreManagmentAPI.Interfaces
{
    public interface IUserAuthenticationService
    {
        public Task<LoginReturnDTO> Login(UserLoginDTO loginDTO);
        public Task<User> Register(UserRegisterDTO registerDTO);
}
}
