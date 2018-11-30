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

        public bool InsertTache(CTache tache)
        {
            bool bRet = false;
            connection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = connection;
            myCommand.CommandText = "INSERT INTO TTache ([TTac_Libelle],[TTac_Description],[TTac_Responsable],[TTac_DateDebutPrevue],[TTac_NbJours],[TTac_FK_TTac],[TTac_DateDebutReel],[TTac_Statut] ,[TTac_FK_TJal]) VALUES (@TTac_Libelle,@TTac_Description,@TTac_Responsable,@TTac_DateDebutPrevue,@TTac_NbJours,@TTac_FK_TTac,@TTac_DateDebutReel,@TTac_Statut ,@TTac_FK_TJal)";
            myCommand.Parameters.Add(new SqlParameter("@TTac_Libelle", tache.tac_libelle));
            myCommand.Parameters.Add(new SqlParameter("@TTac_Description", tache.tac_description));
            myCommand.Parameters.Add(new SqlParameter("@TTac_Responsable", tache.tac_responsable));
            myCommand.Parameters.Add(new SqlParameter("@TTac_DateDebutPrevue", tache.tac_dateDebutPrevue));
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

        public List<CTache> GetAllTache()
        {
            List<CTache> listTache = new List<CTache>();

            connection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = connection;

            myCommand.CommandText = "SELECT [TTac_Id],[TTac_Libelle],[TTac_Description],[TTac_Responsable],[TTac_DateDebutPrevue],[TTac_NbJours],[TTac_FK_TTac],[TTac_DateDebutReel],[TTac_Statut],[TTac_FK_TJal] FROM [TTache]";

            SqlDataReader reader = myCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CTache tache = new CTache((int)reader[0], reader[1].ToString(), reader[2].ToString(), (int)reader[3],(DateTime)reader[4],(int)reader[5], (int)reader[6], (DateTime)reader[7], (int)reader[8], (int)reader[9]);
                    listTache.Add(tache);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();

            connection.Close();

            return listTache;
        }

        public CTache GetTacheById(int id)
        {
            CTache tache = null;

            connection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = connection;

            myCommand.CommandText = "SELECT [TTac_Id],[TTac_Libelle],[TTac_Description],[TTac_Responsable],[TTac_DateDebutPrevue],[TTac_NbJours],[TTac_FK_TTac],[TTac_DateDebutReel],[TTac_Statut],[TTac_FK_TJal] FROM [TTache] WHERE TTac_Id = @TTac_Id";
            myCommand.Parameters.Add(new SqlParameter("@TTac_Id", id));

            SqlDataReader reader = myCommand.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                tache = new CTache((int)reader[0], reader[1].ToString(), reader[2].ToString(), (int)reader[3], (DateTime)reader[4], (int)reader[5], (int)reader[6], (DateTime)reader[7], (int)reader[8], (int)reader[9]);
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();

            connection.Close();

            return tache;
        }
    }
}
