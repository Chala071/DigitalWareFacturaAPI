using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entidad.Entidad
{
    public partial class DescripcionFactura
    {
        
        public Guid DescripcionFacturaId { get; set; }
        public int? DescripcionFacturaCantidad { get; set; }
        public decimal? DescripcionFacturaPrecio { get; set; }
        public Guid? FacturaId { get; set; }
        public Guid? ProductoId { get; set; }

        public virtual Factura Factura { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
