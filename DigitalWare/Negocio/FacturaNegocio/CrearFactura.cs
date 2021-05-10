using Entidad.Entidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Negocio.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Negocio.FacturaNegocio
{
    public class CrearFactura
    {
        public class DataRequest : IRequest<FacturaDto>
        {
           
                        
            public DateTime FacturaFecha { get; set; }
            public long ClienteId { get; set; }
            public decimal FacturaIvaporcentaje { get; set; }
            public List<ProductoDescripcionFacturarDto> ProductosFacturar { get; set; }

        }

        public class Hanlder : IRequestHandler<DataRequest, FacturaDto>
        {
            private readonly SistemaFacturacionDigitalDBContext dBContext;

            public Hanlder(SistemaFacturacionDigitalDBContext dBContext)
            {
                this.dBContext = dBContext;
            }
            public async Task<FacturaDto> Handle(DataRequest request, CancellationToken cancellationToken)
            {
                //Declaracion de variables
                decimal _subtotal = 0;
                var listaDescripcionProductoFacturadoDto = new List<DescripcionFacturadoDto>();
                var listaDescripcionProductoFacturado = new List<DescripcionFactura>();



                //Evaluamos las cantidades existentes de cada producto y si existe
                foreach (var producto in request.ProductosFacturar)
                {

                    var productoExistente =await dBContext.Producto.Where(x => x.ProductoId == producto.ProductoId).FirstOrDefaultAsync();
                        if (productoExistente == null)
                        {
                            throw new Exception("Producto No existe");
                        }

                        var productoCantidadRestante = productoExistente.ProductoCantidad - producto.CantidadFacturar;
                        if (productoCantidadRestante < 5)
                        {
                            throw new Exception("El stock mínimo es de 5");
                        }


                        //Calculo de subtotal de los productos
                        _subtotal = (_subtotal + (producto.CantidadFacturar * productoExistente.ProductoPrecioUnitario));                 
                     
                    
                    
                }


                //Creamos factura para guardarla en la base de datos
                var facturaNueva = new Factura()
                {
                    FacturaId = new Guid(),
                    FacturaFecha = request.FacturaFecha,
                    ClienteId = request.ClienteId,
                    FacturaIvaporcentaje = request.FacturaIvaporcentaje,
                    FacturaSubtotal = _subtotal,
                    FacturaIvatotal = _subtotal*(request.FacturaIvaporcentaje/100),
                    FacturaTotal =  _subtotal + (_subtotal * (request.FacturaIvaporcentaje / 100))                  
                };
                
                //Guardamos la factura
                await dBContext.Factura.AddAsync(facturaNueva);                
                var result = await dBContext.SaveChangesAsync();
                //////////////////////////////////////////////////////

                if (result >0)
                {
                    var cliente = await dBContext.Cliente.Where(x => x.ClienteId == facturaNueva.ClienteId).FirstOrDefaultAsync();

                    //Actualizamos la cantidad del producto facturado y registramos a descripcion de la facturacion
                    foreach (var producto in request.ProductosFacturar)
                    {
                        
                        var productoExistente = await dBContext.Producto.Where(x => x.ProductoId == producto.ProductoId).FirstOrDefaultAsync();
                        var productoCantidadRestante = productoExistente.ProductoCantidad - producto.CantidadFacturar;
                        productoExistente.ProductoCantidad = productoCantidadRestante;

                        var _DescripcionFacturaProducto = new DescripcionFactura()
                        {
                            DescripcionFacturaId = new Guid(),
                            DescripcionFacturaCantidad = producto.CantidadFacturar,
                            DescripcionFacturaPrecio = producto.CantidadFacturar * productoExistente.ProductoPrecioUnitario,
                            FacturaId = facturaNueva.FacturaId,
                            ProductoId = producto.ProductoId,
                        };
                        listaDescripcionProductoFacturado.Add(_DescripcionFacturaProducto);

                        listaDescripcionProductoFacturadoDto.Add(new DescripcionFacturadoDto()
                        {
                            DescripcionFacturaCantidad= (int)_DescripcionFacturaProducto.DescripcionFacturaCantidad,
                            DescripcionFacturaPrecio= (decimal)_DescripcionFacturaProducto.DescripcionFacturaPrecio,
                            ProductoId=productoExistente.ProductoId,
                            ProductoNombre=productoExistente.ProductoNombre
                        });

                        await dBContext.DescripcionFactura.AddAsync(_DescripcionFacturaProducto);
                        dBContext.Update(productoExistente);
                        var resultActualizarProducto = await dBContext.SaveChangesAsync();
                       

                        if (resultActualizarProducto <= 0) {
                            throw new Exception("No se pudó actualizar la cantidad del producto o la descripcion de la factura");
                        }
                    }

                        return new FacturaDto()
                    {
                        FacturaId = facturaNueva.FacturaId,
                        FacturaFecha = facturaNueva.FacturaFecha,
                        ClienteId = facturaNueva.ClienteId,
                        ClienteNombre = cliente.ClienteNombre,
                        FacturaSubtotal = facturaNueva.FacturaSubtotal,
                        FacturaIvaporcentaje=facturaNueva.FacturaIvaporcentaje,
                        FacturaIvatotal = facturaNueva.FacturaIvatotal,
                        FacturaTotal = facturaNueva.FacturaTotal,
                        ListaDescripcionFactura = listaDescripcionProductoFacturadoDto
                        };
                }
                
               
                throw new Exception("No se pudó registrar la factura");
            }
        }
    }
}
