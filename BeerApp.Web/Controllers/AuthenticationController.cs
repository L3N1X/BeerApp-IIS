using BeerApp.Dao.Services.Interface;
using BeerApp.Web.Authentication.Services.Interfaces;
using BeerApp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        public AuthenticationController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService)); 
        }
        [HttpPost("login")]
        public ActionResult<string> Login(LoginRequest request)
        {
            try
            {
                var user = _userService.TryLogin(request.Username!, request.Password!);
                var accessToken = _tokenService.GenerateAccessToken(user);
                return Ok(accessToken);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
