using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Meio_Ambiente.Classes
{
    class Jogo
    {
        private List<Questao> questoes = new List<Questao>();

        public void AdicionarQuestao(Questao questao)
        {
            bool vrf = false;
            foreach(Questao q in questoes)
            {
                if(q.Equals(questao))//verificando se a questão que vai ser é igual a alguma que já esteja na lista
                {
                    vrf = true;
                }
            }

            if(!vrf)
            {
                questoes.Add(questao);
            }
        }

        public static int CalcularQtdAcertos(List<Questao> questoes)
        {
            int qtd = 0;
            foreach (Questao q in questoes)
            {
                if (q.StatusQuestao)
                {
                    qtd++;
                }
            }

            return qtd;
        }

        public static double CalcularPorcentagemAcertos(List<Questao> questoes)
        {
            int qtd = Jogo.CalcularQtdAcertos(questoes);

            return (qtd / questoes.Count) * 100;
        }
    }
}
