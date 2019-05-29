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
            if (this.Visible)
            {
                PreencherComboBox();
                jogo = new Jogo();
            }
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

            if (table.Rows.Count > 0)
            {
                comboBox1.Enabled = true;
                int i = 0;
                foreach (DataRow row in table.Rows)
                {
                    comboBox1.Items.Add(row["Descricao"].ToString());
                    i++;
                }

                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.Enabled = false;
                MessageBox.Show("O jogo ainda não possui nenhum tema, para começar a jogar, por favor, adicione temas ao jogo e questionários aos temas!", "Bem-vindo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            string query = string.Format("SELECT TOP {0} * FROM QUESTAO "+
                                         "WHERE IDTema = {1} "+
                                         "ORDER BY NEWID()", Jogo.QTD_QUESTOES_POR_JOGO, tema.IDTema);

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

                Alternativa[] alternativas = new Alternativa[tableAlternativas.Rows.Count];

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

            if (qtd >= Jogo.QTD_QUESTOES_POR_JOGO)
            {
                return true;
            }
            else
            {
                string msg = string.Format("O tema selecionado não possui questões suficientes ({0}/{1})\nPor favor, adicione novas questões ao tema para continuar", qtd, Jogo.QTD_QUESTOES_POR_JOGO);
                MessageBox.Show(msg, "aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        //teste - pego da internet (simula showinputdialog do JAVA)
        private static string ShowInputDialog(ref string input, string msg)
        {
            int sizeX = 200;
            int sizeY = 70;

            System.Drawing.Size size = new System.Drawing.Size(sizeX, sizeY);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            //inputBox.Location = new System.Drawing.Point(x + sizeX / 2, y + sizeY / 2);
            inputBox.StartPosition = FormStartPosition.CenterScreen;
            inputBox.Text = msg;

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            //input = textBox.Text;
            //return result;

            if(result == DialogResult.Cancel)
            {
                return "cancel";
            }

            return textBox.Text;
        }

        private void alterarQuantidadeDeQuestõesPorJogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int novaQtd=-30;
            string msg = "Questões";

            do
            {
                try
                {
                    string input = "";

                    string qtd = ShowInputDialog(ref input, msg);

                    if (qtd == "cancel")
                    {
                        break;
                    }
                    else
                    {
                        novaQtd = Convert.ToInt32(qtd);
                        if (novaQtd >= 4 && novaQtd <= 40)
                        {
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Valor inválido.\nQuantidade mínima: 4\nQuantidade máxima: 40", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Valor inválido");
                }

            }
            while (true);

            if(novaQtd > 0)
            {
                Properties.Settings.Default.qtdQuestoes = novaQtd;
                Properties.Settings.Default.Save();
                MessageBox.Show("Alterado com sucesso!", "Êxito", MessageBoxButtons.OK);
            }
        }

        private void alterarTempoPorQuestãosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int novoTempo = -30;
            string msg = "Tempo";

            do
            {
                try
                {
                    string input = "";

                    string qtd = ShowInputDialog(ref input, msg);

                    if (qtd == "cancel")
                    {
                        break;
                    }
                    else
                    {
                        novoTempo = Convert.ToInt32(qtd);
                        if (novoTempo >= 10 && novoTempo <= 60)
                        {
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Valor inválido.\nTempo mínimo: 5s\nTempo máximo: 60s", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Valor inválido");
                }

            }
            while (true);

            if (novoTempo > 0)
            {
                Properties.Settings.Default.tempoQuestoes = novoTempo;
                Properties.Settings.Default.Save();
                MessageBox.Show("Alterado com sucesso!", "Êxito", MessageBoxButtons.OK);
            }
        }
    }
}
