using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VariacaoAtivoBackendMysql.Database;
using VariacaoAtivoBackendMysql.Interfaces;
using VariacaoAtivoBackendMysql.Modelos;
using YahooFinanceApi;

namespace VariacaoAtivoBackendMysql.Servicos
{
    public class AcaoServico : IAcaoServico
    {
        private readonly IAcaoRepositorio Repositorio;
        private readonly AplicacaoDbContexto Contexto;

        public AcaoServico(IAcaoRepositorio repositorio, [FromServices] AplicacaoDbContexto contexto)
        {
            Repositorio = repositorio;
            Contexto = contexto;
        }        

        public async Task<Acao> ObterVariacaoAtivoUltimosTrintaDiasAsync(string simbolo)
        {
            //Verifica se a ação já existe na base e em caso positivo retorna.
            var acao = Repositorio.ObterTodosComEagerLoad(a => a.Historico).FirstOrDefault(a => a.Simbolo == simbolo);

            if (acao != null)
                return acao;

            var retorno = new Acao();
            var resultado = await Yahoo.GetHistoricalAsync(simbolo, DateTime.Now.AddMonths(-1), DateTime.Now, Period.Daily);

            foreach (var pregao in resultado)
                retorno.Historico.Add(new Historico(pregao.DateTime, pregao.Open));

            retorno.Simbolo = simbolo;
            retorno.CalcularVariacoes();

            return await Repositorio.AdicionarAsync(retorno);            
        }
    }
}
