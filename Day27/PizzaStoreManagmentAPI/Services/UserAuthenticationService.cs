using PizzaStoreManagmentAPI.Exceptions;
using PizzaStoreManagmentAPI.Interfaces;
using PizzaStoreManagmentAPI.Models.DTO;
using PizzaStoreManagmentAPI.Models;
using System.Security.Cryptography;
using System.Text;
using static PizzaStoreManagmentAPI.Services.UserServices;

namespace PizzaStoreManagmentAPI.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    { 
     private readonly IRepository<int, UserCredential> _userCredentialsRepo;
    private readonly IRepository<int, User> _userRepo;
    private readonly ITokenServices _tokenService;
    public UserAuthenticationService(IRepository<int, User> userRepo, IRepository<int, UserCredential> userCredentialRepo, ITokenServices tokenService)
    {
        _userCredentialsRepo = userCredentialRepo;
        _userRepo = userRepo;
        _tokenService = tokenService;
    }
    public async Task<LoginReturnDTO> Login(UserLoginDTO loginDTO)
    {
        var userDB = await _userCredentialsRepo.Get(loginDTO.UserId);
        if (userDB == null)
        {
            throw new UnauthorizedUserException("Invalid username or password");
        }
        HMACSHA512 hMACSHA = new HMACSHA512(userDB.PasswordHashKey);
        var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
        bool isPasswordSame = ComparePassword(encrypterPass, userDB.Password);
        if (isPasswordSame)
        {
            var user = await _userRepo.Get(loginDTO.UserId);
            LoginReturnDTO loginReturnDTO = MapEmployeeToLoginReturnDTO(user);
            return loginReturnDTO;

        }
        throw new UnauthorizedUserException("Invalid username or password");
    }

    private LoginReturnDTO MapEmployeeToLoginReturnDTO(User user)
    {
        LoginReturnDTO returnDTO = new LoginReturnDTO();
        returnDTO.UserID = user.Id;

        returnDTO.Token = _tokenService.GenerateToken(user);
        return returnDTO;
    }

    private bool ComparePassword(byte[] encrypterPass, byte[] password)
    {
        for (int i = 0; i < encrypterPass.Length; i++)
        {
            if (encrypterPass[i] != password[i])
            {
                return false;
            }
        }
        return true;
    }

    public async Task<User> Register(UserRegisterDTO userDTO)
    {
        User user = null;
        UserCredential userCredential = null;
        try
        {
            user = userDTO;
            userCredential = MapUserToUserCredential(userDTO);
            user = await _userRepo.Add(user);
            userCredential.UserId = user.Id;
            userCredential = await _userCredentialsRepo.Add(userCredential);
            ((UserRegisterDTO)user).Password = string.Empty;
            return user;
        }
        catch (Exception) { }
        if (user != null)
            await RevertEmployeeInsert(user);
        if (userCredential != null && user == null)
            await RevertUserInsert(userCredential);
        throw new UnableToRegisterException("Not able to register at this moment");
    }

    private async Task RevertUserInsert(UserCredential userCredential)
    {
        await _userCredentialsRepo.Delete(userCredential.UserId);
    }

    private async Task RevertEmployeeInsert(User user)
    {
        await _userRepo.Delete(user.Id);
    }

    private UserCredential MapUserToUserCredential(UserRegisterDTO userDTO)
    {
        UserCredential userCredential = new UserCredential();
        userCredential.UserId = userDTO.Id;
        userCredential.Status = "Disabled";
        HMACSHA512 hMACSHA = new HMACSHA512();
        userCredential.PasswordHashKey = hMACSHA.Key;
        userCredential.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
        return userCredential;
    }

}
}
