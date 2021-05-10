using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace FacturacionDigitalWebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiBaseController : ControllerBase
    {
        private IMediator _imediator;
        protected IMediator Mediator => _imediator ?? (_imediator = HttpContext.RequestServices.GetService<IMediator>());
    }
}
