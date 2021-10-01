using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJETSHARPDER
{
    public partial class FormLoading : Form
    {
        public FormLoading()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

        }

        int start = 0;
        private void timer1_Tick_2(object sender, EventArgs e)
        {
            start +=1;
            progressbar.Value = start;
            pourcentage.Text = start + "%";
            if (progressbar.Value == 100)
            {
                progressbar.Value = 0;
                timer1.Stop();
                Login login = new Login();
                login.Show();
                this.Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Myprogressbar_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {

        }

        private void progressbar_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
