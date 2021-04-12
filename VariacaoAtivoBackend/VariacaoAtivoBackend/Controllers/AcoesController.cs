using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YahooFinanceApi;

namespace VariacaoAtivoBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcoesController : ControllerBase
    {
        [HttpGet("{simboloAcao}")]
        public async Task<Acao> GetAsync(string simboloAcao)
        {
            var retorno = new Acao();            
            var resultado = await Yahoo.GetHistoricalAsync(simboloAcao, DateTime.Now.AddMonths(-1), DateTime.Now, Period.Daily);

            foreach (var pregao in resultado)
                retorno.Historico.Add(new Historico(pregao.DateTime, pregao.Open));                

            retorno.CalcularVariacoes();
            return retorno;
        }
    }
}
