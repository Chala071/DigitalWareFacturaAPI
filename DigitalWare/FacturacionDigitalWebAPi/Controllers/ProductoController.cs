using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Dto.Producto;
using Negocio.ProductoNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionDigitalWebAPi.Controllers
{
   
    public class ProductoController : MiBaseController
    {
        //https://localhost:44360/api/Producto/Crear
        [HttpPost("Crear")]
        public async Task<ActionResult<ProductoDto>> CrearProducto(CreacionProducto.DataRequest data)
        {
            return await Mediator.Send(data);
        }

        //https://localhost:44360/api/Producto/Editar
        [HttpPut("Editar")]
        public async Task<ActionResult<ProductoDto>> EditarProducto(EditarProducto.DataRequest data)
        {
            return await Mediator.Send(data);
        }

        //https://localhost:44360/api/Producto/Eliminar
        [HttpDelete("Eliminar")]
        public async Task<ActionResult<Unit>> ElimnarProducto(EliminarProducto.DataRequest data)
        {
            return await Mediator.Send(data);
        }

        //https://localhost:44360/api/Producto
        [HttpGet]
        public async Task<ActionResult<List<ProductoDto>>> ObtenerListaProducto()
        {
            return await Mediator.Send(new ConsultarProducto.DataRequest());
        }





    }
}
