using Application.Commands.Users;
using Application.Queries.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebUI.Controllers.Api;

namespace WebUI.Controllers
{

    public class UserController : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody] CreateUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetAllUser()
        {
            return Ok(Mediator.Send(new GetAllUsersQuery()));
        }
    }
}
