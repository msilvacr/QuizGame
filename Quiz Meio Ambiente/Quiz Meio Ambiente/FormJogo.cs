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
    public partial class FormJogo : Form
    {
        private Jogo jogo;
        private int nQuestao = 0;
        TimeSpan time;// = new TimeSpan(0, 0, 30);

        public FormJogo(Jogo jogo)
        {
            InitializeComponent();

            this.jogo = jogo;
        }

        private void ProximaQuestao(Jogo jogo)
        {
            txtTextoQuestao.Text = jogo.Questoes[nQuestao].TextoQuestao;
            txtA.Text = jogo.Questoes[nQuestao].Alternativas[0].TextoAlternativa;
            txtB.Text = jogo.Questoes[nQuestao].Alternativas[1].TextoAlternativa;
            txtC.Text = jogo.Questoes[nQuestao].Alternativas[2].TextoAlternativa;
            txtD.Text = jogo.Questoes[nQuestao].Alternativas[3].TextoAlternativa;

            time = new TimeSpan(0, 0, 30);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time = time.Subtract(TimeSpan.FromSeconds(1));
            lblTime.Text = time.Minutes.ToString() + ":" + time.Seconds.ToString(); ;
            timer.Start();
        }

        private void FormJogo_Load(object sender, EventArgs e)
        {
            timer.Start();
            ProximaQuestao(jogo);
        }
    }
}
