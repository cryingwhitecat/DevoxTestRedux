using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevoxTestRedux.Application.Projects.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateProjectController : BaseAPIController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateProjectCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
