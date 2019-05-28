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
    public partial class FormPrincipal : Form
    {
        ConexaoDB conn = new ConexaoDB();
        Tema tema;
        Jogo jogo;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            PreencherComboBox();
        }
        private void FormPrincipal_VisibleChanged(object sender, EventArgs e)
        {
            PreencherComboBox();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ver = MessageBox.Show("tem certeza que deseja sair?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if(ver == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void temasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTema frmTema = new FormTema();
            this.Visible = false;
            frmTema.ShowDialog();
            this.Visible = true;
        }

        private void PreencherComboBox()
        {
            comboBox1.Items.Clear();
            string query = "Select distinct Descricao from Tema order by Descricao Asc";

            DataTable table = conn.ExecutarConsulta(CommandType.Text, query);
            int i = 0;
            foreach (DataRow row in table.Rows)
            {
                comboBox1.Items.Add(row["Descricao"].ToString());
                i++;
            }

            comboBox1.SelectedIndex = 0;
        }

        private void questionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormQuestao formQuestao = new FormQuestao();

            this.Visible = false;

            formQuestao.ShowDialog();

            this.Visible = true;
        }
    }
}
