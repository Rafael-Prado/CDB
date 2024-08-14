using CalculoCdbApi.ViewModel;
using CdbDomain.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculoCdbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculoCdbController : Controller
    {
        private readonly IInvestimentoService _service;

        public CalculoCdbController(IInvestimentoService service)
        {
            _service = service;
        }


        // POST api/<CalculoCdbController>
        [HttpPost("calcular")]
        public ActionResult<InvestimentoResponse> Post([FromBody] InvestimentoRequest investimento)
        {
            var valorBruto = _service.CalcularValorBruto(investimento.Valor, investimento.Mes);
            var taxa = _service.CalcularTaxa(investimento.Mes, valorBruto, investimento.Valor);

            var response = new InvestimentoResponse {
                ValorBruto = Math.Round(valorBruto, 2),
                ValorLiquido = Math.Round(valorBruto - taxa),
            };
            return Ok(response);
        }
        
    }
}
