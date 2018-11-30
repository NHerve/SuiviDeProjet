using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bean;

namespace ServiceDA
{
    class DATrigramme
    {
        SqlConnection connection = new SqlConnection("Data Source=MSI;Initial Catalog=SuiviProjet;Integrated Security=True");

        public bool InsertTache(CTrigramme trigramme)
        {
            bool bRet = false;
            connection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = connection;
            myCommand.CommandText = "INSERT INTO TTrigramme ([TTri_Trigramme]) VALUES (@TTri_Trigramme)";
            myCommand.Parameters.Add(new SqlParameter("@TTri_Trigramme", trigramme.tri_trigramme));
            if (myCommand.ExecuteNonQuery() > 0)
            {
                bRet = true;
            }

            connection.Close();

            return bRet;
        }

        public List<CTrigramme> GetAllTrigramme()
        {
            List<CTrigramme> listTrigramme = new List<CTrigramme>();

            connection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = connection;

            myCommand.CommandText = "SELECT [TTri_Id],[TTri_Trigramme] FROM [TTrigramme]";

            SqlDataReader reader = myCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CTrigramme trigramme = new CTrigramme((int)reader[0], reader[1].ToString());
                    listTrigramme.Add(trigramme);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();

            connection.Close();

            return listTrigramme;
        }

        public CTrigramme GetTrigrammeById(int id)
        {
            CTrigramme trigramme = null;

            connection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = connection;

            myCommand.CommandText = "SELECT [TTri_Id],[TTri_Trigramme] FROM [TTrigramme] WHERE TTri_Id = @TTri_Id";
            myCommand.Parameters.Add(new SqlParameter("@TTri_Id", id));

            SqlDataReader reader = myCommand.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                trigramme = new CTrigramme((int)reader[0], reader[1].ToString());
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();

            connection.Close();

            return trigramme;
        }
    }
}
