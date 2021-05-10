using Entidad.Entidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Negocio.ProductoNegocio
{
    public class EliminarProducto
    {
        public class DataRequest : IRequest
        {
            public Guid ProductoId { get; set; }

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
                var productoExistente = await dBContext.Producto.Where(p => p.ProductoId == request.ProductoId).FirstOrDefaultAsync();
                if (productoExistente != null)
                {
                    dBContext.Producto.Remove(productoExistente);
                    var result = await dBContext.SaveChangesAsync();
                    if (result>0)
                    {
                        return Unit.Value;
                    }

                    throw new Exception("No se puede eliminar producto, puede ser que este relacionado en una factura");

                }
                throw new Exception("Producto no existe");
            }
        }
    }
}
