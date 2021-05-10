using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entidad.Entidad
{
    public partial class Factura
    {
        public Factura()
        {
            DescripcionFactura = new HashSet<DescripcionFactura>();
        }

        public Guid FacturaId { get; set; }
        public DateTime FacturaFecha { get; set; }
        public long ClienteId { get; set; }
        public decimal FacturaIvaporcentaje { get; set; }
        public decimal FacturaSubtotal { get; set; }
        public decimal FacturaTotal { get; set; }
        public decimal FacturaIvatotal { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<DescripcionFactura> DescripcionFactura { get; set; }
    }
}
