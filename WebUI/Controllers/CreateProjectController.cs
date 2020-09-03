using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevoxTestRedux.Application.Projects.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using WebUI.Filters;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateProjectController : BaseAPIController
    {
        [HttpPut]
        public async Task<ActionResult<int>> Post(CreateProjectCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
