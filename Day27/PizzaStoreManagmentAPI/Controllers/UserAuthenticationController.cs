using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaStoreManagmentAPI.Models.DTO;
using PizzaStoreManagmentAPI.Models;
using static PizzaStoreManagmentAPI.Services.UserServices;
using PizzaStoreManagmentAPI.Services;

namespace PizzaStoreManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthenticationController : ControllerBase
    {

        private readonly UserAuthenticationService _userAuthService;
        public UserAuthenticationController(UserAuthenticationService userAuthService)
        {
            _userAuthService = userAuthService;
        }
        [HttpPost("Login")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<User>> Login(UserLoginDTO userLoginDTO)
        {
            try
            {
                var result = await _userAuthService.Login(userLoginDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(new Error(401, ex.Message));
            }
        }
        [HttpPost("Register")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> Register(UserRegisterDTO userRegisterDTO)
        {
            try
            {
                User result = await _userAuthService.Register(userRegisterDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(500, ex.Message));
            }
        }




    }
}
   