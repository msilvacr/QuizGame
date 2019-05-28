using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Meio_Ambiente.Classes
{
    class Questao
    {
        Tema temaQuestao;
        private int idQuestao;
        private string textoQuestao;
        Alternativa[] alternativas;
        private bool statusQuestao;

        public Questao(Tema temaQuestao, int idQuestao, string textoQuestao)
        {
            this.temaQuestao = temaQuestao;
            this.idQuestao = idQuestao;
            this.textoQuestao = textoQuestao;
        }

        public Questao() {}

        public Tema TemaQuestao
        {
            get { return temaQuestao; }
            set { temaQuestao = value; }
        }

        public int IDQuestao
        {
            get { return idQuestao; }
            set { idQuestao = value; }
        }

        public string TextoQuestao
        {
            get { return textoQuestao; }
            set { textoQuestao = value; }
        }

        public Alternativa[] Alternativas
        {
            get { return alternativas; }
            set { alternativas = value; }
        }

        public bool StatusQuestao
        {
            get { return statusQuestao; }
            set { statusQuestao = value; }
        }
    }
}
