using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseViews.DataAccessLayer.Context;
using DatabaseViews.DataAccessLayer.Model;
using DatabaseViews.DataAccessLayer.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseViews.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HostController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Host>>> Get([FromRoute] string loginName)
        {
            var result = await _mediator.Send(new FindHostsByLoginNameQuery {LoginName = loginName});

            return Ok(result);
        }
    }
}