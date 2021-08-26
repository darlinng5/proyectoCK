using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplication.Pedido
{
    class ListarPedidosRegistrados
    {

        public class Query : IRequest<List<PedidoDomain>>
        {
            public int numeroPedido { get; set; }
            public int idCliente { get; set; }
            public DateTime FechaCreacion { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<PedidoDomain>>
        {
            private DataContext _context;
            public Handler(DataContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));

            }

            public async Task<List<PedidoDomain>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Pedido.Where(
                    x => x.estado == "Registrado"&&
                    (x.fechaRegistro==request.FechaCreacion || 
                    x.idCliente==request.idCliente || 
                    x.idPedido==request.numeroPedido))
                    .ToListAsync();

            }

        }
    }
}
