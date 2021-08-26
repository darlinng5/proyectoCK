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

namespace Aplication.Productos
{
    public class ListProducts
    {
            public class Query : IRequest<List<ProductoDomain>>
        {

        }

        public class Handler : IRequestHandler<Query, List<ProductoDomain>>
        {
            private DataContext _context;
            public Handler(DataContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));

            }
            public async Task<List<ProductoDomain>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Producto.ToListAsync();
            }
        }



    }
}
