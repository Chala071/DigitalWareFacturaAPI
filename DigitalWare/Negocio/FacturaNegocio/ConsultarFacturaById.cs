using Entidad.Entidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Negocio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Negocio.FacturaNegocio
{
    public class ConsultarFacturaById
    {
        public class DataRequest: IRequest<FacturaDto>
        {
            public Guid FacturaId { get; set; }
        }

        public class Handler : IRequestHandler<DataRequest, FacturaDto>
        {
            private readonly SistemaFacturacionDigitalDBContext dBContext;

            public Handler(SistemaFacturacionDigitalDBContext dBContext)
            {
                this.dBContext = dBContext;
            }
            public async Task<FacturaDto> Handle(DataRequest request, CancellationToken cancellationToken)
            {
                var productosFacturados = new List<DescripcionFacturadoDto>();

                var facturaExistente = await dBContext.Factura.Where(f => f.FacturaId == request.FacturaId).FirstOrDefaultAsync();

               

                if (facturaExistente != null)
                {
                    var listaDescripcionFactura = await dBContext.DescripcionFactura.Where(d => d.FacturaId == facturaExistente.FacturaId).ToListAsync();
                    foreach (var producto in listaDescripcionFactura)
                    {
                        var productoNombre = await dBContext.Producto.Where(p => p.ProductoId == producto.ProductoId).Select(x => x.ProductoNombre).FirstOrDefaultAsync();
                        productosFacturados.Add(new DescripcionFacturadoDto
                        {
                            ProductoId=producto.ProductoId,
                            ProductoNombre = productoNombre,
                            DescripcionFacturaPrecio = (decimal)producto.DescripcionFacturaPrecio,
                            DescripcionFacturaCantidad = (int)producto.DescripcionFacturaCantidad
                        });
                    }

                    var nombreCliente = await dBContext.Cliente.Where(c => c.ClienteId == facturaExistente.ClienteId).Select(c => c.ClienteNombre).FirstOrDefaultAsync();

                    return new FacturaDto()
                    {
                        FacturaId = facturaExistente.FacturaId,
                        FacturaFecha = facturaExistente.FacturaFecha,
                        ClienteId = facturaExistente.ClienteId,
                        ClienteNombre = nombreCliente,
                        FacturaIvaporcentaje = facturaExistente.FacturaIvaporcentaje,
                        FacturaIvatotal = facturaExistente.FacturaIvatotal,
                        FacturaSubtotal = facturaExistente.FacturaSubtotal,
                        FacturaTotal = facturaExistente.FacturaTotal,
                        ListaDescripcionFactura = productosFacturados
                    };

                }

                throw new Exception("Factura no encontrada");
            }
        }
    }
}
