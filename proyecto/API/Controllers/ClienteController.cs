using Aplication.Clientes;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[Action]")]
    public class ClienteController : ControllerBase
    {
        private IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        }


        [HttpGet]
        public async Task<ActionResult<List<ClienteDomain>>> List()
        {
            return await _mediator.Send(new ListarClientes.Query());
        }
    }
}
