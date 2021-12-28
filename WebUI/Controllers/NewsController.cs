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
        public async Task<ActionResult<List<BreakingNewsVm>>> GetAllNews()
        {
            return await Mediator.Send(new GetAllNewsQuery());
        }

        [HttpGet]
        public async Task<ActionResult<BreakingNewsVm>> GetNewsById(string newsId)
        {
            return await Mediator.Send(new GetNewsById {Id = newsId});
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateNews([FromBody] UpdateNewsCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete]
        public async Task<ActionResult<string>> DeleteNews(string newsId)
        {
            return await Mediator.Send(new DeleteNewsCommand {Id = newsId});
        }
    }
}
