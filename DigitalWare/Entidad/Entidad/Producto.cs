using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entidad.Entidad
{
    public partial class Producto
    {
        public Producto()
        {
            DescripcionFactura = new HashSet<DescripcionFactura>();
        }

        public Guid ProductoId { get; set; }
        public string ProductoNombre { get; set; }
        public string ProductoDescripcion { get; set; }
        public int ProductoCantidad { get; set; }
        public decimal ProductoPrecioUnitario { get; set; }
        public Guid? CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<DescripcionFactura> DescripcionFactura { get; set; }
    }
        
}
