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
    public partial class Fournisseur : Form
    {

        public Fournisseur()
        {
            InitializeComponent();
        }
        DataBaseHelper db = new DataBaseHelper();
        Fournisseurs fournisseur = new Fournisseurs();

        public void Alert(string message, FormAlert.enumType type)
        {
            FormAlert formAlert = new FormAlert();
            formAlert.showAlert(message, type);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Home back = new Home();
            back.Show();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Fournisseur_Load(object sender, EventArgs e)
        {
            afficherTable();

            afficherNombreFournisseur();

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (companyNameTxt.Text == "" || companyPhoneNumberTxt.Text == "" || companyAddressTxt.Text == "" || companyEmailTxt.Text == "")
            {
                MessageBox.Show("les champs sont vide !");
                this.Alert("Saisir les champs !", FormAlert.enumType.Info);

            }
            else { 

                int id = Convert.ToInt32(companyIdTxt.Text.Trim());
                string nomFournisseur = companyNameTxt.Text.Trim();
                string telephone = companyPhoneNumberTxt.Text.Trim();
                string address = companyAddressTxt.Text.Trim();
                string email = companyEmailTxt.Text.Trim();

           
                    if (fournisseur.modifierFounisseur(id,nomFournisseur, telephone, address, email))
                    {
                        MessageBox.Show("Fournisseur Modifier avec succes", "Information ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Alert("Cet Fournisseur est Modifier !", FormAlert.enumType.Success);
                        companyNameTxt.Clear();
                        companyPhoneNumberTxt.Clear();
                        companyAddressTxt.Clear();
                        companyEmailTxt.Clear();

                    }
                    else
                    {
                        MessageBox.Show("Fournisseur Non Modifier", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Alert("Cet Fournisseur existe !", FormAlert.enumType.Info);

                }


                loadfournisseur();


            }

        }

        private void buttonAddCompany_Click(object sender, EventArgs e)
        {
            if (companyNameTxt.Text == "" || companyPhoneNumberTxt.Text == "" || companyAddressTxt.Text == "" || companyEmailTxt.Text == "")
            {
                MessageBox.Show("Saisir les champs  !");
                this.Alert("Saisir les champs !", FormAlert.enumType.Info);

            }
            else
            {

                string nomFournisseur = companyNameTxt.Text.Trim();
                string telephone = companyPhoneNumberTxt.Text.Trim();
                string address = companyAddressTxt.Text.Trim();
                string email = companyEmailTxt.Text.Trim();

                if (!fournisseur.verifcationFournisseur(email))
                {

                    if (fournisseur.ajouterFournisseur(nomFournisseur, telephone, address, email))
                    {
                        MessageBox.Show("Fournisseur Ajouter avec succes", "Information ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Alert("Cet Fournisseur est Ajouter !", FormAlert.enumType.Success);
                        companyNameTxt.Clear();
                        companyPhoneNumberTxt.Clear();
                        companyAddressTxt.Clear();
                        companyEmailTxt.Clear();

                    }
                    else
                    {
                        MessageBox.Show("Fournisseur Non Ajouter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Alert("Cet Fournisseur n'est pas Ajouter !", FormAlert.enumType.Info);

                    }
                }
                else if (fournisseur.verifcationFournisseur(email))
                {
                    MessageBox.Show("On a Deja un Contrat avec cet fournisseur", " Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Alert("Cet Fournisseur existe !", FormAlert.enumType.Info);

                }

                loadfournisseur();

                
            }
        }

        public void Clear()
        {
            if (companyNameTxt.Text == "" || companyPhoneNumberTxt.Text == "" || companyAddressTxt.Text == "" || companyEmailTxt.Text == "")
            {
                MessageBox.Show("les champs sont deja vide  !");
                this.Alert("Saisir les champs !", FormAlert.enumType.Info);

            }
            else { 
                companyEmailTxt.Clear();
                companyNameTxt.Clear();
                companyPhoneNumberTxt.Clear();
                companyAddressTxt.Clear();
            }
        }
        private void buttonEditCompany_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void afficherTable()
        {
            guna2DataGridView1.DataSource = getFournisseur();
        }

        private void afficherNombreFournisseur()
        {
            if (guna2DataGridView1.Rows.Count > 0)
            {
                int nombre = Convert.ToInt32(guna2DataGridView1.Rows.Count);
                if (nombre <= 1)
                {
                    labelFournisseur.Text = "FOURNISSEUR : " + guna2DataGridView1.Rows.Count.ToString();
                }
                else
                {
                    labelFournisseur.Text = "FOURNISSEURS  : " + guna2DataGridView1.Rows.Count.ToString();

                }
            }
            else
            {
                labelFournisseur.Text = "FOURNISSEUR  : " + "0";

            }
        }

        private object getFournisseur()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `fournisseur` ", db.GetConnection);
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);

            return table;
        }

        private void loadfournisseur()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `fournisseur` ", db.GetConnection);
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            db.closeConnection();
            guna2DataGridView1.DataSource = table;
        }

        private void companyPhoneNumberTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxcompanyPhoneNumber_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxcompanyPhoneNumber_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void companyPhoneNumberTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Le contact est Numerique", " Error");
                this.Alert("Saisir une valeur !", FormAlert.enumType.Info);


            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                companyIdTxt.Text = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                companyNameTxt.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                companyPhoneNumberTxt.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                companyAddressTxt.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                companyEmailTxt.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fournisseur System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Alert("Fournisseur System !", FormAlert.enumType.Info);

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (companyNameTxt.Text == "" || companyPhoneNumberTxt.Text == "" || companyAddressTxt.Text == "" || companyEmailTxt.Text == "")
            {
                MessageBox.Show("les champs sont vide  !");
                this.Alert("Saisir les champs !", FormAlert.enumType.Info);

            }
            else { 

                int id = Convert.ToInt32(companyIdTxt.Text.Trim());
            
                if(MessageBox.Show("Etes vous de vouloir Supprimer ..?","Remove",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (fournisseur.supprimerFournisseur(id))
                    {
                        MessageBox.Show("Fournisseur Supprimer avec succes", "Information ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Alert("Cet Fournisseur est Supprimer !", FormAlert.enumType.Success);
                        companyNameTxt.Clear();
                        companyPhoneNumberTxt.Clear();
                        companyAddressTxt.Clear();
                        companyEmailTxt.Clear();

                    }
                    else
                    {
                        MessageBox.Show("Fournisseur Non Supprimer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Alert("Cet Fournisseur n'est pas Supprimer !", FormAlert.enumType.Info);

                    }
                }
           

                loadfournisseur();
            }

        }
        private void guna2DataGridView1_ColumnHeadersDefaultCellStyleChanged(object sender, EventArgs e)
        {

        }

        private void Fournisseur_Click(object sender, EventArgs e)
        {

        }

        private void labelFournisseur_Click(object sender, EventArgs e)
        {

        }
    }
}