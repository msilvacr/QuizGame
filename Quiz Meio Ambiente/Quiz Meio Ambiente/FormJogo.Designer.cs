﻿namespace Quiz_Meio_Ambiente
{
    partial class FormJogo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtA = new System.Windows.Forms.RadioButton();
            this.txtB = new System.Windows.Forms.RadioButton();
            this.txtC = new System.Windows.Forms.RadioButton();
            this.txtD = new System.Windows.Forms.RadioButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.txtTextoQuestao = new System.Windows.Forms.TextBox();
            this.lblNQuestao = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtA
            // 
            this.txtA.AutoSize = true;
            this.txtA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtA.Location = new System.Drawing.Point(12, 188);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(119, 24);
            this.txtA.TabIndex = 0;
            this.txtA.TabStop = true;
            this.txtA.Text = "radioButton1";
            this.txtA.UseVisualStyleBackColor = true;
            // 
            // txtB
            // 
            this.txtB.AutoSize = true;
            this.txtB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtB.Location = new System.Drawing.Point(12, 230);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(119, 24);
            this.txtB.TabIndex = 0;
            this.txtB.TabStop = true;
            this.txtB.Text = "radioButton1";
            this.txtB.UseVisualStyleBackColor = true;
            // 
            // txtC
            // 
            this.txtC.AutoSize = true;
            this.txtC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtC.Location = new System.Drawing.Point(12, 271);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(119, 24);
            this.txtC.TabIndex = 0;
            this.txtC.TabStop = true;
            this.txtC.Text = "radioButton1";
            this.txtC.UseVisualStyleBackColor = true;
            // 
            // txtD
            // 
            this.txtD.AutoSize = true;
            this.txtD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtD.Location = new System.Drawing.Point(12, 313);
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(119, 24);
            this.txtD.TabIndex = 0;
            this.txtD.TabStop = true;
            this.txtD.Text = "radioButton1";
            this.txtD.UseVisualStyleBackColor = true;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Quiz_Meio_Ambiente.Properties.Resources.clock;
            this.pictureBox1.Location = new System.Drawing.Point(356, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(430, 9);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 55);
            this.lblTime.TabIndex = 2;
            // 
            // txtTextoQuestao
            // 
            this.txtTextoQuestao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTextoQuestao.Location = new System.Drawing.Point(12, 87);
            this.txtTextoQuestao.Multiline = true;
            this.txtTextoQuestao.Name = "txtTextoQuestao";
            this.txtTextoQuestao.ReadOnly = true;
            this.txtTextoQuestao.Size = new System.Drawing.Size(587, 83);
            this.txtTextoQuestao.TabIndex = 3;
            // 
            // lblNQuestao
            // 
            this.lblNQuestao.AutoSize = true;
            this.lblNQuestao.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNQuestao.ForeColor = System.Drawing.Color.Black;
            this.lblNQuestao.Location = new System.Drawing.Point(12, 29);
            this.lblNQuestao.Name = "lblNQuestao";
            this.lblNQuestao.Size = new System.Drawing.Size(0, 37);
            this.lblNQuestao.TabIndex = 4;
            // 
            // FormJogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 422);
            this.Controls.Add(this.lblNQuestao);
            this.Controls.Add(this.txtTextoQuestao);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtD);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormJogo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormJogo";
            this.Load += new System.EventHandler(this.FormJogo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton txtA;
        private System.Windows.Forms.RadioButton txtB;
        private System.Windows.Forms.RadioButton txtC;
        private System.Windows.Forms.RadioButton txtD;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TextBox txtTextoQuestao;
        private System.Windows.Forms.Label lblNQuestao;
    }
}