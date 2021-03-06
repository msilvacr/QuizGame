﻿using Quiz_Meio_Ambiente.Classes;
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

        TimeSpan time;

        public FormJogo(Jogo jogo)
        {
            InitializeComponent();

            this.jogo = jogo;

            DeselecionarRadioButtons();
        }

        private void ProximaQuestao()
        {
            timer.Stop();
            time = new TimeSpan(0, 0, Jogo.TEMPO_POR_QUESTAO());

            txtTextoQuestao.Text = jogo.Questoes[nQuestao].TextoQuestao;

            txtA.Text = jogo.Questoes[nQuestao].Alternativas[0].TextoAlternativa;
            txtB.Text = jogo.Questoes[nQuestao].Alternativas[1].TextoAlternativa;
            txtC.Text = jogo.Questoes[nQuestao].Alternativas[2].TextoAlternativa;
            txtD.Text = jogo.Questoes[nQuestao].Alternativas[3].TextoAlternativa;

            this.lblNQuestao.Text = string.Format("{0}/{1}", nQuestao + 1, jogo.Questoes.Count);

            DeselecionarRadioButtons();
            timer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time = time.Subtract(TimeSpan.FromSeconds(1));
            lblTime.Text = time.Minutes.ToString() + ":" + time.Seconds.ToString(); ;
            VerificarTempo();
            timer.Start();
        }

        private void FormJogo_Load(object sender, EventArgs e)
        {
            ProximaQuestao();
            DeselecionarRadioButtons();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Stop();
            if (ChecarRadioButton())
            {
                verificarQuestao();

                if (nQuestao == Jogo.QTD_QUESTOES_POR_JOGO())
                {
                    ConcluirJogo();
                }
                else
                {
                    ProximaQuestao();
                    if (nQuestao == Jogo.QTD_QUESTOES_POR_JOGO()-1)
                    {
                        button2.Text = "Finalizar";
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma alternativa", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void ConcluirJogo()
        {
            timer.Stop();

            double pontuacao = Jogo.CalcularPorcentagemAcertos(jogo.Questoes);
            int qtdAcertos = Jogo.CalcularQtdAcertos(jogo.Questoes);

            string msg1 = string.Format("Você acertou {0}% das questões!", pontuacao);
            string msg2 = string.Format("Acertos: {0}/{1}", qtdAcertos, jogo.Questoes.Count);

            MessageBox.Show(msg1, msg2, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            this.Dispose();
        }

        private bool ChecarRadioButton()
        {
            if (txtA.Checked || txtB.Checked || txtC.Checked || txtD.Checked)
                return true;
            else
                return false;            
        }

        private void DeselecionarRadioButtons()
        {
            txtA.Checked = false;
            txtB.Checked = false;
            txtC.Checked = false;
            txtD.Checked = false;
        }

        private void verificarQuestao()
        {
            string texto="";

            if(txtA.Checked)
            {
                texto = txtA.Text;
            }
            else if (txtB.Checked)
            {
                texto = txtB.Text;
            }
            else if (txtC.Checked)
            {
                texto = txtC.Text;
            }
            else if (txtD.Checked)
            {
                texto = txtD.Text;
            }

            foreach(Alternativa a in jogo.Questoes[nQuestao].Alternativas)
            {
                if(a.Correta)
                {
                    if(a.TextoAlternativa == texto)
                    {
                        MessageBox.Show("Resposta correta", "Você acertou!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResponderQuestao(true);
                    }
                    else
                    {
                        MessageBox.Show("Resposta errada...", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        ResponderQuestao(false);
                    }
                }
            }
        }

        private void VerificarTempo()
        {
            if(time.Seconds <= 0)
            {
                timer.Stop();
                MessageBox.Show("O tempo acabou...", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ResponderQuestao(false);
                timer.Start();


                if (nQuestao == Jogo.QTD_QUESTOES_POR_JOGO())
                {
                    ConcluirJogo();
                }
                else
                {
                    ProximaQuestao();
                    if (nQuestao == Jogo.QTD_QUESTOES_POR_JOGO() - 1)
                    {
                        button2.Text = "Finalizar";
                    }
                }
            }
        }

        private void ResponderQuestao(bool status)
        {
            jogo.Questoes[nQuestao].StatusQuestao = status;

            nQuestao++;
        }

        private void FormJogo_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }
    }
}
