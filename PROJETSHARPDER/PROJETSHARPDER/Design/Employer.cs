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
    public partial class Manoeuvre : Form
    {
        public Manoeuvre()
        {
            InitializeComponent();
        }
        DataBaseHelper db = new DataBaseHelper();
        Manoeuvres manoeuvres = new Manoeuvres();

        public void Alert(string message, FormAlert.enumType type)
        {
            FormAlert formAlert = new FormAlert();
            formAlert.showAlert(message, type);
        }


        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Home back = new Home();
            back.Show();

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (employerNameTxt.Text == "" || employerPrenomTxt.Text == "" || employerNumberTxt.Text == "" || employerPosteTxt.Text == "" || employerEtatTxt.Text == "" || employerSalaireTxt.Text == "")
            {
                MessageBox.Show("Saisir les champs  !");
                this.Alert("Saisir les champs !", FormAlert.enumType.Info);

            }
            else
            {

                string nom = employerNameTxt.Text.Trim();
                string prenom = employerPrenomTxt.Text.Trim();
                string telephone = employerNumberTxt.Text.Trim();
                string poste = employerPosteTxt.Text.Trim();
                string status = employerEtatTxt.Text.Trim();
                string salaire = employerSalaireTxt.Text.Trim();
                string image = PicturesImage.GetType().ToString();

                if (!manoeuvres.verifcationManoeuvre(telephone))
                {

                    if (manoeuvres.ajouterManoeuvre(nom, prenom, telephone, poste, status, salaire,image))
                    {
                        MessageBox.Show("Employer Ajouter avec succes", "Information ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Alert("Cet Employer est Ajouter !", FormAlert.enumType.Success);
                        employerNameTxt.Clear();
                        employerPrenomTxt.Clear();
                        employerNumberTxt.Clear();
                        employerPosteTxt.Text = "";
                        employerEtatTxt.Text = "";
                        employerSalaireTxt.Text = "";


                    }
                    else
                    {
                        MessageBox.Show("Employer Non Ajouter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Alert("Cet Employer n'est pas Modifier !", FormAlert.enumType.Info);

                    }
                }
                else if (manoeuvres.verifcationManoeuvre(telephone))
                {
                    MessageBox.Show("Il est deja employer", " Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Alert("Cet Employer existe !", FormAlert.enumType.Info);

                }
                loadManoeuvre();
            }
            
        }

        private void Manoeuvre_Load(object sender, EventArgs e)
        {
            afficherTable();
            afficherNombreEmployer();
        }

        private void afficherNombreEmployer()
        {
            if (guna2DataGridView1.Rows.Count > 0)
            {
                int nombre = Convert.ToInt32(guna2DataGridView1.Rows.Count);
                if (nombre <= 1)
                {
                    labelEmployer.Text = "EMPLOYER : " + guna2DataGridView1.Rows.Count.ToString();
                }
                else
                {
                    labelEmployer.Text = "EMPLOYERS  : " + guna2DataGridView1.Rows.Count.ToString();

                }
            }
            else
            {
                labelEmployer.Text = "EMPLOYER  : " + "0";

            }
        }

        private void afficherTable()
        {
            guna2DataGridView1.DataSource = getManoeuvre();
        }
        private object getManoeuvre()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `manoeuvre` ", db.GetConnection);
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            guna2DataGridView1.RowTemplate.Height = 120;
            guna2DataGridView1.AllowUserToAddRows = false;
            table.Load(reader);
            guna2DataGridView1.DataSource = table;
            return table;
        }

        

               private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                employerIdTxt.Text = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                employerNameTxt.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                employerPrenomTxt.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                employerNumberTxt.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                employerPosteTxt.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                employerEtatTxt.Text = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                employerSalaireTxt.Text = guna2DataGridView1.SelectedRows[0].Cells[6].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Produit System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Alert("Produit System!", FormAlert.enumType.Info);

            }
        }

        private void employerIdTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void loadManoeuvre()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `manoeuvre` ", db.GetConnection);
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            db.closeConnection();
            guna2DataGridView1.DataSource = table;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (employerNameTxt.Text == "" || employerPrenomTxt.Text == "" || employerNumberTxt.Text == "" || employerPosteTxt.Text == "" || employerEtatTxt.Text == "" || employerSalaireTxt.Text == "")
            {
                MessageBox.Show("les champs sont vide !");
                this.Alert("Saisir les champs !", FormAlert.enumType.Info);

            }
            else
            {
                int id = Convert.ToInt32(employerIdTxt.Text.Trim());
                string nom = employerNameTxt.Text.Trim();
                string prenom = employerPrenomTxt.Text.Trim();
                string telephone = employerNumberTxt.Text.Trim();
                string poste = employerPosteTxt.Text.Trim();
                string status = employerEtatTxt.Text.Trim();
                string salaire = employerSalaireTxt.Text.Trim();
                string image = PicturesImage.ToString();

                if (manoeuvres.modifierManoeuvre(id, nom, prenom, telephone, poste, status, salaire, image))
                {
                    MessageBox.Show("Employer Modifier avec succes", "Information ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Alert("Cet Employer est Modifier !", FormAlert.enumType.Success);
                    employerNameTxt.Clear();
                    employerPrenomTxt.Clear();
                    employerNumberTxt.Clear();
                    employerPosteTxt.Text = "";
                    employerEtatTxt.Text = "";
                    employerSalaireTxt.Text = "";

                }
                else
                {
                    MessageBox.Show("Employer Non Modifier", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Alert("Ressayer de Modifier !", FormAlert.enumType.Info);

                }



                loadManoeuvre();
            }
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            if (employerNameTxt.Text == "" || employerPrenomTxt.Text == "" || employerNumberTxt.Text == "" || employerPosteTxt.Text == "" || employerEtatTxt.Text == "" || employerSalaireTxt.Text == "")
            {
                MessageBox.Show("les champs sont deja vide !");
                this.Alert("Saisir les champs !", FormAlert.enumType.Info);

            }
            else
            {
                employerIdTxt.Clear();
                employerNameTxt.Clear();
                employerPrenomTxt.Clear();
                employerNumberTxt.Clear();
                employerPosteTxt.Text = "";
                employerEtatTxt.Text = "";
                employerSalaireTxt.Text = "";
            }
        }

        private void employerNameTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void employerNumberTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Le contact est Numerique", " Error");
                this.Alert("Saisir une valeur Numerique !", FormAlert.enumType.Info);


            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (employerNameTxt.Text == "" || employerPrenomTxt.Text == "" || employerNumberTxt.Text == "" || employerPosteTxt.Text == "" || employerEtatTxt.Text == "" || employerSalaireTxt.Text == "")
            {
                MessageBox.Show("les champs sont vides  !");
                this.Alert("Saisir Les champs !", FormAlert.enumType.Info);

            }
            else
            {
                int id = Convert.ToInt32(employerIdTxt.Text.Trim());

                if (MessageBox.Show("Etes vous de vouloir Supprimer ..?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (manoeuvres.supprimerManoeuvre(id))
                    {
                        MessageBox.Show("Employer Supprimer avec succes", "Information ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Alert("Cet Employer est Supprimer !", FormAlert.enumType.Success);
                        employerIdTxt.Clear();
                        employerNameTxt.Clear();
                        employerPrenomTxt.Clear();
                        employerNumberTxt.Clear();
                        employerPosteTxt.Text = "";
                        employerEtatTxt.Text = "";
                        employerSalaireTxt.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Employer Non Supprimer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Alert("Cet Employer n'est pas Supprimer !", FormAlert.enumType.Info);

                    }
                }


                loadManoeuvre();
            }
        }
        private void UploadImage()
        {
            try
            {
                openFileDialog1.Filter = "JPG FILES(*.jpg)|*.jpg| PNG FILES(*.png)|*.png";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    PicturesImage.Image = Image.FromFile(openFileDialog1.FileName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de chargement d'image. \n" + ex.ToString(), "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void btnPhoto_Click(object sender, EventArgs e)
        {
            UploadImage();
        }

        private void Manoeuvre_Click(object sender, EventArgs e)
        {

        }
    }
}
