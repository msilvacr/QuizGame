using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Meio_Ambiente.Classes
{
    class Tema
    {
        private int idTema;
        private string descricao;

        public int IDTema
        {
            get { return idTema; }
            set { idTema = value; }
        }

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
    }
}
