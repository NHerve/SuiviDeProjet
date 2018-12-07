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

        SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=SuiviProjet;Integrated Security=True");

        public bool InsertProjet(CProjet projet)
        {
            bool bRet = false;
            connection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = connection;
            myCommand.CommandText = "INSERT INTO TProjet ([TPro_Nom],[TPro_TriProjet],[TPro_FK_TTri]) VALUES (@TPro_Nom,@TPro_TriProjet,@TPro_FK_TTri)";
            myCommand.Parameters.Add(new SqlParameter("@TPro_Nom", projet.pro_nom));
            myCommand.Parameters.Add(new SqlParameter("@TPro_TriProjet", projet.pro_idTrigramme));
            myCommand.Parameters.Add(new SqlParameter("@TPro_FK_TTri", projet.pro_responsable));
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

            myCommand.CommandText = "SELECT [TPro_Id],[TPro_Nom],[TPro_TriProjet],[TPro_FK_TTri] FROM [TProjet] WHERE TPro_Actif = 1";

            SqlDataReader reader = myCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CProjet projet = new CProjet((int)reader[0], reader[1].ToString(), reader[2].ToString(), (int)reader[3]);
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

            myCommand.CommandText = "SELECT [TPro_Id],[TPro_Nom],[TPro_TriProjet],[TPro_FK_TTri] FROM [TProjet] WHERE TPro_Id = @TPro_Id AND TPro_Actif = 1";
            myCommand.Parameters.Add(new SqlParameter("@TPro_Id", id));

            SqlDataReader reader = myCommand.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                projet = new CProjet((int)reader[0], reader[1].ToString(), reader[2].ToString(), (int)reader[3]);
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();

            connection.Close();

            return projet;
        }

        public void DelProjet(int id)
        {

            connection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = connection;

            myCommand.CommandText = "UPDATE TProjet set TPro_Actif = 0 WHERE TPro_Id = @TPro_Id";
            myCommand.Parameters.Add(new SqlParameter("@TPro_Id", id));

            SqlDataReader reader = myCommand.ExecuteReader();
            reader.Close();

            connection.Close();
        }

    }
}
