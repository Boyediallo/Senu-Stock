using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace PROJETSHARPDER
{
    class AjoutManoeuvre1
    {

        DataBaseHelper db = new DataBaseHelper();

        public bool ajouterManoeuvre(string nom, string prenom, string telephone, string poste, string status, string salaire)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `manoeuvre`(`nom`, `prenom`, `telephone`, `poste`, `status`, `salaire`) VALUES (@nom,@prenom,@telephone,@poste,@status,@salaire)", db.GetConnection);
            command.Parameters.Add("@nom", MySqlDbType.VarChar).Value = nom;
            command.Parameters.Add("@prenom", MySqlDbType.VarChar).Value = prenom;
            command.Parameters.Add("@telephone", MySqlDbType.VarChar).Value = telephone;
            command.Parameters.Add("@poste", MySqlDbType.VarChar).Value = poste;
            command.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;
            command.Parameters.Add("@salaire", MySqlDbType.VarChar).Value = salaire;

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

        public bool modifierManoeuvre(int id, string nom, string prenom, string telephone, string poste, string status, string salaire)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `manoeuvre` SET `nom`=@nom,`prenom`=@prenom,`telephone`=@telephone,`poste`=@poste,`status`=@status,`salaire`=@salaire WHERE `id`=@id", db.GetConnection);

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@nom", MySqlDbType.VarChar).Value = nom;
            command.Parameters.Add("@prenom", MySqlDbType.VarChar).Value = prenom;
            command.Parameters.Add("@telephone", MySqlDbType.VarChar).Value = telephone;
            command.Parameters.Add("@poste", MySqlDbType.VarChar).Value = poste;
            command.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;
            command.Parameters.Add("@salaire", MySqlDbType.VarChar).Value = salaire;

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


        public bool verifcationManoeuvre(string telephone)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `manoeuvre` WHERE`telephone`=@telephone", db.GetConnection);
            command.Parameters.Add("@telephone", MySqlDbType.VarChar).Value = telephone;
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

        public bool supprimerManoeuvre(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `manoeuvre` WHERE `id`=@id", db.GetConnection);
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
