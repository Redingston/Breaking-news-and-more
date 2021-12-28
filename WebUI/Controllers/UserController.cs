//using System.Collections.Generic;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;
//using Application.Users.Commands;
//using Application.Users.Queries;
////using Application.Users.Commands;
////using Application.Users.Queries;
//using WebUI.Controllers.Api;

//namespace WebUI.Controllers
//{

//    public class UserController : BaseApiController
//    {
//        [HttpPost]
//        public async Task<ActionResult<string>> Create([FromBody] CreateUserCommand command)
//        {
//            return await Mediator.Send(command);
//        }

//        [HttpGet]
//        public async Task<ActionResult<List<UserVm>>> GetAllUser()
//        {
//            return await Mediator.Send(new GetAllUsersQuery());
//        }
//    }
//}
