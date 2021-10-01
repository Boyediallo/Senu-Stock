using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace PROJETSHARPDER
{
    class DataBaseHelper
    {
        // Connection in DataBase
        private MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=sunustock");

        //isibiliter de l'objet De la connection
        public MySqlConnection GetConnection
        {
            get
            {
                return connection;
            }
            set { }

        }
        //Open connection
        public void openConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        //Close the connection in database
        public void closeConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
} 
