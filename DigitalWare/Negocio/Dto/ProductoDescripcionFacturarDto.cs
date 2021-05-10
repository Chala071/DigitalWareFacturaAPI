using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto
{
    public class ProductoDescripcionFacturarDto
    {
        public Guid ProductoId { get; set; }
        public int CantidadFacturar { get; set; }
    }
}
