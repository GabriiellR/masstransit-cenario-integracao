using BennerApi.Application.Interfaces;
using BennerApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BennerApi.Controllers
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
            var centrosCusto = _applicationServiceCentroCusto.GetAll();

            return Ok(centrosCusto);
        }

        [HttpPost]
        public ActionResult Post(CentroCusto centroCusto)
        {

            if (centroCusto is null)
                return BadRequest("Preencha corretamente as informações de centro de custo");

            var centroCustoCadastrado = _applicationServiceCentroCusto.Post(centroCusto);

            return Ok(centroCustoCadastrado.Result);
        }

        [HttpPut]
        public ActionResult Update(CentroCusto centroCusto)
        {
            if (centroCusto is null)
                return BadRequest("Preencha corretamente as informações de centro de custo");

            var centroCustoAtualizado = _applicationServiceCentroCusto.Update(centroCusto);
            return Ok(centroCustoAtualizado.Result);   
        }

        [HttpDelete("estrutura")]
        public ActionResult Delete(string estrutura)
        {
            if (string.IsNullOrEmpty(estrutura))
                return BadRequest("Informe a estrutura do centro de custo a ser deletado.");

            var centroCustoDeletado = _applicationServiceCentroCusto.Delete(estrutura);
            return Ok(centroCustoDeletado.Result);
        }
    }
}