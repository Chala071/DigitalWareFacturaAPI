using Entidad.Entidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Negocio.FacturaNegocio
{
    public class EliminarFactura
    {
        public class DataRequest : IRequest
        {
            public Guid FacturaId { get; set; }
        }

        public class Handler : IRequestHandler<DataRequest>
        {
            private readonly SistemaFacturacionDigitalDBContext dBContext;

            public Handler(SistemaFacturacionDigitalDBContext dBContext)
            {
                this.dBContext = dBContext;
            }
            public async Task<Unit> Handle(DataRequest request, CancellationToken cancellationToken)
            {
                var facturaExistente = await dBContext.Factura.Where(f => f.FacturaId == request.FacturaId).FirstOrDefaultAsync();
                if (facturaExistente != null)
                {
                    //Eliminamos los productos facturados
                    var listaProductosFacturados = await dBContext.DescripcionFactura.Where(d => d.FacturaId == facturaExistente.FacturaId).ToListAsync();
                    dBContext.RemoveRange(listaProductosFacturados);
                    //Eliminamos la factura
                    dBContext.Remove(facturaExistente);
                    var result = await dBContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        return Unit.Value;
                    }

                    throw new Exception("No se pudo Eliminar la factura");
                }
                throw new Exception("Factura no encontrada");
               

               
            }
        }
    }
}
