using Aplication.Pedido;
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
    public class PedidoController : Controller
    {

        private IMediator _mediator;

        public PedidoController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        }


        [HttpGet]
        
        public async Task<ActionResult<List<PedidoDomain>>> ListarTodosPedidos()
        {
            return await _mediator.Send(new ListarPedido.Query());
        }




        [HttpPost]
        public async Task<Unit> CrearPedido(CrearPedido.Command command)
        {
           

            //string idCliente = response.idCliente;

            //var comando = new CrearPedido.Command
            //{
            //    idPedido = response.idPedido,
            //    estado = response.estado


            //};

           

            return await _mediator.Send(command);
        }


        [HttpPost]
        public async Task<Unit> AprobarUnPedido([FromBody] aprobarPedido.Command command)
        {

            return await _mediator.Send(command);
        }



      
    }
}
