using System;
using System.ComponentModel.DataAnnotations;

namespace Negocio.Dto
{
    public class DescripcionFacturadoDto
    {
        
        public int DescripcionFacturaCantidad { get; set; }
        public decimal DescripcionFacturaPrecio { get; set; }       
        public Guid? ProductoId { get; set; }
        public string ProductoNombre { get; set; }



    }
}