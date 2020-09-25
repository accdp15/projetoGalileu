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
    public partial class frmGerirIngredientes : Form
    {
        private Ingrediente _ingredienteActivo = new Ingrediente();

        public frmGerirIngredientes()
        {
            InitializeComponent();
            btnApagar.Enabled = false;
            btnAtualizar.Enabled = false;
            RefrescarTabla();
        }

        private void RefrescarTabla()
        {
            List<Ingrediente> lista = Ingrediente.Ler();
            dgvIngrediente.DataSource = lista;

        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            _ingredienteActivo.Inserir();
            RefrescarTabla();
            btnApagar.Enabled = false;
            btnAtualizar.Enabled = false;
          
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            _ingredienteActivo.Atualizar();
            RefrescarTabla();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            _ingredienteActivo.Apagar();
            RefrescarTabla();
            btnApagar.Enabled = false;
            btnAtualizar.Enabled = false;
        }

        private void dgvIngrediente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _ingredienteActivo.IngredienteID = Convert.ToInt32(dgvIngrediente[0, e.RowIndex].Value);
            _ingredienteActivo.NomeIngrediente = Convert.ToString(dgvIngrediente[1, e.RowIndex].Value);
            txtIngrediente.Text = _ingredienteActivo.NomeIngrediente;
            btnApagar.Enabled = true;
            btnAtualizar.Enabled = true;
        }

        private void txtIngrediente_Leave(object sender, EventArgs e)
        {//nombre ingrediente porque es el campo que estamos actualizando 
            _ingredienteActivo.NomeIngrediente = txtIngrediente.Text;
        }
    }
}
