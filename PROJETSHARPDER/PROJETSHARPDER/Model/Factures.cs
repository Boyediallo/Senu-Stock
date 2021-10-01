using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace PROJETSHARPDER
{
    class Factures
    {
        DataBaseHelper db = new DataBaseHelper();

        public bool ajouterFacture(string produit, string date, int quantite, string Company)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `facture`(`produit`,`date`, `quantite`,`Company`) VALUES (@produit,@date,@quantite,@Company)", db.GetConnection);
            command.Parameters.Add("@produit", MySqlDbType.VarChar).Value = produit;
            command.Parameters.Add("@date", MySqlDbType.VarChar).Value = date;
            command.Parameters.Add("@quantite", MySqlDbType.Int32).Value = quantite;
            command.Parameters.Add("@Company", MySqlDbType.VarChar).Value = Company;


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

        public bool modifierFacture(int id, string produit, string date, int quantite, string Company)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `facture` SET `id`=@id,`produit`=@produit,`date`=@date,`quantite`=@quantite,`Company`=@Company  WHERE `id`=@id", db.GetConnection);

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@produit", MySqlDbType.VarChar).Value = produit;
            command.Parameters.Add("@date", MySqlDbType.VarChar).Value = date;
            command.Parameters.Add("@quantite", MySqlDbType.Int32).Value = quantite;
            command.Parameters.Add("@Company", MySqlDbType.VarChar).Value = Company;

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

        public bool supprimerFacture(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `facture` WHERE `id`=@id", db.GetConnection);
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
