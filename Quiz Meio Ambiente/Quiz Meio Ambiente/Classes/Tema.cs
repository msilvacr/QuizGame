using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Meio_Ambiente.Classes
{
    public class Tema
    {
        private int idTema;
        private string descricao;

        public Tema(int idTema, string descricao)
        {
            this.idTema = idTema;
            this.descricao = descricao;
        }

        public Tema() { }        

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
