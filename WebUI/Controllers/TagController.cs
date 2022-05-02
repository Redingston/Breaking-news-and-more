using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreakingNewsCore.DTO.TagsDTO;
using BreakingNewsCore.Tags.Queries;
using WebUI.Controllers.Api;

namespace WebUI.Controllers
{
    public class TagController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<TagDTO>>> GetAllTags()
        {
            return await Mediator.Send(new GetAllTagsQuery());
        }
    }
}
