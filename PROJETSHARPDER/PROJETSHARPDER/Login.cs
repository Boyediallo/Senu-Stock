using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace PROJETSHARPDER
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        DataBaseHelper db = new DataBaseHelper();
        int i;
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
             Home home = new Home();

            if ((usernameTxt.Text == "Amadou Bhoye Diallo" || usernameTxt.Text == "Admin" || usernameTxt.Text == "Moustapha Der") && passwordTxt.Text == "passer@1")
            {
                home.Show();
                this.Hide();

            } else
            {
                MessageBox.Show("Wrong Username or Password");

            }
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
