
namespace PROJETSHARPDER
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.Myprogressbar = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(226, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "GESTION DE STOCK";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Myprogressbar
            // 
            this.Myprogressbar.BackColor = System.Drawing.Color.Transparent;
            this.Myprogressbar.FillColor = System.Drawing.Color.White;
            this.Myprogressbar.FillOffset = 21;
            this.Myprogressbar.FillThickness = 10;
            this.Myprogressbar.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.Myprogressbar.ForeColor = System.Drawing.Color.White;
            this.Myprogressbar.InnerColor = System.Drawing.Color.Navy;
            this.Myprogressbar.Location = new System.Drawing.Point(292, 111);
            this.Myprogressbar.Maximum = 300;
            this.Myprogressbar.Minimum = 0;
            this.Myprogressbar.Name = "Myprogressbar";
            this.Myprogressbar.ProgressColor = System.Drawing.Color.DeepSkyBlue;
            this.Myprogressbar.ProgressColor2 = System.Drawing.Color.DarkBlue;
            this.Myprogressbar.ProgressEndCap = System.Drawing.Drawing2D.LineCap.Round;
            this.Myprogressbar.ProgressOffset = 20;
            this.Myprogressbar.ProgressStartCap = System.Drawing.Drawing2D.LineCap.Round;
            this.Myprogressbar.ProgressThickness = 40;
            this.Myprogressbar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.Myprogressbar.ShadowDecoration.Parent = this.Myprogressbar;
            this.Myprogressbar.ShowPercentage = true;
            this.Myprogressbar.Size = new System.Drawing.Size(260, 260);
            this.Myprogressbar.TabIndex = 1;
            this.Myprogressbar.Text = "guna2CircleProgressBar1";
            this.Myprogressbar.ValueChanged += new System.EventHandler(this.Myprogressbar_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 409);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(824, 63);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(201, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(422, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Back-Cover designed by Amadou Bhoye DIALLO";
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(824, 472);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Myprogressbar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CircleProgressBar Myprogressbar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
    }
}

