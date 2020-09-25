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
    public partial class frmAdministrador : Form
    {
        public frmAdministrador()
        {
            InitializeComponent();
        }

        private void gerirComentariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void usuariosBloqueadosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listarDificuldadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGerirDificuldades form = new frmGerirDificuldades();
            form.ShowDialog();
        }

        private void listarUnidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGerirUnidades form = new frmGerirUnidades();
            form.ShowDialog();
        }

        private void listarComentariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGerirComentarios form = new frmGerirComentarios();
            form.ShowDialog();
        }

        private void listarIngredientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGerirIngredientes form = new frmGerirIngredientes();
            form.ShowDialog();
        }

        private void validarNovasReceitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGerirReceitas form = new frmGerirReceitas();
            form.ShowDialog();
        }

        private void listarCategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGerirCategorias form = new frmGerirCategorias();
            form.ShowDialog();
        }
    }
}
