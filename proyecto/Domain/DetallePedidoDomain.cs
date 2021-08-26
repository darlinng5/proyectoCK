using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DetallePedidoDomain
    {
        [Key]
        public int idDetalle { get; set; }
        public ProductoDomain Producto { get; set; }
        public int idProducto { get; set; }
        public uint cantidad { get; set; }

        public PedidoDomain Pedido { get; set; }

        public int idPedido { get; set; }





        public class Map
        {
            public Map(EntityTypeBuilder<DetallePedidoDomain> etDetalle)
            {
                etDetalle.HasKey(x => x.idDetalle);
                etDetalle.Property(x => x.cantidad).HasColumnName("Cantidad").IsRequired();
                etDetalle.HasOne(x => x.Producto);
                etDetalle.Property(x => x.idProducto).HasColumnName("idProducto").IsRequired(); 
                etDetalle.HasOne(x => x.Pedido);
                etDetalle.Property(x => x.idPedido).HasColumnName("idPedido").IsRequired();
              //  etDetalle.HasOne(x => x.Pedido).WithMany(e => e.DetallePedido).HasForeignKey(e => e.idPedido).OnDelete(DeleteBehavior.Cascade);

            }
        }




    }
}
