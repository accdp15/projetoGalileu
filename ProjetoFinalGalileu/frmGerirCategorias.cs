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
    public partial class frmGerirCategorias : Form
    {
        private Categoria _categoriaActiva = new Categoria();
        public frmGerirCategorias()
        {
            InitializeComponent();
            btnApagar.Enabled = false;
            btnAtualizar.Enabled = false;
            RefrescarTabla();
        }

        private void RefrescarTabla()
        {
            List<Categoria> lista = Categoria.Ler();
            dgvCategoria.DataSource = lista;
           
        }


        private void dgvCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _categoriaActiva.CategoriaID = Convert.ToInt32(dgvCategoria[0, e.RowIndex].Value);
            _categoriaActiva.Nome = Convert.ToString(dgvCategoria[1, e.RowIndex].Value);
            txtCategoria.Text = _categoriaActiva.Nome;
            btnApagar.Enabled = true;
            btnAtualizar.Enabled = true;
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            _categoriaActiva.Inserir();
            RefrescarTabla();
            btnApagar.Enabled = false;
            btnAtualizar.Enabled = false;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            _categoriaActiva.Atualizar();
            RefrescarTabla();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            _categoriaActiva.Apagar();
            RefrescarTabla();
            btnApagar.Enabled = false;
            btnAtualizar.Enabled = false; 
        }

        private void txtCategoria_Leave(object sender, EventArgs e)
        {
            _categoriaActiva.Nome = txtCategoria.Text;
        }
    }
}
