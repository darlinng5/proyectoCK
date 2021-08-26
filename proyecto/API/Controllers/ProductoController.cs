using Aplication.Productos;
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
    public class ProductoController : ControllerBase
    {
        private IMediator _mediator;

        public ProductoController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        }
        

        [HttpGet]
        public async Task<ActionResult<List<ProductoDomain>>> List()
        {
            return await _mediator.Send(new ListProducts.Query());
        }
    }
}
