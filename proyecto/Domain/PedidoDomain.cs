using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PedidoDomain
    {
        public int idPedido { get; set; }
        public string estado { get; set; }
        public DateTime fechaRegistro { get; set; }

        public ClienteDomain clientePedido { get; set; }
        public int idCliente { get; set; }

        public List<DetallePedidoDomain> DetallePedido { get; set; }
        public class Map
        {
            public Map(EntityTypeBuilder<PedidoDomain> etPedido)
            {
                etPedido.HasKey(x => x.idPedido);
                etPedido.Property(x => x.estado).HasColumnName("Estado").HasMaxLength(50).IsRequired();
                etPedido.Property(x => x.fechaRegistro).HasColumnName("Fecha Registro").IsRequired();
                etPedido.Property(x => x.idCliente).HasColumnName("idCliente").IsRequired();
                etPedido.HasOne(x => x.clientePedido);
            
            }
        }




    }
}
