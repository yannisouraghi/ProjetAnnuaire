using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;

namespace ProjetAnnuaire
{
    class SQLConnector
    {
        private SqlConnection? conn;

        public SqlConnection? SQLConnect()
        {
            try
            {
                string connectionString = "Data Source=PTP-IV-SQL01P;Initial Catalog=royplate;User ID=royplate;Password=milton12456!;Trusted_Connection=no;";
                conn = new SqlConnection(connectionString);

                if (conn != null)
                {
                    conn.Open();
                }
                else
                {
                    // Gérer le cas où conn est null (optionnel)
                    MessageBox.Show("La connexion est null.");
                }
                MessageBox.Show("Connexion réussie");
                return conn;
            }
            catch (SqlException)
            {
                MessageBox.Show("Erreur de connexion à la base de données");
            }

            return null;
        }
    }
}
