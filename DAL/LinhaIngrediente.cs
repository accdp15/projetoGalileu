using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LinhaIngrediente
    {
        public int ReceitaID { get; set; }

        public Ingrediente Ingrediente { get; set; }

        public int IngredienteID { get { return this.Ingrediente.IngredienteID; } }
        public string IngredienteNome { get { return this.Ingrediente.NomeIngrediente; } }

        public Unidade Unidade { get; set; }
        public int UnidadeID { get { return this.Unidade.UnidadeID; } }

        public string UnidadeNome {  get { return this.Unidade.NomeUnidade; } }

        public double Quantidade { get; set; }

        public LinhaIngrediente()
        {
            this.Ingrediente = new Ingrediente();
            this.Unidade = new Unidade();
        }

        public void Inserir(SqlConnection sqlConnection, SqlTransaction transaccion)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.InserirLineaIngrediente";
            sqlCommand.Parameters.AddWithValue("@ReceitaID", this.ReceitaID);
            sqlCommand.Parameters.AddWithValue("@IngredienteID", this.Ingrediente.IngredienteID);
            sqlCommand.Parameters.AddWithValue("@UnidadeID", this.Unidade.UnidadeID);
            sqlCommand.Parameters.AddWithValue("@Quantidade", this.Quantidade);


            sqlCommand.Transaction = transaccion;
            sqlCommand.ExecuteNonQuery();

            //No estamos haciendo try/catch por lo que si ocurre un fallo, la exception es enviada automaticamente al codigo que ejecuto el metodo ApagarIngredientesDeLaReceta, en este case el metodo Inserir del DAL Receita
        }

        public static void ApagarIngredientesDeLaReceta(int receitaID, SqlConnection sqlConnection, SqlTransaction transaccion)
        {
            SqlCommand eliminarIngredientesAntiguos = new SqlCommand();
            eliminarIngredientesAntiguos.Connection = sqlConnection;
            eliminarIngredientesAntiguos.CommandType = System.Data.CommandType.StoredProcedure;
            eliminarIngredientesAntiguos.CommandText = "dbo.ApagarIngredientesAntigos";
            eliminarIngredientesAntiguos.Parameters.AddWithValue("@ReceitaID", receitaID);

            try
            {
                eliminarIngredientesAntiguos.Transaction = transaccion;
                eliminarIngredientesAntiguos.ExecuteNonQuery(); //aca se ejecuta el comando (lo que hicimos alla arriba de SQLCOMMAND)
            }
            catch (Exception e)
            {
                throw e; //Lanza la exception al codigo que ejecuto el metodo ApagarIngredientesDeLaReceta, en este case el metodo Atualizar del DAL Receita
            }
        }

        public static List<LinhaIngrediente> LerIngredientes(int receitaID)
        {
            List<LinhaIngrediente> listaIngredientes = new List<LinhaIngrediente>();
            
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand lerIngredientesCommand = new SqlCommand();
            lerIngredientesCommand.Connection = sqlConnection;
            lerIngredientesCommand.CommandType = System.Data.CommandType.StoredProcedure;
            lerIngredientesCommand.CommandText = "dbo.LerLinhaIngredientes";
            lerIngredientesCommand.Parameters.AddWithValue("@ReceitaID", receitaID);

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = lerIngredientesCommand.ExecuteReader();

                while (reader.Read())
                {
                    LinhaIngrediente ingrediente = new LinhaIngrediente();

                    ingrediente.ReceitaID = reader.GetInt32(0);
                    ingrediente.Ingrediente.IngredienteID = reader.GetInt32(1);
                    ingrediente.Ingrediente.NomeIngrediente = reader.GetString(2);
                    ingrediente.Unidade.UnidadeID = reader.GetInt32(3);
                    ingrediente.Unidade.NomeUnidade = reader.GetString(4);
                    ingrediente.Quantidade = reader.GetInt32(5);

                    listaIngredientes.Add(ingrediente);
                }

                sqlConnection.Close();
            }
            catch (Exception)
            {


            }

            return listaIngredientes;
        }
    }
}
