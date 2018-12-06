using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bean;

namespace ServiceDA
{
    public class DAJalon
    {
        SqlConnection connection = new SqlConnection("Data Source=MSI;Initial Catalog=SuiviProjet;Integrated Security=True");

        public bool InsertJalon(CJalon jalon)
        {
            bool bRet = false;
            connection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = connection;
            myCommand.CommandText = "INSERT INTO TJalon ([TJal_Libelle],[TJal_DateLivraisonPrevue],[TJal_FK_TTri],[TJal_DateLivraisonReel],[TJal_FK_TPro]) VALUES (@TJal_Libelle,@TJal_DateLivraisonPrevue,@TJal_FK_TTri,@TJal_DateLivraisonReel,@TJal_FK_TPro)";
            myCommand.Parameters.Add(new SqlParameter("@TJal_Libelle", jalon.jal_libelle));
            myCommand.Parameters.Add(new SqlParameter("@TJal_DateLivraisonPrevue", jalon.jal_dateLivraisonPrevue));
            myCommand.Parameters.Add(new SqlParameter("@TJal_FK_TTri", jalon.jal_responsable));
            myCommand.Parameters.Add(new SqlParameter("@TJal_DateLivraisonReel", jalon.jal_dateLivraisonReel));
            myCommand.Parameters.Add(new SqlParameter("@TJal_FK_TPro", jalon.jal_projet));
            if (myCommand.ExecuteNonQuery() > 0)
            {
                bRet = true;
            }

            connection.Close();

            return bRet;
        }

        public List<CJalon> GetAllJalon()
        {
            List<CJalon> listJalon = new List<CJalon>();

            connection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = connection;

            myCommand.CommandText = "SELECT [TJal_Id],[TJal_Libelle],[TJal_DateLivraisonPrevue],[TJal_FK_TTri],[TJal_DateLivraisonReel],[TJal_FK_TPro] FROM [TJalon] WHERE TJal_Actif = 1";

            SqlDataReader reader = myCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CJalon jalon = new CJalon((int)reader[0], reader[1].ToString(), reader[2].ToString(), (int)reader[3], reader[4].ToString(), (int)reader[5]);
                    listJalon.Add(jalon);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();

            connection.Close();

            return listJalon;
        }

        public CJalon GetJalonById(int id)
        {
            CJalon jalon = null;

            connection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = connection;

            myCommand.CommandText = "SELECT [TJal_Id],[TJal_Libelle],[TJal_DateLivraisonPrevue],[TJal_FK_TTri],[TJal_DateLivraisonReel],[TJal_FK_TPro] FROM [TJalon] WHERE TJal_Id = @TJal_Id AND TJal_Actif = 1";
            myCommand.Parameters.Add(new SqlParameter("@TJal_Id", id));

            SqlDataReader reader = myCommand.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                jalon = new CJalon((int)reader[0], reader[1].ToString(), reader[2].ToString(), (int)reader[3], reader[4].ToString(), (int)reader[5]);
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();

            connection.Close();

            return jalon;
        }


        public List<CJalon> GetJalonForProjet(int idProjet)
        {
            List<CJalon> listJalon = new List<CJalon>();

            connection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = connection;

            myCommand.CommandText = "SELECT [TJal_Id],[TJal_Libelle],[TJal_DateLivraisonPrevue],[TJal_FK_TTri],[TJal_DateLivraisonReel],[TJal_FK_TPro] FROM [TJalon] WHERE TJal_FK_TPro = @idProjet AND TJal_Actif = 1";
            myCommand.Parameters.Add(new SqlParameter("@idProjet", idProjet));

            SqlDataReader reader = myCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CJalon jalon = new CJalon((int)reader[0], reader[1].ToString(), reader[2].ToString(), (int)reader[3], reader[4].ToString(), (int)reader[5]);
                    listJalon.Add(jalon);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();

            connection.Close();

            return listJalon;
        }

        public void DelJalon(int id)
        {

            connection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = connection;

            myCommand.CommandText = "UPDATE TJalon set TJal_Actif = 0 WHERE TJal_Id = @TJal_Id";
            myCommand.Parameters.Add(new SqlParameter("@TJal_Id", id));

            SqlDataReader reader = myCommand.ExecuteReader();
            reader.Close();

            connection.Close();
        }
    }
}
