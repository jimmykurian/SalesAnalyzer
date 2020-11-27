using Application.StateRegions.Commands;
using Application.StateRegions.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateRegionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StateRegionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<StateRegion>>> List()
        {
            return await _mediator.Send(new List.Query());
        }

        [HttpGet]
        [Route("getByMatrix")]
        public async Task<ActionResult<List<StateMonthMatrix>>> ListByMatrix()
        {
            return await _mediator.Send(new ListByMatrix.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StateRegion>> Details(Guid id)
        {
            return await _mediator.Send(new Details.Query { Id = id });
        }


        [HttpPost]
        public async Task<ActionResult<Unit>> Create(StateRegionsRequest stateRegionsRequest)
        {
            return await _mediator.Send(new Create.Command { StateRegions = stateRegionsRequest.stateRegions });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(Guid id, Edit.Command command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await _mediator.Send(new Delete.Command { Id = id });
        }
    }
}
