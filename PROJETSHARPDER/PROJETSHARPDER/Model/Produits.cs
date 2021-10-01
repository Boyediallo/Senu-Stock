using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace PROJETSHARPDER
{
    class Produits
    {
        DataBaseHelper db = new DataBaseHelper();

        public bool ajouterProduit(string nom, int prixAchat, int prixVente, int quantite,string date,string Company)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `produit`(`nom`, `prixAchat`, `prixVente`, `quantite`, `date`, `Company`) VALUES (@nom,@prixAchat,@prixVente,@quantite,@date,@Company)", db.GetConnection);
            command.Parameters.Add("@nom", MySqlDbType.VarChar).Value = nom;
            command.Parameters.Add("@prixAchat", MySqlDbType.Int32).Value = prixAchat;
            command.Parameters.Add("@prixVente", MySqlDbType.Int32).Value = prixVente;
            command.Parameters.Add("@quantite", MySqlDbType.Int32).Value = quantite;
            command.Parameters.Add("@date", MySqlDbType.VarChar).Value = date;
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

        public bool modifierProduit(int id, string nom, int prixAchat, int prixVente, int quantite, string date, string Company)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `produit` SET `nom`=@nom,`prixAchat`=@prixAchat,`prixVente`=@prixVente,`quantite`=@quantite,`date`=@date,`Company`=@Company WHERE `id`=@id", db.GetConnection);

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@nom", MySqlDbType.VarChar).Value = nom;
            command.Parameters.Add("@prixAchat", MySqlDbType.Int32).Value = prixAchat;
            command.Parameters.Add("@prixVente", MySqlDbType.Int32).Value = prixVente;
            command.Parameters.Add("@quantite", MySqlDbType.Int32).Value = quantite;
            command.Parameters.Add("@date", MySqlDbType.VarChar).Value = date;
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

        public bool verifcationProduit(string nom)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `produit` WHERE`nom`=@nom", db.GetConnection);
            command.Parameters.Add("@nom", MySqlDbType.VarChar).Value = nom;
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

        public bool supprimerProduit(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `produit` WHERE `id`=@id", db.GetConnection);
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
