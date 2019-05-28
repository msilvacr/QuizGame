using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Meio_Ambiente.Classes
{
    class Alternativa
    {
        private int idAlternativa;
        private int idQuestao;
        private bool correta;
        private string textoAlternativa;

        public Alternativa() { }
        public Alternativa(string textoAlternativa, bool correta)
        {
            this.textoAlternativa = textoAlternativa;
            this.correta = correta;
        }
        public Alternativa(int idAlternativa, string textoAlternativa)
        {
            this.idAlternativa = idAlternativa;
            this.textoAlternativa = textoAlternativa;
        }
        public Alternativa(int idAlternativa, int idQuestao)
        {
            this.idAlternativa = idAlternativa;
            this.idQuestao = idQuestao;
        }

        public int IDAlternativa
        {
            get { return idAlternativa; }
            set { idAlternativa = value; }
        }

        public int IDQuestao
        {
            get { return IDQuestao; }
            set { IDQuestao = value; }
        }

        public bool Correta
        {
            get { return correta; }
            set { correta = value; }
        }
        public string TextoAlternativa
        {
            get { return textoAlternativa; }
            set { textoAlternativa = value; }
        }

        public override bool Equals(object obj)
        {
            var alternativa = obj as Alternativa;
            return alternativa != null &&
                   idAlternativa == alternativa.idAlternativa &&
                   textoAlternativa == alternativa.textoAlternativa;
        }
    }
}
