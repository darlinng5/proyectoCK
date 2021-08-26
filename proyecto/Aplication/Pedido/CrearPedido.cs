using Domain;
using FluentValidation;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplication.Pedido
{
    public class CrearPedido
    {

        public class Command : IRequest
        {
            public int idPedido { get; set; }
            public string estado { get; set; }
            public DateTime fechaRegistro { get; set; }
            public int idCliente { get; set; }



            public List<DetallePedidoDomain> DetallePedido { get; set; }
        }


        public class CommandValidator : AbstractValidator<Command>
        {

            public CommandValidator()
            {
                RuleFor(x => x.idCliente).NotEmpty();
                RuleFor(x => x.idPedido).NotEmpty();
              
               
            }
        }

      


        public class Handler : IRequestHandler<Command>
        {
            DataContext _context;
            public Handler(DataContext datacontex)
            {
                _context = datacontex ?? throw new ArgumentNullException(nameof(datacontex));
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {

                var pedido = new PedidoDomain
                {
                    idPedido = request.idPedido,
                    fechaRegistro = DateTime.Now,
                    estado = "REGISTRADO",
                    idCliente = request.idCliente

                };
                _context.Pedido.Add(pedido);
                var success = await _context.SaveChangesAsync() > 0;
                if (success)
                {
                    var listaDetalles = request.DetallePedido;                  
                    foreach(var item in listaDetalles)
                    {
                        item.idPedido = 1;//OJO CAMBIAR ESTE ID PARA QUE LO TOME DEL NUEVO QUE ACABA DE CREAR   
                        _context.DetallePedido.Add(item);
                        await _context.SaveChangesAsync();
                    }
                    return Unit.Value;
                }
                throw new Exception("Ocurrio un problema al guardar los datos");

            }
        }

    }
}
