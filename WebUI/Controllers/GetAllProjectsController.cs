using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevoxTestRedux.Application.Projects.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllProjectsController : BaseAPIController
    {
        [HttpGet]
        public async Task<ProjectsModel> Get()
        {
            return await Mediator.Send(new GetAllProjectsQuery());
        }
    }
}
