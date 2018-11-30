using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bean;

namespace ServiceDA
{
    class DATache
    {
        SqlConnection connection = new SqlConnection("Data Source=MSI;Initial Catalog=SuiviProjet;Integrated Security=True");

        public bool InsertJalon(CTache tache)
        {
            bool bRet = false;
            connection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = connection;
            myCommand.CommandText = "INSERT INTO TTache ([TTac_Libelle],[TTac_Description],[TTac_Responsable],[TTac_DateDebutTheorique],[TTac_NbJours],[TTac_FK_TTac],[TTac_DateDebutReel],[TTac_Statut] ,[TTac_FK_TJal]) VALUES (@TTac_Libelle,@TTac_Description,@TTac_Responsable,@TTac_DateDebutTheorique,@TTac_NbJours,@TTac_FK_TTac,@TTac_DateDebutReel,@TTac_Statut ,@TTac_FK_TJal)";
            myCommand.Parameters.Add(new SqlParameter("@TTac_Libelle", tache.tac_libelle));
            myCommand.Parameters.Add(new SqlParameter("@TTac_Description", tache.tac_description));
            myCommand.Parameters.Add(new SqlParameter("@TTac_Responsable", tache.tac_responsable));
            myCommand.Parameters.Add(new SqlParameter("@TTac_DateDebutTheorique", tache.tac_dateDebutTheorique));
            myCommand.Parameters.Add(new SqlParameter("@TTac_NbJours", tache.tac_nbJours));
            myCommand.Parameters.Add(new SqlParameter("@TTac_FK_TTac", tache.tac_tachePrecedente));
            myCommand.Parameters.Add(new SqlParameter("@TTac_DateDebutReel", tache.tac_dateDebutReel));
            myCommand.Parameters.Add(new SqlParameter("@TTac_Statut", tache.tac_statut));
            myCommand.Parameters.Add(new SqlParameter("@TTac_FK_TJal", tache.tac_jalon));
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

            myCommand.CommandText = "SELECT [TJal_Id],[TJal_Libelle],[TJal_DateLivraisonTheorique],[TJal_Responsable],[TJal_DateLivraisonReel],[TJal_FK_TPro] FROM [TJalon]";

            SqlDataReader reader = myCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CJalon jalon = new CJalon((int)reader[0], reader[1].ToString(), (DateTime)reader[2], reader[3].ToString(), (DateTime)reader[4], (int)reader[5]);
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

            myCommand.CommandText = "SELECT [TJal_Id],[TJal_Libelle],[TJal_DateLivraisonTheorique],[TJal_Responsable],[TJal_DateLivraisonReel],[TJal_FK_TPro] FROM [TJalon] WHERE TJal_Id = @TJal_Id";
            myCommand.Parameters.Add(new SqlParameter("@TJal_Id", id));

            SqlDataReader reader = myCommand.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                jalon = new CJalon((int)reader[0], reader[1].ToString(), (DateTime)reader[2], reader[3].ToString(), (DateTime)reader[4], (int)reader[5]);
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();

            connection.Close();

            return jalon;
        }
    }
}
