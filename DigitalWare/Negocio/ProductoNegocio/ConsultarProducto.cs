using Entidad.Entidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Negocio.Dto.Producto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Negocio.ProductoNegocio
{
    public class ConsultarProducto
    {
        public class DataRequest : IRequest<List<ProductoDto>>
        {

        }

        public class Handler : IRequestHandler<DataRequest, List<ProductoDto>>
        {
            private readonly SistemaFacturacionDigitalDBContext dBContext;

            public Handler(SistemaFacturacionDigitalDBContext dBContext)
            {
                this.dBContext = dBContext;
            }
            public async Task<List<ProductoDto>> Handle(DataRequest request, CancellationToken cancellationToken)
            {
                var listaProductosDto = new List<ProductoDto>();
                var listaProductos = await dBContext.Producto.ToListAsync();

                if (listaProductos != null)
                {
                    foreach (var producto in listaProductos)
                    {
                        listaProductosDto.Add(new ProductoDto()
                        {
                            ProductoId = producto.ProductoId,
                            ProductoNombre = producto.ProductoNombre,
                            ProductoDescripcion = producto.ProductoDescripcion,
                            ProductoCantidad = producto.ProductoCantidad,
                            ProductoPrecioUnitario = producto.ProductoPrecioUnitario,
                            CategoriaId = producto.CategoriaId
                        });

                    }
                    return listaProductosDto;
                }
                throw new Exception("No se pudó obtener la lista de productos");
            }
        }
    }
}
