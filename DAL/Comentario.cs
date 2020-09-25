using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Comentario
    {
        public int ComentarioID { get; set; }   

        public int UserID { get; set; }

        public int ReceitaID { get; set; }

        public DateTime DataPublicacao { get; set; }

        public string Texto { get; set; }

        public Comentario()
        {
        }

        public void Inserir()
        {
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.InserirComentario";
            sqlCommand.Parameters.AddWithValue("@UserID", this.UserID);
            sqlCommand.Parameters.AddWithValue(" @ReceitaID", this.ReceitaID);
            sqlCommand.Parameters.AddWithValue("@DataPublicacao", this.DataPublicacao);
            sqlCommand.Parameters.AddWithValue("@Texto", this.Texto);

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
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.AtualizarComentario";
            sqlCommand.Parameters.AddWithValue("@ComentarioID", this.ComentarioID);
            sqlCommand.Parameters.AddWithValue("@Texto", this.Texto);

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
      
        public void Apagar()
        {
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.ApagarComentario";
            sqlCommand.Parameters.AddWithValue("@ComentarioID", this.ComentarioID);

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
            sqlCommand.CommandText = "dbo.LerComentarios";
            sqlCommand.Parameters.AddWithValue("@ReceitaID", this.ReceitaID);

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();


                while (reader.Read())
                {
                    Comentario comentario = new Comentario();
                    comentario.ComentarioID = reader.GetInt32(0);
                    comentario.UserID = reader.GetInt32(1);
                    comentario.ReceitaID = reader.GetInt32(2);
                    comentario.DataPublicacao = reader.GetDateTime(3);
                    comentario.Texto = reader.GetString(4);
                }


                sqlConnection.Close();

            }
            catch (Exception)
            {


            }
        }

            
    }
}
