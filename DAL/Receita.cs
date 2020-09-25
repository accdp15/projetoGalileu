using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class Receita
    {
        public int ReceitaID { get; set; }

        public int UserID { get; set; }

        public Categoria Categoria { get; set; }

        //Propiedad con comportamiento
        private string _nome;

        public string Nome
        {
            get
            {
                return _nome.ToLowerInvariant();
            }
            set
            {
                string valorTransformado = value;
                // Remueve espacios al inicio y al final
                valorTransformado = valorTransformado.Trim();
                // Transforma el text a minusculas
                valorTransformado = valorTransformado.ToLower();
                // Remueve los espacios sobrantes en medio del text
                string[] arregloDePalabras = valorTransformado.Split(' ');
                valorTransformado = string.Join(" ", arregloDePalabras);
                _nome = valorTransformado;
            }
        }

        public string Descripcao { get; set; }

        public int Duracao { get; set; }

        public int QuantidadeComensales { get; set; }

        public Dificuldade Dificuldade { get; set; }

        public DateTime DataPublicacao { get; set; }

        public bool Status { get; set; }

        public List<LinhaIngrediente> IngredientesReceita;

        public Receita()
        {
            this.Categoria = new Categoria();
            this.Dificuldade = new Dificuldade();
            this.IngredientesReceita = new List<LinhaIngrediente>();
        }
        
        public void Inserir()
        {
            int receitaID = -1;
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlTransaction transaction;

            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.InserirReceita";
            sqlCommand.Parameters.AddWithValue("@UserID", this.UserID);
            sqlCommand.Parameters.AddWithValue("@CategoriaID", this.Categoria.CategoriaID);
            sqlCommand.Parameters.AddWithValue("@Nome", this.Nome);
            sqlCommand.Parameters.AddWithValue("@Descripcao", this.Descripcao);
            sqlCommand.Parameters.AddWithValue("@QuantidadeComensales", this.QuantidadeComensales);
            sqlCommand.Parameters.AddWithValue("@DificuldadeID", this.Dificuldade.DificuldadeID);
            sqlCommand.Parameters.AddWithValue("@Duracao", this.Duracao);

            try
            {
                sqlCommand.Connection.Open();
                transaction = sqlCommand.Connection.BeginTransaction("CrearReceita");
                try
                {
                    sqlCommand.Transaction = transaction;
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        receitaID = reader.GetInt32(0); //el 0 es la 1ra columna de la linea actual
                    }
                    reader.Close();
                    
                    if (receitaID > 0) 
                    {
                        foreach (LinhaIngrediente item in this.IngredientesReceita) //recorremos la lista de ingredientes, en c/vuelta estamos posicionados en un elemtno de la lista, el elemento esta guardado en la variable item
                        {
                            item.ReceitaID = receitaID;
                            item.Inserir(sqlConnection, transaction);

                        }// con esto del foreach estamos haciendo primero insertar la receta para tener el receitaID para que el objeto de la clase lineaingredientes pueda insertarse 
                    }
                    transaction.Commit();
                }
                catch (Exception e1)
                {
                    transaction.Rollback();
                }
                
                sqlCommand.Connection.Close();
            }
            catch(Exception e2)
            {
            }
        }

        public void Atualizar()
        {
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);

            //Ejecutar AtualizarReceita
            SqlCommand atualizarReceitaCommand = new SqlCommand();
            SqlTransaction transaction;
            atualizarReceitaCommand.Connection = sqlConnection;
            atualizarReceitaCommand.CommandType = System.Data.CommandType.StoredProcedure;
            atualizarReceitaCommand.CommandText = "dbo.AtualizarReceita";
            atualizarReceitaCommand.Parameters.AddWithValue("@ReceitaID", this.ReceitaID);
            atualizarReceitaCommand.Parameters.AddWithValue("@UserID", this.UserID);
            atualizarReceitaCommand.Parameters.AddWithValue("@CategoriaID", this.Categoria.CategoriaID);
            atualizarReceitaCommand.Parameters.AddWithValue("@Nome", this.Nome);
            atualizarReceitaCommand.Parameters.AddWithValue("@Descripcao", this.Descripcao);
            atualizarReceitaCommand.Parameters.AddWithValue("@QuantidadComensales", this.QuantidadeComensales);
            atualizarReceitaCommand.Parameters.AddWithValue("@DificuldadeID", this.Dificuldade.DificuldadeID);
            atualizarReceitaCommand.Parameters.AddWithValue("@Status", this.Status);
            atualizarReceitaCommand.Parameters.AddWithValue("@Duracao", this.Duracao);

            try
            {
                sqlConnection.Open();
                transaction = atualizarReceitaCommand.Connection.BeginTransaction("AtualizarReceita");

                try
                {
                    // Descarta (elimina) la lista antigua de ingredientes guardados en la base de datos
                    LinhaIngrediente.ApagarIngredientesDeLaReceta(this.ReceitaID, sqlConnection, transaction); // entre los ( ) estamos pasando el valor de receita ID del objeto receta que ejecuta la funcion actualizar // esta linea viene de un metodo statico que hicimos en la clase lineingrediente

                    // Actualiza solo la tabla Receita

                    atualizarReceitaCommand.Transaction = transaction;
                    atualizarReceitaCommand.ExecuteNonQuery();

                    // Inserta nuevos registros en la tabla LinhaIngrediente
                    foreach (LinhaIngrediente item in this.IngredientesReceita)
                    {
                        item.Inserir(sqlConnection, transaction);
                    }

                    transaction.Commit();

                    sqlConnection.Close();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
            catch
            {
            }

        }

        public void Apagar()
        {
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand apagarReceitaCommand = new SqlCommand();
            SqlTransaction transaction;
            apagarReceitaCommand.Connection = sqlConnection;
            apagarReceitaCommand.CommandType = System.Data.CommandType.StoredProcedure;
            apagarReceitaCommand.CommandText = "dbo.ApagarReceita";
            apagarReceitaCommand.Parameters.AddWithValue("@ReceitaID", this.ReceitaID);

            try
            {
                sqlConnection.Open();
                transaction = apagarReceitaCommand.Connection.BeginTransaction("ApagarReceita");

                try
                {
                    LinhaIngrediente.ApagarIngredientesDeLaReceta(this.ReceitaID, sqlConnection, transaction); // entre los ( ) estamos pasando el valor de receita ID del objeto receta que ejecuta la funcion actualizar // esta linea viene de un metodo statico que hicimos en la clase lineingrediente

                    apagarReceitaCommand.Transaction = transaction;
                    apagarReceitaCommand.ExecuteNonQuery();

                    transaction.Commit();

                    sqlConnection.Close();
                }
                catch {
                    transaction.Rollback();
                }
            }
            catch (Exception)
            {

            }
            

            
        }

        public static List<Receita> Ler()
        {
            List<Receita> listaReceitas = new List<Receita>();

            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand leerReceitasCommand = new SqlCommand();
            leerReceitasCommand.Connection = sqlConnection;
            leerReceitasCommand.CommandType = System.Data.CommandType.StoredProcedure;
            leerReceitasCommand.CommandText = "dbo.LerReceitas";

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = leerReceitasCommand.ExecuteReader();

                while(reader.Read())
                {
                    Receita receita = new Receita(); //creamos objeto receta y le asignamos los valores de la linea q se lee en el momento
                    // a continuacion los valores:
                    receita.ReceitaID = reader.GetInt32(0);
                    receita.UserID = reader.GetInt32(1);
                    receita.Categoria.CategoriaID = reader.GetInt32(2);
                    receita.Categoria.Nome = reader.GetString(3);
                    receita.Nome = reader.GetString(4);
                    receita.Descripcao = reader.GetString(5);
                    receita.QuantidadeComensales = reader.GetInt32(6);
                    receita.Dificuldade.DificuldadeID = reader.GetInt32(7);
                    receita.Dificuldade.Nivel = reader.GetString(8);
                    receita.DataPublicacao = reader.GetDateTime(9);
                    receita.Status = reader.GetBoolean(10);
                    receita.Duracao = reader.GetInt32(11);
                    /*
                     * A nuestro objeto receita todavia le falta darle un valor a la propiedad IngredientesReceita que es de la clase List<LinhaIngrediente>
                     * Quien se encarga de consultar/insertar/actualizar/etc la tabla de base de datos LinhaIngrediente is la clase LinhaIngrediente
                     * Es por eso que se tuvo que crear una funcion en dicha clase para ejecutar el store procedure dbo.LerLinhaIngredientes
                     */
                    receita.IngredientesReceita = LinhaIngrediente.LerIngredientes(receita.ReceitaID); 

                    listaReceitas.Add(receita);
                }

                sqlConnection.Close();
            }
            catch (Exception)
            {


            }

            return listaReceitas;
        }

        public static List<Receita> LerReceitasPorNome(string nome) //parametro porque no estamos llamando la funcion a traves del objeto sino de la clase, por lo tanto no hay un  THIS
        {
            List<Receita> ListaReceitasPorNome = new List<Receita>();

            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.LerReceitaPorNomeReceita";
            sqlCommand.Parameters.AddWithValue("@Nome", nome); //

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader(); 

                while (reader.Read())
                {
                    Receita receita = new Receita();

                    receita.ReceitaID = reader.GetInt32(0);
                    receita.Nome = reader.GetString(1);

                    ListaReceitasPorNome.Add(receita);
                }

                sqlConnection.Close();
            }
            catch (Exception e)
            {

               
            }

            return ListaReceitasPorNome;
        }

        public static List<Receita> LerReceitasPorNomeIngrediente(string Nome)
        {
            List<Receita> ListaRecetaPorIngred = new List<Receita>();

            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.LerReceitaPorNomeIngrediente"; 
            sqlCommand.Parameters.AddWithValue("@NomeIngrediente", Nome);

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Receita receita = new Receita();

                    receita.ReceitaID = reader.GetInt32(0);
                    receita.Nome = reader.GetString(1);

                    ListaRecetaPorIngred.Add(receita);
                }


                sqlConnection.Close();
            }
            catch (Exception)
            {

                
            }


            return ListaRecetaPorIngred;
        }

        public static List<Receita> LerReceitasPorCategoria(string nome)
        {
            List<Receita> ListaPorCateg = new List<Receita>();

            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.LerReceitaPorNomeCategoria";
            sqlCommand.Parameters.AddWithValue("@Nome", nome);

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Receita receita = new Receita();
                    receita.ReceitaID = reader.GetInt32(0);
                    receita.Nome = reader.GetString(1);

                    ListaPorCateg.Add(receita);

                }

                sqlConnection.Close();
            }
            catch (Exception)
            {

                
            }


            return ListaPorCateg;
        }

       

    }
}
