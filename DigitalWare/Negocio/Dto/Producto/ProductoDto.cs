using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto.Producto
{
    public class ProductoDto
    {
        public Guid ProductoId { get; set; }
        public string ProductoNombre { get; set; }
        public string ProductoDescripcion { get; set; }
        public int ProductoCantidad { get; set; }
        public decimal ProductoPrecioUnitario { get; set; }
        public Guid? CategoriaId { get; set; }
    }
}
