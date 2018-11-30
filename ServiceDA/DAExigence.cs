using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bean;

namespace ServiceDA
{
    class DAExigence
    {
        SqlConnection connection = new SqlConnection("Data Source=MSI;Initial Catalog=SuiviProjet;Integrated Security=True");

        public bool InsertExigence(CExigence exigence)
        {
            bool bRet = false;
            connection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = connection;
            myCommand.CommandText = "INSERT INTO TExigence ([TExi_Description],[TExi_Type],[TExi_FK_TPro]) VALUES (@TExi_Description,@TExi_Type,@TExi_FK_TPro)";
            myCommand.Parameters.Add(new SqlParameter("@TExi_Description", exigence.exi_description));
            myCommand.Parameters.Add(new SqlParameter("@TExi_Type", exigence.exi_type));
            myCommand.Parameters.Add(new SqlParameter("@TExi_FK_TPro", exigence.exi_projet));
            if (myCommand.ExecuteNonQuery() > 0)
            {
                bRet = true;
            }

            connection.Close();

            return bRet;
        }

        public List<CExigence> GetAllExigence()
        {
            List<CExigence> listExigence = new List<CExigence>();

            connection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = connection;

            myCommand.CommandText = "SELECT [TExi_Id],[TExi_Description],[TExi_Type],[TExi_FK_TPro] FROM [TJalon]";

            SqlDataReader reader = myCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CExigence exigence = new CExigence((int)reader[0], reader[1].ToString(), (int)reader[2], (int)reader[3]);
                    listExigence.Add(exigence);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();

            connection.Close();

            return listExigence;
        }

        public CExigence GetExigenceById(int id)
        {
            CExigence exigence = null;

            connection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = connection;

            myCommand.CommandText = "SELECT [TExi_Id],[TExi_Description],[TExi_Type],[TExi_FK_TPro] FROM [TJalon] WHERE TExi_Id = @TExi_Id";
            myCommand.Parameters.Add(new SqlParameter("@TExi_Id", id));

            SqlDataReader reader = myCommand.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                exigence = new CExigence((int)reader[0], reader[1].ToString(), (int)reader[2], (int)reader[3]);
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();

            connection.Close();

            return exigence;
        }
    }
}
