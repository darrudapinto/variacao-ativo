using System;

namespace VariacaoAtivoBackend
{
    public class Historico
    {        
        public Historico(DateTime dataPregao, decimal valorAbertura)
        {
            DataPregao = dataPregao;
            ValorAbertura = valorAbertura;
        }

        public DateTime DataPregao { get; protected set; }
        public decimal ValorAbertura { get; protected set; }
        public decimal VariacaoDiaAnterior { get; set; }
        public decimal VariacaoInicioPeriodo { get; set; }
    }
}
