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
    public class ClienteDomain
    {
        [Key]
        public int idCliente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }


        public class Map
        {
            public Map(EntityTypeBuilder<ClienteDomain> etCliente)
            {

                etCliente.HasKey(x => x.idCliente);
                etCliente.Property(x => x.nombre).HasColumnName("Nombre").HasMaxLength(50).IsRequired();
                etCliente.Property(x => x.apellido).HasColumnName("Apellido").IsRequired();



            }
        }
    }

}
