using Quiz_Meio_Ambiente.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz_Meio_Ambiente
{
    public partial class FormTema : Form
    {
        ConexaoDB conn = new ConexaoDB();
        public FormTema()
        {
            InitializeComponent();
        }

        private void FormTema_Load(object sender, EventArgs e)
        {

        }

        private void buttonIniciar_Click(object sender, EventArgs e)
        {
            if(textBoxTema.Text == string.Empty)
            {
                MessageBox.Show("Preencha o campo antes de tentar adicionar o tema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxTema.Focus();
            }
            else
            {
                string query = string.Format("select * from tema where UPPER(descricao) = '{0}'", textBoxTema.Text.ToUpper());

                DataTable table = conn.ExecutarConsulta(CommandType.Text, query); //consultando pra ver se ja nao existe no banco de dados

                if(table.Rows.Count == 0)
                {
                    query = string.Format("insert into tema(Descricao) Values('{0}')", textBoxTema.Text.ToUpper());
                    conn.ExecutarManipulacao(CommandType.Text, query); //inserindo tema
                    MessageBox.Show("Tema adicionado.", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("O tema já existe no banco de dados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxTema.Text = string.Empty;
                    textBoxTema.Focus();
                }
            }
        }
    }
}
