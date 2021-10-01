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
    public partial class Printer : Form
    {
        public string Date, produit,company,date,quantite;
        public Printer()
        {
            InitializeComponent();
            Date = DateTime.Now.ToString("M/d/yyyy");
        }

        private void guna2PictureBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(PictureBoxPrinter, "Print");
        }

        private void Printer_Load(object sender, EventArgs e)
        {
            labelTime.Text = Date;
            produitLabel.Text = produit;
            companyLabel.Text = company;
            quatiteLabel.Text = quantite;
            dateLabel.Text = date;
        }

        private void labelProduit_Click(object sender, EventArgs e)
        {

        }

        private void labelCompany_Click(object sender, EventArgs e)
        {

        }

        private void labelQuantite_Click(object sender, EventArgs e)
        {

        }

        private void labelDate_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
