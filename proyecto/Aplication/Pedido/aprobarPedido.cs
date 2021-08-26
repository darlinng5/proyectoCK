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
   public class aprobarPedido
    {



        public class Command : IRequest
        {
            public int idControlDeAprobacion { get; set; }
            public DateTime fechaAprobacion { get; set; }
            public int idUduario { get; set; }
            public int idPedido { get; set; }


        }


        public class CommandValidator : AbstractValidator<Command>
        {

            public CommandValidator()
            {
                RuleFor(x => x.idUduario).NotEmpty();
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


                var pedidoaModidficar = _context.Pedido.FirstOrDefault(x => x.idPedido == request.idPedido && x.estado == "REGISTRADO");
                if (pedidoaModidficar != null)
                {
                    var controldeAprobacion = new ControldeAprobacionPedido
                    {
                        fechaAprobacion = DateTime.Now,
                        idUduario = request.idUduario,
                        idPedido = request.idPedido
                    };
                    _context.ControlAprobacionPedido.Add(controldeAprobacion);
                    pedidoaModidficar.estado = "Aprobado";
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return Unit.Value;
                    }
                    throw new Exception("Ocurrio un problema al guardar los datos");

                }
                throw new Exception("Ocurrio un problema al guardar los datos");

            }


        }
    }
}
