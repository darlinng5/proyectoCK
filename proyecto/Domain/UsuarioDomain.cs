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
    public class UsuarioDomain
    {

        [Key]
        public int idUduario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }


        public class Map
        {
            public Map(EntityTypeBuilder<UsuarioDomain> etUsuario)
            {

                etUsuario.HasKey(x => x.idUduario);
                etUsuario.Property(x => x.nombre).HasColumnName("Nombre").HasMaxLength(50).IsRequired();
                etUsuario.Property(x => x.apellido).HasColumnName("Apellido").IsRequired();

            }
        }


    }
}
