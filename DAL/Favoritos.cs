using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Favoritos
    {
        public int UserID { get; set; }

        public  Receita Receita { get; set; }

        public Favoritos()
        {

        }

        public void Inserir()
        {
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.InserirFavorito";
            sqlCommand.Parameters.AddWithValue("@UserID", this.UserID);
            sqlCommand.Parameters.AddWithValue("@ReceitaID", this.Receita.ReceitaID);


            try
            {
                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

            }
            catch (Exception)
            {


            }
        }

        public void Atualizar()
        {

        }

        public void Apagar()
        {
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.ApagarFavorito";
            sqlCommand.Parameters.AddWithValue("@UserID", this.UserID);
            sqlCommand.Parameters.AddWithValue("@ReceitaID", this.Receita.ReceitaID);


            try
            {
                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

            }
            catch (Exception)
            {


            }
        }

        public void Ler()
        {
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.LerFavoritos";
            sqlCommand.Parameters.AddWithValue("@UserID", this.UserID);

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Favoritos favoritos = new Favoritos();
                    favoritos.Receita.ReceitaID = reader.GetInt32(0);
                    favoritos.Receita.Nome = reader.GetString(1);
                }


                sqlConnection.Close();

            }
            catch (Exception)
            {


            }
        }
    }
}
