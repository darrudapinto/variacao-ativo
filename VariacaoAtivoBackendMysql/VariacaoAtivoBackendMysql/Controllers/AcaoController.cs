using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VariacaoAtivoBackendMysql.Interfaces;
using VariacaoAtivoBackendMysql.Modelos;

namespace VariacaoAtivoBackendMysql.Controllers
{
    [ApiController]
    [Route("v1/acao")]
    public class AcaoController
    {
        private readonly IAcaoServico Servico;

        public AcaoController(IAcaoServico servico)
        {
            Servico = servico;
        }

        [HttpGet]
        [Route("{simbolo}")]
        public async Task<ActionResult<Acao>> Get(string simbolo)
        {
            return await Servico.ObterVariacaoAtivoUltimosTrintaDiasAsync(simbolo);            
        }        
    }
}
