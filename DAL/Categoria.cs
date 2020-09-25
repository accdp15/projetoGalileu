using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Categoria
    {
        public int CategoriaID { get; set; }
        public string Nome { get; set; }

        public Categoria() { }

        public void Inserir()
        {
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.InserirCategoria";
            sqlCommand.Parameters.AddWithValue("@Nome", this.Nome);

            try
            {
                sqlCommand.Connection.Open();

                sqlCommand.ExecuteNonQuery();

                sqlCommand.Connection.Close();

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
            sqlCommand.CommandText = "dbo.AtualizarCategoria";
            sqlCommand.Parameters.AddWithValue("@Nome", this.Nome);
            sqlCommand.Parameters.AddWithValue("@CategoriaID", this.CategoriaID);

            try
            {
                sqlCommand.Connection.Open();

                sqlCommand.ExecuteNonQuery();

                sqlCommand.Connection.Close();
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
            sqlCommand.CommandText = "dbo.ApagarCategoria";
            sqlCommand.Parameters.AddWithValue("@CategoriaID", this.CategoriaID);

            try
            {
                sqlCommand.Connection.Open();

                sqlCommand.ExecuteNonQuery();

                sqlCommand.Connection.Close();
            }
            catch
            {

            }
            
        }

        public static List<Categoria> Ler()
        {
            List<Categoria> result = new List<Categoria>();

            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.LerCategorias";

            try
            {
                sqlCommand.Connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.CategoriaID = reader.GetInt32(0);
                    categoria.Nome = reader.GetString(1);
                    result.Add(categoria);

                }

                sqlCommand.Connection.Close();
            }
            catch
            {

            }
            return result;
            


        }





        

    }
    
    
}
