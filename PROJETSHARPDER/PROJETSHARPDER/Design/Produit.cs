using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace PROJETSHARPDER
{
    public partial class Produit : Form
    {
           
        public  Produit()
        {
            InitializeComponent();
        }
        DataBaseHelper db = new DataBaseHelper();
        Produits produit = new Produits();

        public void Alert(string message, FormAlert.enumType type)
        {
            FormAlert formAlert = new FormAlert();
            formAlert.showAlert(message, type);
        }
        private void Produit_Load(object sender, EventArgs e)
        {
            afficherTable();
            afficherComboBox();
            afficherNombreProduit();
        }

        private void afficherNombreProduit()
        {
            if (guna2DataGridView2.Rows.Count > 0)
            {
                int nombre = Convert.ToInt32(guna2DataGridView2.Rows.Count);
                if (nombre <= 1)
                {
                    labelProduit.Text = "PRODUIT : " + guna2DataGridView2.Rows.Count.ToString();
                }
                else
                {
                    labelProduit.Text = "PRODUITS  : " + guna2DataGridView2.Rows.Count.ToString();

                }
            }
            else
            {
                labelProduit.Text = "PRODUITS  : " + "0";

            }
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
                        comboxProduitCompanyTxt.Items.Add(reader.GetString(i));

                    }
                }
                db.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void usernameTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (produitNameTxt.Text == "" || produitAchatTxt.Text == "" || produitVenteTxt.Text == "" || produitQuantiteTxt.Text == "" || dateProduitTxt.Text == "" || comboxProduitCompanyTxt.Text == "")
            {
                MessageBox.Show("les champs sont vides  !");
                this.Alert("Saisir les champs !", FormAlert.enumType.Info);


            }
            else { 
                    int id = Convert.ToInt32(produitIdTxt.Text.Trim());
                    string nom = produitNameTxt.Text.Trim();
                    int prixAchat = Convert.ToInt32(produitAchatTxt.Text.Trim());
                    int prixVente = Convert.ToInt32(produitVenteTxt.Text.Trim());
                    int quantite = Convert.ToInt32(produitQuantiteTxt.Text.Trim());
                    string date = dateProduitTxt.Text.Trim();
                    string Company = comboxProduitCompanyTxt.Text.Trim();


                        if (produit.modifierProduit(id, nom, prixAchat, prixVente, quantite, date, Company))
                        {
                            MessageBox.Show("Produit Modifier avec succes", "Information ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Alert("Cet Produit est Modifier !", FormAlert.enumType.Success);
                            produitNameTxt.Clear();
                            produitAchatTxt.Clear();
                            produitVenteTxt.Clear();
                            produitQuantiteTxt.Clear();

                        }
                        else
                        {
                            MessageBox.Show("Produit Non Modifier", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Alert("Ressayer de Modifier", FormAlert.enumType.Info);

                }

                loadproduit();

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Home back = new Home();
            back.Show();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (produitNameTxt.Text == "" || produitAchatTxt.Text == "" || produitVenteTxt.Text == "" || produitQuantiteTxt.Text == "" || dateProduitTxt.Text == "" || comboxProduitCompanyTxt.Text == "")
            {
                  MessageBox.Show("les champs sont  !");
                  this.Alert("Saisir les champs  !", FormAlert.enumType.Info);

            }
            else
            {

                string nom = produitNameTxt.Text.Trim();
                int prixAchat = Convert.ToInt32(produitAchatTxt.Text.Trim());
                int prixVente = Convert.ToInt32(produitVenteTxt.Text.Trim());
                int quantite = Convert.ToInt32(produitQuantiteTxt.Text.Trim());
                string date = dateProduitTxt.Text.Trim();
                string Company = comboxProduitCompanyTxt.Text.Trim();

                if (!produit.verifcationProduit(nom))
                {

                    if (produit.ajouterProduit(nom, prixAchat, prixVente, quantite, date, Company))
                    {
                        MessageBox.Show("Produit Ajouter avec succes", "Information ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Alert(" Cet Produit Ajouter !", FormAlert.enumType.Success);
                        produitNameTxt.Clear();
                        produitAchatTxt.Clear();
                        produitVenteTxt.Clear();
                        produitQuantiteTxt.Clear();


                    }
                    else
                    {
                        MessageBox.Show("Produit Non Ajouter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Alert("Ressayer de Modifier  !", FormAlert.enumType.Info);

                    }
                }
                else if (produit.verifcationProduit(nom))
                {
                    MessageBox.Show("On a deja cet produit en stock", " Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Alert("Saisir un autre produit  !", FormAlert.enumType.Info);


                }


                loadproduit();
               
             }
                
        }

        private void afficherTable()
        {
            guna2DataGridView2.DataSource = getProduit();
        }

        private object getProduit()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `produit` ", db.GetConnection);
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);

            return table;
        }

        private void loadproduit()
        {
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM `produit` ", db.GetConnection);
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                db.closeConnection();
                guna2DataGridView2.DataSource = table;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

     
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                produitIdTxt.Text = guna2DataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                produitNameTxt.Text = guna2DataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                produitAchatTxt.Text = guna2DataGridView2.SelectedRows[0].Cells[2].Value.ToString();
                produitVenteTxt.Text = guna2DataGridView2.SelectedRows[0].Cells[3].Value.ToString();
                produitQuantiteTxt.Text = guna2DataGridView2.SelectedRows[0].Cells[4].Value.ToString();
                dateProduitTxt.Text = guna2DataGridView2.SelectedRows[0].Cells[5].Value.ToString();
                comboxProduitCompanyTxt.Text = guna2DataGridView2.SelectedRows[0].Cells[6].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Produit System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Alert("Produit System", FormAlert.enumType.Info);


            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            if (produitNameTxt.Text == "" || produitAchatTxt.Text == "" || produitVenteTxt.Text == "" || produitQuantiteTxt.Text == "" || dateProduitTxt.Text == "" || comboxProduitCompanyTxt.Text == "")
            {
                MessageBox.Show("les champs sont deja vides  !");
                this.Alert("Saisir les champs  !", FormAlert.enumType.Info);

            }
            else
            {
                produitIdTxt.Clear();
                produitNameTxt.Clear();
                produitAchatTxt.Clear();
                produitVenteTxt.Clear();
                produitQuantiteTxt.Clear();
                dateProduitTxt.Text = "";
                comboxProduitCompanyTxt.Text = "";
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void produitAchatTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Le Prix D'achat est Numerique", " Error");
                this.Alert("Saisir une valeur Numerique  !", FormAlert.enumType.Info);


            }
        }

        private void produitVenteTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Le Prix De Vente est Numerique", " Error");
                this.Alert("Saisir une valeur Numerique  !", FormAlert.enumType.Info);

            }
        }

        private void produitQuantiteTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("La Quantite est Numerique", " Error");
                this.Alert("Saisir une valeur Numerique  !", FormAlert.enumType.Info);

            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (produitNameTxt.Text == "" || produitAchatTxt.Text == "" || produitVenteTxt.Text == "" || produitQuantiteTxt.Text == "" || dateProduitTxt.Text == "" || comboxProduitCompanyTxt.Text == "")
            {
                MessageBox.Show("Les champs sont vides  !");
                this.Alert("Saisir les champs !", FormAlert.enumType.Info);

            }
            else
            {
                int id = Convert.ToInt32(produitIdTxt.Text.Trim());

                if (MessageBox.Show("Etes vous de vouloir Supprimer ..?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (produit.supprimerProduit(id))
                    {
                        MessageBox.Show("Produit Supprimer avec succes", "Information ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Alert("Cet Produit est Supprimer", FormAlert.enumType.Success);
                        produitIdTxt.Clear();
                        produitNameTxt.Clear();
                        produitAchatTxt.Clear();
                        produitVenteTxt.Clear();
                        produitQuantiteTxt.Clear();
                        dateProduitTxt.Text = "";
                        comboxProduitCompanyTxt.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("Fournisseur Non Supprimer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Alert("Ressayer de Supprimer ", FormAlert.enumType.Info);

                    }
                }


                loadproduit();
            }
        }
    }
}
