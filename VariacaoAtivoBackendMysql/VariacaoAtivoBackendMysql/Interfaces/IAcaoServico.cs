using System.Threading.Tasks;
using VariacaoAtivoBackendMysql.Modelos;

namespace VariacaoAtivoBackendMysql.Interfaces
{
    public interface IAcaoServico
    {
        Task<Acao> ObterVariacaoAtivoUltimosTrintaDiasAsync(string simbolo);        
    }
}
