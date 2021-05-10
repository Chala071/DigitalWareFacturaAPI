using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Dto;
using Negocio.FacturaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionDigitalWebAPi.Controllers
{
   
    public class FacturaController : MiBaseController
    {
        //https://localhost:44360/api/Factura/Consultar
        [HttpGet("Consultar")]
        public async Task<ActionResult<FacturaDto>> ConsultarFactura(ConsultarFacturaById.DataRequest data)
        {
            return await Mediator.Send(data);
        }

        //https://localhost:44360/api/Factura/Crear
        [HttpPost("Crear")]
        public async Task<ActionResult<FacturaDto>> RegistrarFactura(CrearFactura.DataRequest data)
        {
            return await Mediator.Send(data);
        }

        //https://localhost:44360/api/Factura/Borrar
        [HttpDelete("Borrar")]
        public async Task<ActionResult<Unit>> BorrarFactura(EliminarFactura.DataRequest data)
        {
            return await Mediator.Send(data);
        }

        //https://localhost:44360/api/Factura/Editar
        [HttpPut("Editar")]
        public async Task<ActionResult<FacturaDto>> EditarFactura(EditarFactura.DataRequest data)
        {
            return await Mediator.Send(data);
        }


    }
}
