using Application.Common.Models;
using Application.Users.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebUI.Controllers.Api;

namespace WebUI.Controllers
{

    public class UserController : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<(Result, string)>> CreateDefaultUser([FromBody] CreateUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut]
        public async Task<ActionResult<(Result, string)>> UpdateUser([FromBody] UpdateUserCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
