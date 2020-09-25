using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace ProjetoFinalGalileu
{
    public partial class frmGerirDificuldades : Form
    {
        private Dificuldade _dificuldadeActiva;

        public frmGerirDificuldades()
        {
            InitializeComponent();
            _dificuldadeActiva = new Dificuldade();
            RefrescarDataViewGrid();
            btnAtualizar.Enabled = false;
        }

        private void RefrescarDataViewGrid()
        {

            List<Dificuldade> lista = Dificuldade.LerDificuldades();
            //BindingList<Dificuldade> bindingList = new BindingList<Dificuldade>(lista);
            //BindingSource dataSource = new BindingSource(bindingList, null);
            dgvDificuldades.DataSource = lista;
        }

        private void dgvDificuldades_CellClick(object sender, DataGridViewCellEventArgs evento)
        {
            _dificuldadeActiva.DificuldadeID = Convert.ToInt32(dgvDificuldades[0, evento.RowIndex].Value);
            _dificuldadeActiva.Nivel = Convert.ToString(dgvDificuldades[1, evento.RowIndex].Value);
            txtNivel.Text = _dificuldadeActiva.Nivel;
            btnAtualizar.Enabled = true;
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            _dificuldadeActiva.Apagar();
            RefrescarDataViewGrid();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            _dificuldadeActiva.Atualizar();
            RefrescarDataViewGrid();
        }

        private void txtNivel_Leave(object sender, EventArgs e)
        {
            _dificuldadeActiva.Nivel = txtNivel.Text;
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            if (_dificuldadeActiva.Inserir())
                RefrescarDataViewGrid();
            else
                MessageBox.Show("asaaa");
        }
    }
}
