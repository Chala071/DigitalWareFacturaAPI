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
    public class EditarFactura
    {
        public class DataRequest: IRequest<FacturaDto>
        {
            public Guid FacturaId { get; set; }
            public List<ProductoDescripcionFacturarDto> ListaProductoFacturado { get; set; }
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
                decimal subtotal = 0;
                var listProductosModificados = new List<Producto>();
                var listaDescripcionProductoFacturadoDto = new List<DescripcionFacturadoDto>();
                var facturaExistente = await dBContext.Factura.Where(f => f.FacturaId == request.FacturaId).FirstOrDefaultAsync();
                if (facturaExistente != null)
                {
                    
                    var listaProductoFacturadoDB = await dBContext.DescripcionFactura.Where(d => d.FacturaId == facturaExistente.FacturaId).ToListAsync();
                    
                    //Evaluamos si el cliente envia la misma cantidad de productos
                    if (request.ListaProductoFacturado.Count == listaProductoFacturadoDB.Count)
                    {
                        
                        foreach(var productoFacturadDB in listaProductoFacturadoDB)
                        {
                            var productoExistente = await dBContext.Producto.Where(p => p.ProductoId == productoFacturadDB.ProductoId).FirstOrDefaultAsync();

                            foreach (var productoFacturadoCliente in request.ListaProductoFacturado)
                            {
                                if (productoFacturadoCliente.ProductoId == productoFacturadDB.ProductoId)
                                {
                                    var CantidadAumentaDisminuye = productoFacturadDB.DescripcionFacturaCantidad - productoFacturadoCliente.CantidadFacturar;
                                    productoFacturadDB.DescripcionFacturaCantidad = productoFacturadoCliente.CantidadFacturar;
                                    productoExistente.ProductoCantidad = (int)(productoExistente.ProductoCantidad + CantidadAumentaDisminuye);
                                }
                            }

                            productoFacturadDB.DescripcionFacturaPrecio = productoFacturadDB.DescripcionFacturaCantidad * productoExistente.ProductoPrecioUnitario;
                            subtotal = (decimal)(subtotal + productoFacturadDB.DescripcionFacturaPrecio);

                            listProductosModificados.Add(productoExistente);
                            listaDescripcionProductoFacturadoDto.Add(new DescripcionFacturadoDto()
                            {
                                ProductoId = productoFacturadDB.ProductoId,
                                ProductoNombre = productoExistente.ProductoNombre,
                                DescripcionFacturaPrecio = (decimal)productoFacturadDB.DescripcionFacturaPrecio,
                                DescripcionFacturaCantidad = (int)productoFacturadDB.DescripcionFacturaCantidad
                            });

                        }

                        facturaExistente.FacturaSubtotal = subtotal;
                        facturaExistente.FacturaIvatotal = subtotal * facturaExistente.FacturaIvaporcentaje;
                        facturaExistente.FacturaTotal = facturaExistente.FacturaSubtotal + facturaExistente.FacturaIvatotal;

                        var cliente = await dBContext.Cliente.Where(c => c.ClienteId == facturaExistente.ClienteId).FirstOrDefaultAsync();

                        //GUardamos la actualizacion
                        dBContext.Factura.Update(facturaExistente);
                        dBContext.Producto.UpdateRange(listProductosModificados);
                        dBContext.DescripcionFactura.UpdateRange(listaProductoFacturadoDB);
                        int result = await dBContext.SaveChangesAsync();

                        if (result > 0)
                        {
                            return new FacturaDto()
                            {
                                FacturaId = facturaExistente.FacturaId,
                                FacturaFecha = facturaExistente.FacturaFecha,
                                ClienteId = facturaExistente.ClienteId,
                                ClienteNombre = cliente.ClienteNombre,
                                FacturaSubtotal = facturaExistente.FacturaSubtotal,
                                FacturaIvaporcentaje = facturaExistente.FacturaIvaporcentaje,
                                FacturaIvatotal = facturaExistente.FacturaIvatotal,
                                FacturaTotal = facturaExistente.FacturaTotal,
                                ListaDescripcionFactura = listaDescripcionProductoFacturadoDto
                            };
                        }


                    }
                    else
                    {
                        throw new Exception("Los productos no corresponden a la factura consultada");
                    }
                }

                throw new Exception("Factura no encontrada");
            }
        }

    }
}
