using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.BreakingNews.Commands;
using Application.BreakingNews.Queries;
using WebUI.Controllers.Api;

namespace WebUI.Controllers
{
    

    public class NewsController : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody] CreateNewsCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetAllUser()
        {
            return Ok(Mediator.Send(new GetAllNewsQuery()));
        }
    }
}
