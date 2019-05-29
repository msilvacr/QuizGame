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
            jogo = new Jogo();
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

        private void buttonIniciar_Click(object sender, EventArgs e)
        {
            CriarTema();
            if(!ValidarQtdQuestoesTema(this.tema))
            {
                //o tema não possui questões suficientes
            }
            else
            {
                CriarJogoAPartirDoTema();

                FormJogo formjogo = new FormJogo(jogo);

                this.Visible = false;
                formjogo.ShowDialog();
                this.Visible = true;
            }
        }

        private void CriarJogoAPartirDoTema()
        {
            string query = string.Format("SELECT TOP 10 * FROM QUESTAO "+
                                         "WHERE IDTema = {0} "+
                                         "ORDER BY NEWID()", tema.IDTema);

            DataTable table = conn.ExecutarConsulta(CommandType.Text, query);

            foreach(DataRow row in table.Rows)
            {
                Questao novaQuestao = new Questao();

                novaQuestao.IDQuestao = Convert.ToInt32(row["IDQuestao"].ToString());

                novaQuestao.TextoQuestao = row["Questao"].ToString();

                novaQuestao.StatusQuestao = false;

                novaQuestao.TemaQuestao = tema;

                query = string.Format("SELECT * FROM Alternativa " +
                                      "WHERE IDQuestao = {0} " +
                                      "ORDER BY NEWID()", novaQuestao.IDQuestao);

                DataTable tableAlternativas = conn.ExecutarConsulta(CommandType.Text, query);

                Alternativa[] alternativas = new Alternativa[table.Rows.Count];

                int i = 0;

                foreach(DataRow rowAlternativa in tableAlternativas.Rows)
                {
                    int idAlternativa = rowAlternativa.Field<int>("IDAlternativa");
                    string textoAlternativa = rowAlternativa.Field<string>("Alternativa");
                    bool correta = rowAlternativa.Field<bool>("Correta");

                    alternativas[i] = new Alternativa(idAlternativa, novaQuestao, correta, textoAlternativa);
                    i++;
                }
                novaQuestao.Alternativas = alternativas;

                jogo.Questoes.Add(novaQuestao);
            }
        }       

        private void CriarTema()
        {
            string itemSelecionado = comboBox1.GetItemText(comboBox1.SelectedItem);

            string query = string.Format("SELECT * FROM Tema " +
                                         "Where Descricao = '{0}'", itemSelecionado);

            DataTable table = conn.ExecutarConsulta(CommandType.Text, query);

            int idTema = table.Rows[0].Field<int>("IDTema");
            string descTema = table.Rows[0].Field<string>("Descricao");

            tema = new Tema(idTema, descTema);//criando tema selecionado

        }

        private bool ValidarQtdQuestoesTema(Tema tema)
        {
            string query = string.Format("Select COUNT(IDQuestao) from Questao Where IDTema = {0}", tema.IDTema);

            int qtd = Convert.ToInt16(conn.ExecutarManipulacao(CommandType.Text, query).ToString());

            if(qtd > 9)
            {
                return true;
            }
            else
            {
                string msg = string.Format("O tema selecionado não possui questões suficientes ({0}/10)\nPor favor, adicione novas questões ao tema para continuar", qtd);
                MessageBox.Show(msg, "aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
    }
}
