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
    public partial class FormQuestao : Form
    {
        ConexaoDB conn = new ConexaoDB();
        Tema tema;
        List<Questao> questoes = new List<Questao>();
        int totalAdd = 0;

        public FormQuestao()
        {
            InitializeComponent();
        }

        private void FormQuestao_Load(object sender, EventArgs e)
        {
            PreencherComboBox();
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

        private void button2_Click(object sender, EventArgs e)
        {
            if(txtQuestao.Text != string.Empty && txtA.Text != string.Empty && txtB.Text != string.Empty && txtC.Text != string.Empty && txtD.Text != string.Empty)
            {

                Questao questao = new Questao();

                questao.TemaQuestao = tema; //adicionando tema

                questao.TextoQuestao = txtQuestao.Text; //adicionando texto da questao

                Alternativa A = new Alternativa(txtA.Text, true);
                Alternativa B = new Alternativa(txtB.Text, false);
                Alternativa C = new Alternativa(txtC.Text, false);
                Alternativa D = new Alternativa(txtD.Text, false);

                Alternativa[] alternativas = new Alternativa[4] { A, B, C, D };

                questao.Alternativas = alternativas; //adicionando lista de alternativas

                questao.StatusQuestao = false; //adicionando status

                questoes.Add(questao); //inserindo na lista de questoes

                totalAdd++;
                LimparTextBox();
            }
            else
            {
                MessageBox.Show("Preencha todos os campos", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }
        private void LimparTextBox()
        {
            txtQuestao.Text = string.Empty;
            txtA.Text = string.Empty;
            txtB.Text = string.Empty;
            txtC.Text = string.Empty;
            txtD.Text = string.Empty;
            txtQuestao.Focus();
            this.lblTotal.Text = "Total Adicionadas: " + totalAdd.ToString();
            this.btnFinalizar.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.comboBox1.Enabled = false;
            this.btnSelecionar.Enabled = false;

            string query = string.Format("select * from tema where descricao = '{0}'", comboBox1.SelectedItem.ToString());

            DataTable table = conn.ExecutarConsulta(CommandType.Text, query);

            int idTema = Convert.ToInt16(table.Rows[0]["IDTema"]);
            string desc = table.Rows[0]["Descricao"].ToString();

            tema = new Tema(idTema, desc);

            groupBox2.Enabled = true;
            txtQuestao.Focus();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            ConexaoDB conn = new ConexaoDB();

            if(questoes.Count > 0)
            {
                foreach (Questao questao in questoes)
                {
                    string query = string.Format("INSERT INTO QUESTAO (IDTema, questao) " +
                                                 "OUTPUT inserted.IDQuestao " +
                                                 "VALUES({0}, '{1}')", tema.IDTema, questao.TextoQuestao);

                    int idQuestao = Convert.ToInt16(conn.ExecutarManipulacao(CommandType.Text, query).ToString());

                    foreach (Alternativa alternativa in questao.Alternativas)
                    {
                        query = string.Format("Insert into Alternativa(IDQuestao, Alternativa, Correta) " +
                                              "Values({0}, '{1}', {2})", idQuestao, alternativa.TextoAlternativa, Convert.ToInt16(alternativa.Correta));

                        conn.ExecutarManipulacao(CommandType.Text, query);
                    }
                }
                MessageBox.Show("Inseridas com sucesso");

                this.Dispose();
            }            
        }
    }
}
