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
        public void Alert(string message, FormAlert.enumType type)
        {
            FormAlert formAlert = new FormAlert();
            formAlert.showAlert(message, type);
        }
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
                MessageBox.Show(" Username ou Password incorrect");
                this.Alert("Saisir Le Username et le Password", FormAlert.enumType.Info);

            }
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
