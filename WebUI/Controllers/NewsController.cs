using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<ActionResult<List<BreakingNewsDTO>>> GetAllNews()
        {
            return await Mediator.Send(new GetAllNewsQuery());
        }

        [HttpGet]
        public async Task<ActionResult<BreakingNewsFullInfoDTO>> GetNewsById(string newsId)
        {
            return await Mediator.Send(new GetNewsByIdQuery {Id = newsId});
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateNews([FromBody] UpdateNewsCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteNews(string newsId)
        {
            await Mediator.Send(new DeleteNewsCommand { Id = newsId });
            return NoContent();
        }
    }
}
