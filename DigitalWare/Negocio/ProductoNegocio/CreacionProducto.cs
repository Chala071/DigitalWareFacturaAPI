using Entidad.Entidad;
using MediatR;
using Negocio.Dto.Producto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Negocio.ProductoNegocio
{
    public class CreacionProducto
    {
        public class DataRequest : IRequest<ProductoDto>
        {
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


                var nuevoProducto = new Producto()
                {
                    ProductoId = new Guid(),
                    ProductoNombre = request.ProductoNombre,
                    ProductoDescripcion = request.ProductoDescripcion,
                    ProductoCantidad = request.ProductoCantidad,
                    ProductoPrecioUnitario = request.ProductoPrecioUnitario,
                    CategoriaId = request.CategoriaId
                };

                

                await dBContext.Producto.AddAsync(nuevoProducto);
                var result= await dBContext.SaveChangesAsync();

                if (result > 0)
                {
                    return new ProductoDto() {

                        ProductoId=nuevoProducto.ProductoId,
                        ProductoNombre = nuevoProducto.ProductoNombre,
                        ProductoDescripcion = nuevoProducto.ProductoDescripcion,
                        ProductoCantidad = nuevoProducto.ProductoCantidad,
                        ProductoPrecioUnitario = nuevoProducto.ProductoPrecioUnitario,
                        CategoriaId = nuevoProducto.CategoriaId
                    };
                }
                throw new Exception("No se pudo crear el producto");
            }
        }
    }
}
