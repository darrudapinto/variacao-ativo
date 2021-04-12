using System.Linq;
using System.Threading.Tasks;
using VariacaoAtivoBackendMysql.Database;
using VariacaoAtivoBackendMysql.Interfaces;
using VariacaoAtivoBackendMysql.Modelos;

namespace VariacaoAtivoBackendMysql.Repositorios
{
    public class AcaoRepositorio : RepositorioBase<Acao>, IAcaoRepositorio
    {
        public AcaoRepositorio(AplicacaoDbContexto contexto) : base(contexto)
        {
        }
    }
}
