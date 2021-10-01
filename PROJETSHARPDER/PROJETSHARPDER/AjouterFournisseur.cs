using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PROJETSHARPDER
{
    class AjouterFournisseur
    {
        DataBaseHelper db = new DataBaseHelper();

        public bool ajouterFournisseur(string nomFournisseur, string telephone, string address, string email) {
            MySqlCommand command = new MySqlCommand("INSERT INTO `fournisseur`(`nomFournisseur`, `telephone`, `address`,`email`) VALUES (@nomFournisseur,@telephone,@address,@email)", db.GetConnection);
            command.Parameters.Add("@nomFournisseur",MySqlDbType.VarChar).Value = nomFournisseur;
            command.Parameters.Add("@telephone", MySqlDbType.VarChar).Value = telephone;
            command.Parameters.Add("@address", MySqlDbType.VarChar).Value = address;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            } else
            {
                db.closeConnection();
                return false;
            }

        }

        public bool modifierFounisseur(int id,string nomFournisseur, string telephone, string address, string email)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `fournisseur` SET `nomFournisseur`=@nomFournisseur,`telephone`=@telephone,`address`=@address,`email`=@email WHERE `id`=@id", db.GetConnection);

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@nomFournisseur", MySqlDbType.VarChar).Value = nomFournisseur;
            command.Parameters.Add("@telephone", MySqlDbType.VarChar).Value = telephone;
            command.Parameters.Add("@address", MySqlDbType.VarChar).Value = address;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }

        }

   
        public bool verifcationFournisseur(string email)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `fournisseur` WHERE`email`=@email", db.GetConnection);
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

        public bool supprimerFournisseur(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `fournisseur` WHERE `id`=@id", db.GetConnection);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }



    }
}