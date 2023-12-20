using Microsoft.AspNetCore.Mvc;
using ShelfLayoutManager.Api.Models;
using ShelfLayoutManager.Core.Services;

namespace ShelfLayoutManager.Api.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly NLog.ILogger _logger;

        public AuthController(IAuthService authService, NLog.ILogger logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserLoginModel model)
        {
            if (await _authService.RegisterUser(model.UserName, model.Password))
            {
                _logger.Info("User successfully registered.");
                return Ok("Done");
            }

            _logger.Error("Authentication Failed.");
            return BadRequest("Something went wrong.");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel model)
        {
            if (await _authService.Login(model.UserName, model.Password))
            {
                var token = await _authService.GenerateTokenString(model.UserName);
                _logger.Info($"User: {model.UserName} successfully authenticated.");
                return Ok(token);
            }

            _logger.Error("Authentication Failed.");
            return BadRequest();
        }
    }
}
