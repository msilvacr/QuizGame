﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Meio_Ambiente.Classes
{
    public class Jogo
    {
        //public static int QTD_QUESTOES_POR_JOGO = Properties.Settings.Default.qtdQuestoes;
        //
        //public static int TEMPO_POR_QUESTAO = Properties.Settings.Default.tempoQuestoes;

        private List<Questao> questoes = new List<Questao>();

        public Jogo() { } 

        public Jogo(List<Questao> questoes)
        {
            this.questoes = questoes;
        }

        public List<Questao> Questoes
        {
            get { return questoes; }
            set { questoes = value; }
        }

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

            return (qtd * 100 ) / questoes.Count;
        }

        public static void AlterarQuantidadeQuestoesPorJogo(int qtd)
        {
            Properties.Settings.Default.qtdQuestoes = qtd;
        }

        public static void AlterarTempoPorQuestao(int qtd)
        {
            Properties.Settings.Default.tempoQuestoes = qtd;
        }

        public static int QTD_QUESTOES_POR_JOGO()
        {
            return Properties.Settings.Default.qtdQuestoes;
        }

        public static int TEMPO_POR_QUESTAO()
        {
            return Properties.Settings.Default.tempoQuestoes;
        }
    }
}
