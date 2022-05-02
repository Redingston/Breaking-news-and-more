using System.Threading.Tasks;
using BreakingNewsCore.DTO.UsersDTO;
using BreakingNewsCore.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginDTO logDTO)
        {
            var tokens = await authenticationService.LoginAsync(logDTO.Email, logDTO.Password);

            return Ok(tokens);
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] UserAutorizationDTO userTokensDTO)
        {
            var tokens = await authenticationService.RefreshTokenAsync(userTokensDTO);

            return Ok(tokens);
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> LogoutAsync([FromBody] UserAutorizationDTO userTokensDTO)
        {
            await authenticationService.LogoutAsync(userTokensDTO);

            return NoContent();
        }
    }
}
