using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Dificuldade
    {
        public int DificuldadeID { get; set; }
        public string Nivel { get; set; }

        public Dificuldade() { }

        public bool Inserir()
        {
            bool result = true;
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.InserirDificuldade";
            sqlCommand.Parameters.AddWithValue("@Nivel", this.Nivel);

            try
            {
                sqlConnection.Open();
                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                sqlConnection.Close();
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public bool Atualizar()
        {
            bool result = true;

            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.AtualizarDificuldade";
            sqlCommand.Parameters.AddWithValue("@Nivel", this.Nivel);
            sqlCommand.Parameters.AddWithValue("@DificuldadeID", this.DificuldadeID);

            try
            {
                sqlConnection.Open();
                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                sqlConnection.Close();
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public static bool ApagarById(int id)
        {
            bool result = true;

            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "dbo.ApagarDificuldade";
            command.Parameters.AddWithValue("@DificuldadeID", id);

            try 
            {
                sqlConnection.Open();
                if (command.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                sqlConnection.Close();
            } 
            catch(Exception)
            {
                result = false;
            }

            return result;
        }

        public bool Apagar()
        {
            return ApagarById(this.DificuldadeID);
        }

        public static List<Dificuldade> LerDificuldades()
        {
            List<Dificuldade> result = new List<Dificuldade>();
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = sqlConnection;
            sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcommand.CommandText = "dbo.LerDificuldades";

            try
            {
                sqlConnection.Open();
                SqlDataReader tablaResultado = sqlcommand.ExecuteReader();

                while(tablaResultado.Read())
                {
                    Dificuldade dificuldade = new Dificuldade();
                    dificuldade.DificuldadeID = tablaResultado.GetInt32(0);
                    dificuldade.Nivel = tablaResultado.GetString(1);
                    result.Add(dificuldade);
                }
                sqlConnection.Close();
            }
            catch (Exception)
            {
                result = null;
            }    

            return result;

        }
    }
}
