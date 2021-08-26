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

namespace Aplication.Clientes
{
    public class ListarClientes
    {
        public class Query : IRequest<List<ClienteDomain>>
        {

        }

        public class Handler : IRequestHandler<Query, List<ClienteDomain>>
        {
            private DataContext _context;
            public Handler(DataContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));

            }
            public async Task<List<ClienteDomain>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Cliente.ToListAsync();
            }
        }



    }

}
