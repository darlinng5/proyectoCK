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
    public class ControldeAprobacionPedido
    {
        [Key]
        public int idControlDeAprobacion { get; set; }
        public DateTime fechaAprobacion { get; set; }
        public int idUduario { get; set; }
        public int idPedido { get; set; }
        public UsuarioDomain Usuario { get; set; }

        public PedidoDomain Pedido { get; set; }
        public class Map
        {
            public Map(EntityTypeBuilder<ControldeAprobacionPedido> etControl)
            {
                etControl.HasKey(x => x.idControlDeAprobacion);
                etControl.Property(x => x.fechaAprobacion).HasColumnName("Nombre").HasMaxLength(50).IsRequired();
                etControl.Property(x => x.idUduario).HasColumnName("IdUsuario").IsRequired();
                etControl.Property(x => x.idUduario).HasColumnName("idPedido").IsRequired();
                etControl.HasOne(x=>x.Pedido);
                etControl.HasOne(x => x.Usuario);
            }
        }
    }
}
