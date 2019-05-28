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
        private string textoAlternativa;

        public Alternativa(int idAlternativa, string textoAlternativa)
        {
            this.idAlternativa = idAlternativa;
            this.textoAlternativa = textoAlternativa;
        }

        public int IDAlternativa
        {
            get { return idAlternativa; }
            set { idAlternativa = value; }
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
