using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinalGalileu
{
    public partial class frmGerirUnidades : Form
    {
        private Unidade _unidadeActiva; //atributo 

        public frmGerirUnidades()
        {
            InitializeComponent();
            _unidadeActiva = new Unidade();
            btnApagar.Enabled = false;
            btnAtualizar.Enabled = false;
            RefrescarTabla(); // aca antes tenia las lineas del metodo que ves mas abajo, pero lo sustityo por el metodo creado para no estar repitiendo el codigo
        }

        private void RefrescarTabla()
        {
            List<Unidade> lista = Unidade.LerUnidades();  //creamos la variable en este caso es una lisra pirque nuestro metodo devuelve una lista //a traves del DAL (la clase) llamamos el metodo que usamos para leer las unidades 
            dgvUnidade.DataSource = lista; //actualizamos nuestro dgv
        }

        private void dgvUnidade_CellClick(object sender, DataGridViewCellEventArgs e) // COMPORTAMIENTO DE NUESTRA TABLA esto es cuando estamos haciendo clic en una celda de la tabla dgv 
        {
            _unidadeActiva.UnidadeID = Convert.ToInt32(dgvUnidade[0, e.RowIndex].Value); // al objeto global se le asigna su propiedad y con esto estamos leyendo las columnas de la fila seleccionada y asignandoselo a las propiedades del objeto global
            _unidadeActiva.NomeUnidade = Convert.ToString(dgvUnidade[1, e.RowIndex].Value);
            // ahora vamos a actualizar nuestros text box referenciando al objeto global (_unidadeActiva)
            txtUnidade.Text = _unidadeActiva.NomeUnidade;
            btnApagar.Enabled = true;
            btnAtualizar.Enabled = true;
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            _unidadeActiva.Inserir(); //con mi objeto global llamo al metodo de mi BD inserir que llama al store procedure
            RefrescarTabla();
            btnApagar.Enabled = false;
            btnAtualizar.Enabled = false;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            _unidadeActiva.Atualizar();
            RefrescarTabla();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            _unidadeActiva.Apagar();
            RefrescarTabla();
            btnApagar.Enabled = false;
            btnAtualizar.Enabled = false;
        }

        private void txtUnidade_Leave(object sender, EventArgs e)
        {//es para que se asigne el valor a nuestro objeto global, es importante para que actualizar y apagar se actualicen 

            _unidadeActiva.NomeUnidade = txtUnidade.Text; //ahora a al text box, queremos que deje de estar activo (perder el foco) cuando alguien hace clic en otra parte de la pagina, y se actualiza mi objeto global con el valor del text box 

        }
    }
}
