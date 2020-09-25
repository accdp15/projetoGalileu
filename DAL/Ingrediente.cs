using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Ingrediente
    {
        public int IngredienteID { get; set; }
        public string NomeIngrediente { get; set; }

        public Ingrediente()
        {

        }

        public void Inserir()
        {
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.InserirIngrediente";
            sqlCommand.Parameters.AddWithValue("@NomeIngrediente", this.NomeIngrediente);

            try
            {
                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
            catch
            {

            }


        }

        public void Atualizar()
        {

            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.AtualizarIngrediente";
            sqlCommand.Parameters.AddWithValue("@NomeIngrediente", this.NomeIngrediente);
            sqlCommand.Parameters.AddWithValue("@IngredienteID", this.IngredienteID);

            try
            {
                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
            catch
            {

            }

            

        }

        public void Apagar()
        {
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.ApagarIngrediente";
            sqlCommand.Parameters.AddWithValue("@IngredienteID", this.IngredienteID);

            try
            {
                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

            }
            catch
            {

            }
        }

        public static List<Ingrediente> Ler()
        {
            List<Ingrediente> result = new List<Ingrediente>();
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.LerIngredientes";

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Ingrediente ingrediente = new Ingrediente();
                    ingrediente.IngredienteID = reader.GetInt32(0);
                    ingrediente.NomeIngrediente = reader.GetString(1);
                    result.Add(ingrediente);
                }

                sqlConnection.Close();

            }
            catch(Exception e)
            {

            }

            return result;
        }
    }
}
