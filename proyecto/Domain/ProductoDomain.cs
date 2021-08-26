using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ProductoDomain
    {

        public int idProducto { get; set; }
        public string nombre { get; set; }
        public ulong precio { get; set; }


        public class Map
        {
            public Map(EntityTypeBuilder<ProductoDomain> etProducto)
            {

                etProducto.HasKey(x => x.idProducto);
                etProducto.Property(x => x.nombre).HasColumnName("Nombre").HasMaxLength(50).IsRequired();
                etProducto.Property(x => x.precio).HasColumnName("Precio").IsRequired();



            }
        }
    }
}
