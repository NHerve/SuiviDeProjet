using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bean;

namespace ServiceDA
{
    public class DAProjet
    {

        SqlConnection connection = new SqlConnection("Data Source=MSI;Initial Catalog=SuiviProjet;Integrated Security=True");

        public bool InsertProjet(CProjet projet)
        {
            bool bRet = false;
            connection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = connection;
            myCommand.CommandText = "INSERT INTO TProjet ([TPro_Nom],[TPro_Tri],[TPro_Responsable]) VALUES (@TPro_Nom,@TPro_Tri,@TPro_responsable)";
            myCommand.Parameters.Add(new SqlParameter("@TPro_Nom", projet.pro_nom));
            myCommand.Parameters.Add(new SqlParameter("@TPro_Tri", projet.pro_idTrigramme));
            myCommand.Parameters.Add(new SqlParameter("@TPro_responsable", projet.pro_responsable));
            if (myCommand.ExecuteNonQuery() > 0)
            {
                bRet = true;
            }

            connection.Close();

            return bRet;
        }

        public List<CProjet> GetAllProjet()
        {
            List<CProjet> listProjet = new List<CProjet>();

            connection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = connection;

            myCommand.CommandText = "SELECT [TPro_Id],[TPro_Nom],[TPro_Tri],[TPro_Responsable] FROM [TProjet]";

            SqlDataReader reader = myCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CProjet projet = new CProjet((int)reader[0], reader[1].ToString(), reader[2].ToString(), reader[3].ToString());
                    listProjet.Add(projet);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();

            connection.Close();

            return listProjet;
        }

        public CProjet GetProjetById(int id)
        {
            CProjet projet = null;

            connection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = connection;

            myCommand.CommandText = "SELECT [TPro_Id],[TPro_Nom],[TPro_Tri],[TPro_Responsable] FROM [TProjet] WHERE TPro_Id = @TPro_Id";
            myCommand.Parameters.Add(new SqlParameter("@TPro_Id", id));

            SqlDataReader reader = myCommand.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                projet = new CProjet((int)reader[0], reader[1].ToString(), reader[2].ToString(), reader[3].ToString());
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();

            connection.Close();

            return projet;
        }

    }
}
