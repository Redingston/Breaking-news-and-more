using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Tags.Queries;
using WebUI.Controllers.Api;

namespace WebUI.Controllers
{
    public class TagController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<TagVm>>> GetAllTags()
        {
            return await Mediator.Send(new GetAllTagsQuery());
        }
    }
}
