﻿namespace NewGameUI
{
    partial class GameMainWindow
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblRPS = new System.Windows.Forms.Label();
            this.lblCounter = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.timerUI = new System.Windows.Forms.Timer(this.components);
            this.pnlArena = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlArena)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnTest);
            this.panel1.Controls.Add(this.btnRestart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(888, 39);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblRPS);
            this.panel3.Controls.Add(this.lblCounter);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(165, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(277, 33);
            this.panel3.TabIndex = 2;
            // 
            // lblRPS
            // 
            this.lblRPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblRPS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblRPS.Location = new System.Drawing.Point(158, 6);
            this.lblRPS.Name = "lblRPS";
            this.lblRPS.Size = new System.Drawing.Size(116, 20);
            this.lblRPS.TabIndex = 5;
            this.lblRPS.Text = "0 RPS";
            this.lblRPS.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCounter
            // 
            this.lblCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCounter.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblCounter.Location = new System.Drawing.Point(85, 6);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(67, 18);
            this.lblCounter.TabIndex = 4;
            this.lblCounter.Text = "000000000";
            this.lblCounter.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.LimeGreen;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Round";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(84, 7);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(3, 7);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 23);
            this.btnRestart.TabIndex = 0;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // timerUI
            // 
            this.timerUI.Tick += new System.EventHandler(this.timerUI_Tick);
            // 
            // pnlArena
            // 
            this.pnlArena.BackColor = System.Drawing.Color.Black;
            this.pnlArena.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlArena.Location = new System.Drawing.Point(0, 39);
            this.pnlArena.Name = "pnlArena";
            this.pnlArena.Size = new System.Drawing.Size(888, 594);
            this.pnlArena.TabIndex = 3;
            this.pnlArena.TabStop = false;
            // 
            // GameMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(888, 633);
            this.Controls.Add(this.pnlArena);
            this.Controls.Add(this.panel1);
            this.Name = "GameMainWindow";
            this.Text = "GameMainWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameMainWindow_FormClosed);
            this.Load += new System.EventHandler(this.GameMainWindow_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlArena)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerUI;
        private System.Windows.Forms.Label lblRPS;
        private System.Windows.Forms.PictureBox pnlArena;

    }
}

