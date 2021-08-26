using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {


        }

        public virtual DbSet<ClienteDomain> Cliente { get; set; }
        public virtual DbSet<PedidoDomain> Pedido { get; set; }
        public virtual DbSet<ProductoDomain> Producto { get; set; }
        public virtual DbSet<DetallePedidoDomain> DetallePedido { get; set; }
        public virtual DbSet<ControldeAprobacionPedido> ControlAprobacionPedido { get; set; }
        public virtual DbSet<UsuarioDomain> Usuario { get; set; }
        protected override void OnModelCreating(ModelBuilder modelB)
        {
            new ClienteDomain.Map(modelB.Entity<ClienteDomain>());
            new PedidoDomain.Map(modelB.Entity<PedidoDomain>());
            new ProductoDomain.Map(modelB.Entity<ProductoDomain>());
            new DetallePedidoDomain.Map(modelB.Entity<DetallePedidoDomain>());
            new ControldeAprobacionPedido.Map(modelB.Entity<ControldeAprobacionPedido>());
            new UsuarioDomain.Map(modelB.Entity<UsuarioDomain>());

            foreach (var relationship in modelB.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelB);

        }

    }
}
