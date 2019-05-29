using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Meio_Ambiente.Classes
{
    public class Alternativa
    {
        private int idAlternativa;
        private Questao questao;
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

        public Alternativa(int idAlternativa, Questao questao, bool correta, string textoAlternativa)
        {
            this.idAlternativa = idAlternativa;
            this.questao = questao;
            this.correta = correta;
            this.textoAlternativa = textoAlternativa;
        }

        public int IDAlternativa
        {
            get { return idAlternativa; }
            set { idAlternativa = value; }
        }

        public Questao Questao
        {
            get { return questao; }
            set { questao = value; }
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
