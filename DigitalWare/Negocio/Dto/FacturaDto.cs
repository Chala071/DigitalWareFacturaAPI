using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Negocio.Dto
{
    public class FacturaDto
    {
        
        public Guid FacturaId { get; set; }
        
        public DateTime FacturaFecha { get; set; }
        
        public long ClienteId { get; set; }

        public string ClienteNombre { get; set; }

        public decimal FacturaIvaporcentaje { get; set; }
        
        public decimal FacturaSubtotal { get; set; }
        
        public decimal FacturaTotal { get; set; }
        
        public decimal FacturaIvatotal { get; set; }
        
        public ICollection<DescripcionFacturadoDto> ListaDescripcionFactura { get; set; }
    }
}
