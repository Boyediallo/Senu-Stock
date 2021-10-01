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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            Produit produit = new Produit();
            produit.ShowDialog();
        }

        private void guna2CirclePictureBox3_Click(object sender, EventArgs e)
        {
            Fournisseur fournisseur= new Fournisseur();
            fournisseur.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox4_Click(object sender, EventArgs e)
        {
            Facture facture = new Facture();
            facture.ShowDialog();
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
                }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CirclePictureBox5_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Produit produit = new Produit();
            produit.ShowDialog();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Facture facture = new Facture();
            facture.ShowDialog();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Fournisseur fournisseur = new Fournisseur();
            fournisseur.ShowDialog();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Manoeuvre manoeuvre = new Manoeuvre();
            manoeuvre.ShowDialog();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DialogResult iExit;

            try
            {
                iExit = MessageBox.Show("Confirmez vous Fermer l'Application", "MySQL Connect", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (iExit == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
