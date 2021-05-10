using Entidad.Entidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Negocio.Dto.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Negocio.ProductoNegocio
{
    public class EditarProducto
    {
        public class DataRequest : IRequest<ProductoDto>
        {
            public Guid ProductoId { get; set; }
            public string ProductoNombre { get; set; }
            public string ProductoDescripcion { get; set; }
            public int ProductoCantidad { get; set; }
            public decimal ProductoPrecioUnitario { get; set; }
            public Guid? CategoriaId { get; set; }
        }

        public class Handler : IRequestHandler<DataRequest, ProductoDto>
        {
            private readonly SistemaFacturacionDigitalDBContext dBContext;

            public Handler(SistemaFacturacionDigitalDBContext dBContext)
            {
                this.dBContext = dBContext;
            }
            public async Task<ProductoDto> Handle(DataRequest request, CancellationToken cancellationToken)
            {
                var productoExistente = await dBContext.Producto.Where(p => p.ProductoId == request.ProductoId).FirstOrDefaultAsync();
                if (productoExistente != null)
                {
                    productoExistente.ProductoNombre = request.ProductoNombre;
                    productoExistente.ProductoDescripcion = request.ProductoDescripcion;
                    productoExistente.ProductoCantidad = request.ProductoCantidad;
                    productoExistente.ProductoPrecioUnitario = request.ProductoPrecioUnitario;
                    productoExistente.CategoriaId = request.CategoriaId;
                    dBContext.Update(productoExistente);

                    var result = await dBContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        return new ProductoDto()
                        {
                            ProductoId = productoExistente.ProductoId,
                            ProductoNombre = productoExistente.ProductoNombre,
                            ProductoDescripcion = productoExistente.ProductoDescripcion,
                            ProductoCantidad = productoExistente.ProductoCantidad,
                            ProductoPrecioUnitario = productoExistente.ProductoPrecioUnitario,
                            CategoriaId = productoExistente.CategoriaId
                        };                    
                    }
                    throw new Exception("No se pudo editar producto");

                }

                throw new Exception("No existe producto");
            }
        }
    }
}
