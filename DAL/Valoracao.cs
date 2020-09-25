using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Valoracao
    {
        public int UserID { get; set; }

        public int Valor { get; set; }

        public int ReceitaID { get; set; }

        public Valoracao()
        {

        }

        public void Inserir()
        {
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.InserirValoracao";
            sqlCommand.Parameters.AddWithValue("@UserID", this.UserID);
            sqlCommand.Parameters.AddWithValue("@ReceitaID", this.ReceitaID);
            sqlCommand.Parameters.AddWithValue("@Valor", this.Valor);

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
            sqlCommand.CommandText = "dbo.AtualizarValoracao";
            sqlCommand.Parameters.AddWithValue("@UserID", this.UserID);
            sqlCommand.Parameters.AddWithValue("@ReceitaID", this.ReceitaID);
            sqlCommand.Parameters.AddWithValue("@Valor", this.Valor);

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
            sqlCommand.CommandText = "dbo.ApagarValoracao";
            sqlCommand.Parameters.AddWithValue("@UserID", this.UserID);
            sqlCommand.Parameters.AddWithValue("@ReceitaID", this.ReceitaID);

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
            sqlCommand.CommandText = "dbo.LerValoracoes";
            sqlCommand.Parameters.AddWithValue("@ReceitaID", this.ReceitaID);

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Valoracao valoracao = new Valoracao();
                    valoracao.ReceitaID = reader.GetInt32(0);
                    valoracao.Valor = reader.GetInt32(1);

                }

                sqlConnection.Close();
            }
            catch (Exception)
            {


            }
        }
    }
}
