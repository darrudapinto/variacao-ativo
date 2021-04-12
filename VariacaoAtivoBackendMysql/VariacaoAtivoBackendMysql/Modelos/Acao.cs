using System.Collections.Generic;

namespace VariacaoAtivoBackendMysql.Modelos
{
    public class Acao
    {
        public Acao()
        {
            Historico = new List<Historico>();
        }

        public int AcaoId { get; set; }
        public string Simbolo { get; set; }
        public List<Historico> Historico { get; set; }

        public void CalcularVariacoes()
        {
            for (int i = 0; i < Historico.Count; i++)
            {
                if (i != 0)
                {
                    var anterior = Historico[i - 1];
                    var atual = Historico[i];

                    //(VF / VI - 1) × 100
                    atual.VariacaoDiaAnterior = decimal.Round((atual.ValorAbertura / anterior.ValorAbertura - 1) * 100, 2);
                    atual.VariacaoInicioPeriodo = decimal.Round((atual.ValorAbertura / Historico[0].ValorAbertura - 1) * 100, 2);
                }
            }
        }
    }
}
