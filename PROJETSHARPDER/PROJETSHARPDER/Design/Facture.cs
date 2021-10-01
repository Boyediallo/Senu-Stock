using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace PROJETSHARPDER
{
    public partial class Facture : Form
    {
        public Facture()
        {
            InitializeComponent();

        }

        DataBaseHelper db = new DataBaseHelper();
        Factures factures = new Factures();

        public void Alert(string message, FormAlert.enumType type)
        {
            FormAlert formAlert = new FormAlert();
            formAlert.showAlert(message, type);
        }
        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Home back = new Home();
            back.Show();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (factureProduitTxt.Text == "" || factureDateTxt.Text == "" || factureQuantiteTxt.Text == "" || ComboBoxCompanyFacture.Text =="")
            {
                MessageBox.Show("Saisir les champs  !");
                this.Alert("Saisir les champs !", FormAlert.enumType.Info);

            }
            else
            {

                string produit = factureProduitTxt.Text.Trim();
                string date = factureDateTxt.Text.Trim();
                int quantite = Convert.ToInt32(factureQuantiteTxt.Text.Trim());
                string Company = ComboBoxCompanyFacture.Text.Trim();


                if (factures.ajouterFacture(produit, date, quantite,Company))
                {
                    MessageBox.Show("Facture Ajouter avec succes", "Information ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Alert("Cette Facture est Ajouter !", FormAlert.enumType.Success);
                    factureProduitTxt.Text = "";
                    factureDateTxt.Text = "";
                    factureQuantiteTxt.Text = "";

                }
                else
                {
                    MessageBox.Show("Facture Non Ajouter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Alert("Cette Facture n'est Ajouter!", FormAlert.enumType.Info);

                }
                loadfacture();

            }

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
        

      
        private void Facture_Load_1(object sender, EventArgs e)
        {
            afficherTable();
            afficherNombreFacture();
            afficherComboBox();
        }

        private void afficherComboBox()
        {
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT `nomFournisseur` FROM `fournisseur`", db.GetConnection);
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        ComboBoxCompanyFacture.Items.Add(reader.GetString(i));

                    }
                }
                db.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void afficherNombreFacture()
        {
            if (guna2DataGridView1.Rows.Count > 0)
            {
                int nombre = Convert.ToInt32(guna2DataGridView1.Rows.Count);
                if (nombre <= 1)
                {
                    labelFacture.Text = "FACTURE : " + guna2DataGridView1.Rows.Count.ToString();
                }
                else
                {
                    labelFacture.Text = "FACTURES  : " + guna2DataGridView1.Rows.Count.ToString();

                }
            }
            else
            {
                labelFacture.Text = "FACTURE  : " + "0";

            }
        }

        private void afficherTable()
        {
            guna2DataGridView1.DataSource = getFacture();
        }

        private object getFacture()
        {
               MySqlCommand command = new MySqlCommand("SELECT * FROM `facture` ", db.GetConnection);
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);

                return table;
           
        }
        
        private void loadfacture()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `facture` ", db.GetConnection);
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            db.closeConnection();
            guna2DataGridView1.DataSource = table;
        }

        private void Facture_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void factureQuantiteTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("La Quantite est Numerique", " Error");
                this.Alert("Saisir une valeur numerique!", FormAlert.enumType.Info);

            }

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (factureProduitTxt.Text == "" || factureDateTxt.Text == "" || factureQuantiteTxt.Text == "" || ComboBoxCompanyFacture.Text =="")
            {
                MessageBox.Show("les champs sont vide  !");
                this.Alert("saisir les champs!", FormAlert.enumType.Info);

            }
            else
            {
                int id = Convert.ToInt32(factureIdTxt.Text.Trim());
                string produit = factureProduitTxt.Text.Trim();
                string date = factureDateTxt.Text.Trim();
                int quantite = Convert.ToInt32(factureQuantiteTxt.Text.Trim());
                string Company = ComboBoxCompanyFacture.Text.Trim();



                if (factures.modifierFacture(id, produit, date, quantite,Company))
                {
                    MessageBox.Show("Facture Modifer avec succes", "Information ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Alert("Cette Facture est Modifier!", FormAlert.enumType.Success);
                    factureProduitTxt.Text = "";
                    factureDateTxt.Text = "";
                    factureQuantiteTxt.Text = "";

                }
                else
                {
                    MessageBox.Show("Facture Non Modifier", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Alert("Cette Facture n'est pas Modifier!", FormAlert.enumType.Info);

                }
                loadfacture();
            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                factureIdTxt.Text = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                factureProduitTxt.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                factureDateTxt.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                factureQuantiteTxt.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                ComboBoxCompanyFacture.SelectedItem = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Facture System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Alert("Facture System!", FormAlert.enumType.Info);

            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            if (factureProduitTxt.Text == "" || factureDateTxt.Text == "" || factureQuantiteTxt.Text == "")
            {
                MessageBox.Show("les champs sont vide  deja vide!");
                this.Alert("Saisir les champs!", FormAlert.enumType.Info);

            }
            else
            {

                factureIdTxt.Clear();
                factureProduitTxt.Items.Clear();
                factureDateTxt.Text = "";
                factureProduitTxt.Text = "";
                factureQuantiteTxt.Clear();
                ComboBoxCompanyFacture.Items.Clear();

            }

        }

        private void factureIdTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void factureProduitTxt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void factureDateTxt_ValueChanged(object sender, EventArgs e)
        {

        }

        private void factureQuantiteTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (factureProduitTxt.Text == "" || factureDateTxt.Text == "" || factureQuantiteTxt.Text == "" || ComboBoxCompanyFacture.Text == "")
            {
                MessageBox.Show("les champs sont vide  !");
                this.Alert("Saisir les champs!", FormAlert.enumType.Info);

            }
            else
            {

                int id = Convert.ToInt32(factureIdTxt.Text.Trim());

                if (MessageBox.Show("Etes vous de vouloir Supprimer ..?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (factures.supprimerFacture(id))
                    {
                        MessageBox.Show("Facture Supprimer avec succes", "Information ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Alert("Cette Facture est Supprimer!", FormAlert.enumType.Success);
                        factureIdTxt.Clear();
                        factureProduitTxt.Text = "";
                        factureDateTxt.Text = "";
                        factureProduitTxt.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("Fournisseur Non Supprimer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Alert("Cette Facture n'est Ajouter!", FormAlert.enumType.Info);

                    }
                }


                loadfacture();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            Printer printer = new Printer();
            printer.produit = factureProduitTxt.SelectedItem.ToString();
            printer.company = ComboBoxCompanyFacture.SelectedItem.ToString();
            printer.quantite = factureQuantiteTxt.Text;
            printer.date = factureDateTxt.Text;
            printer.ShowDialog();
        }

        private void ComboBoxCompanyFacture_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void labelFacture_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
