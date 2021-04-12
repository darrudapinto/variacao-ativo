using System;

namespace VariacaoAtivoBackendMysql.Modelos
{
    public class Historico
    {
        public Historico(DateTime dataPregao, decimal valorAbertura)
        {
            DataPregao = dataPregao;
            ValorAbertura = valorAbertura;
        }

        public int HistoricoId { get; set; }
        public DateTime DataPregao { get; protected set; }
        public decimal ValorAbertura { get; protected set; }
        public decimal VariacaoDiaAnterior { get; set; }
        public decimal VariacaoInicioPeriodo { get; set; }

        public int AcaoId { get; set; }
        public Acao Acao { get; set; }
    }
}
