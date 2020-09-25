using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Unidade
    {
        public int UnidadeID { get; set; }
        public string NomeUnidade { get; set; }

        public Unidade()
        {
        }

        public void Inserir()
        {
            
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.InserirUnidade";
            sqlCommand.Parameters.AddWithValue("@Nome", this.NomeUnidade);

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
            bool result = true;

            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.AtualizarUnidade";
            sqlCommand.Parameters.AddWithValue("@Nome", this.NomeUnidade);
            sqlCommand.Parameters.AddWithValue("@UnidadeID", this.UnidadeID);

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

        public void Apagar()
        {
            
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.ApagarUnidade";
            sqlCommand.Parameters.AddWithValue("@UnidadeID", this.UnidadeID);

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

        public static List<Unidade> LerUnidades()
        {
            List<Unidade> result = new List<Unidade>();

            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.LerUnidades";

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader(); // estamos creando una variable sqldatareader para guardar el resultado de la ejecucion de la funcion

                //Leemos la siguiente linea
                while (reader.Read() == true)
                {
                    //Creamos nuestro objeto unidade
                    Unidade unidade = new Unidade();
                    //Le asignamos los valores de la linea a las propiedades del objeto
                    unidade.UnidadeID = reader.GetInt32(0);
                    unidade.NomeUnidade = reader.GetString(1);
                    //Anadimos el objeto con los datos a la lista de unidades (la variable result contiene el objeto que guarda la lista)
                    result.Add(unidade); //unidade es el objeto con los datos

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
