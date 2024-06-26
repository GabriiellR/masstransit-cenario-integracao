using Intranet.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Intranet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CentroCustoController : ControllerBase
    {
        readonly IApplicationServiceCentroCusto _applicationServiceCentroCusto;
        public CentroCustoController(IApplicationServiceCentroCusto applicationServiceCentroCusto)
        {
            _applicationServiceCentroCusto = applicationServiceCentroCusto;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var centroCustoList = _applicationServiceCentroCusto.GetAll();
            return Ok(centroCustoList);
        }

    }
}