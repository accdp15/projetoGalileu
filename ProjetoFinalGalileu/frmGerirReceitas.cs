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
    public partial class frmGerirReceitas : Form
    {
        private Receita _receitaAtiva; // atributo
        public frmGerirReceitas()
        {
            InitializeComponent();
            _receitaAtiva = new Receita();
            cmbIngredientes.DataSource = Ingrediente.Ler();
            cmbIngredientes.DisplayMember = "NomeIngrediente";
            cmbDificuldade.DataSource = Dificuldade.LerDificuldades();
            cmbDificuldade.DisplayMember = "Nivel";
            cmbCategoria.DataSource = Categoria.Ler();
            cmbCategoria.DisplayMember = "Nome";
            cmbUnidade.DataSource = Unidade.LerUnidades();
            cmbUnidade.DisplayMember = "NomeUnidade";
            ConfigurarTabla();
            RefrescarTabla();
        }

        private void RefrescarTabla()
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = _receitaAtiva.IngredientesReceita;
            dgvLinhaIngrediente.DataSource = bindingSource;
        }
        
        private void ConfigurarTabla()
        {
            dgvLinhaIngrediente.AutoGenerateColumns = false;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "IngredienteID";
            column.Name = "IngredienteID";
            column.Visible = false;
            dgvLinhaIngrediente.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "IngredienteNome";
            column.Name = "Ingrediente";
            column.Visible = true;
            dgvLinhaIngrediente.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Quantidade";
            column.Name = "Quantidade";
            column.Visible = true;
            dgvLinhaIngrediente.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "UnidadeID";
            column.Name = "UnidadeID";
            column.Visible = false;
            dgvLinhaIngrediente.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "UnidadeNome";
            column.Name = "Unidade";
            column.Visible = true;
            dgvLinhaIngrediente.Columns.Add(column);
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            _receitaAtiva.UserID = 1;
            _receitaAtiva.Inserir(); //con mi objeto global llamo al metodo de mi BD inserir que llama al store procedure
            //RefrescarTabla();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            //Necesito crear un nueva instancia de la clase LinhaIngrediente para ver si debo agregarlo en mi lista de LinhaIngrediente
            LinhaIngrediente ingredienteRecetaActiva = new LinhaIngrediente();
            ingredienteRecetaActiva.Ingrediente = (Ingrediente)cmbIngredientes.SelectedItem; //cast de object para Ingrediente
            ingredienteRecetaActiva.Quantidade = Convert.ToDouble(txtQuantidade.Text);
            ingredienteRecetaActiva.Unidade = (Unidade)cmbUnidade.SelectedItem; //cast de object para Unidade

            // El siguiente codigo solo valida si el ingrediete existe en la lista de LinhaIngrediente
            bool existeIngrediente = false;
            for(int i = 0; i < _receitaAtiva.IngredientesReceita.Count; i++ )
            {
                if (_receitaAtiva.IngredientesReceita[i].Ingrediente.IngredienteID == ingredienteRecetaActiva.Ingrediente.IngredienteID)
                {
                    existeIngrediente = true;
                }
            }

            //En esta parte del codigo es donde decides si agregas el ingrediente o no
            if (existeIngrediente == false)
            {
                _receitaAtiva.IngredientesReceita.Add(ingredienteRecetaActiva);
                RefrescarTabla();
            }
            else
            {
                MessageBox.Show("Já tinhas inserido o ingrediente");
            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            Ingrediente ingredienteActivo = (Ingrediente)cmbIngredientes.SelectedItem; //Creamos una variable para almacenar el objeto Ingrediente que fue seleccionado del combobox
            int index = -1;
            for (int i = 0; i < _receitaAtiva.IngredientesReceita.Count; i++)
            {
                if (_receitaAtiva.IngredientesReceita[i].Ingrediente.IngredienteID == ingredienteActivo.IngredienteID)
                {
                    index = i;
                }
            }

            if (index != -1)
            {
                _receitaAtiva.IngredientesReceita.RemoveAt(index);
                RefrescarTabla();
            }
            else
            {
                MessageBox.Show("O ingrediente nao existe.");
            }
        }

        private void dgvLinhaIngrediente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ingredienteID = Convert.ToInt32(dgvLinhaIngrediente[0, e.RowIndex].Value);
            string ingredienteNome = Convert.ToString(dgvLinhaIngrediente[1, e.RowIndex].Value);
            int quantidade = Convert.ToInt32(dgvLinhaIngrediente[2, e.RowIndex].Value);
            int unidadeID = Convert.ToInt32(dgvLinhaIngrediente[3, e.RowIndex].Value);
            string unidadeNome = Convert.ToString(dgvLinhaIngrediente[4, e.RowIndex].Value);

            cmbIngredientes.SelectedIndex = cmbIngredientes.FindString(ingredienteNome);
            txtQuantidade.Text = Convert.ToString(quantidade);
            cmbUnidade.SelectedIndex = cmbUnidade.FindString(unidadeNome);

        }

        private void txtNomeReceita_Leave(object sender, EventArgs e)
        {
            _receitaAtiva.Nome = txtNomeReceita.Text;
        }

        private void txttempodeex_Leave(object sender, EventArgs e)
        {
            _receitaAtiva.Duracao = Convert.ToInt32(txttempodeex.Text);
        }

        private void txtquantcomensal_Leave(object sender, EventArgs e)
        {
            _receitaAtiva.QuantidadeComensales = Convert.ToInt32(txtquantcomensal.Text);
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            _receitaAtiva.Categoria = (Categoria)cmbCategoria.SelectedItem;
        }

        private void cmbDificuldade_SelectedIndexChanged(object sender, EventArgs e)
        {
            _receitaAtiva.Dificuldade = (Dificuldade)cmbDificuldade.SelectedItem;
        }

        private void txtPasosParaExec_Leave(object sender, EventArgs e)
        {
            _receitaAtiva.Descripcao = txtPasosParaExec.Text;
        }
    }
}