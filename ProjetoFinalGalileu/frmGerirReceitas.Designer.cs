namespace ProjetoFinalGalileu
{
    partial class frmGerirReceitas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.txtPasosParaExec = new System.Windows.Forms.TextBox();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNomeReceita = new System.Windows.Forms.TextBox();
            this.cmbIngredientes = new System.Windows.Forms.ComboBox();
            this.dgvLinhaIngrediente = new System.Windows.Forms.DataGridView();
            this.cmbUnidade = new System.Windows.Forms.ComboBox();
            this.btnInserir = new System.Windows.Forms.Button();
            this.txttempodeex = new System.Windows.Forms.TextBox();
            this.txtquantcomensal = new System.Windows.Forms.TextBox();
            this.cmbDificuldade = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnApagar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLinhaIngrediente)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(308, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ESCREVA A SUA RECEITA:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Categoria:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ingredientes:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 26);
            this.label4.TabIndex = 1;
            this.label4.Text = "Pasos para\r\n execução:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 425);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 26);
            this.label5.TabIndex = 1;
            this.label5.Text = "Tempo de \r\n execução:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(408, 426);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 26);
            this.label6.TabIndex = 1;
            this.label6.Text = "Quantidad de \r\n comensales:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 431);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Dificuldade:";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(95, 63);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(113, 21);
            this.cmbCategoria.TabIndex = 3;
            this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbCategoria_SelectedIndexChanged);
            // 
            // txtPasosParaExec
            // 
            this.txtPasosParaExec.Location = new System.Drawing.Point(95, 281);
            this.txtPasosParaExec.Multiline = true;
            this.txtPasosParaExec.Name = "txtPasosParaExec";
            this.txtPasosParaExec.Size = new System.Drawing.Size(633, 131);
            this.txtPasosParaExec.TabIndex = 8;
            this.txtPasosParaExec.Leave += new System.EventHandler(this.txtPasosParaExec_Leave);
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(311, 100);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(58, 20);
            this.txtQuantidade.TabIndex = 9;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(579, 474);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(149, 44);
            this.btnEnviar.TabIndex = 10;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Nome da receita:";
            // 
            // txtNomeReceita
            // 
            this.txtNomeReceita.Location = new System.Drawing.Point(93, 27);
            this.txtNomeReceita.Name = "txtNomeReceita";
            this.txtNomeReceita.Size = new System.Drawing.Size(635, 20);
            this.txtNomeReceita.TabIndex = 12;
            this.txtNomeReceita.Leave += new System.EventHandler(this.txtNomeReceita_Leave);
            // 
            // cmbIngredientes
            // 
            this.cmbIngredientes.FormattingEnabled = true;
            this.cmbIngredientes.Location = new System.Drawing.Point(95, 99);
            this.cmbIngredientes.Name = "cmbIngredientes";
            this.cmbIngredientes.Size = new System.Drawing.Size(113, 21);
            this.cmbIngredientes.TabIndex = 13;
            // 
            // dgvLinhaIngrediente
            // 
            this.dgvLinhaIngrediente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLinhaIngrediente.Location = new System.Drawing.Point(95, 126);
            this.dgvLinhaIngrediente.Name = "dgvLinhaIngrediente";
            this.dgvLinhaIngrediente.Size = new System.Drawing.Size(633, 138);
            this.dgvLinhaIngrediente.TabIndex = 14;
            this.dgvLinhaIngrediente.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLinhaIngrediente_CellClick);
            // 
            // cmbUnidade
            // 
            this.cmbUnidade.FormattingEnabled = true;
            this.cmbUnidade.Location = new System.Drawing.Point(464, 99);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.Size = new System.Drawing.Size(113, 21);
            this.cmbUnidade.TabIndex = 15;
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(628, 99);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(45, 23);
            this.btnInserir.TabIndex = 16;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // txttempodeex
            // 
            this.txttempodeex.Location = new System.Drawing.Point(311, 431);
            this.txttempodeex.Name = "txttempodeex";
            this.txttempodeex.Size = new System.Drawing.Size(59, 20);
            this.txttempodeex.TabIndex = 17;
            this.txttempodeex.Leave += new System.EventHandler(this.txttempodeex_Leave);
            // 
            // txtquantcomensal
            // 
            this.txtquantcomensal.Location = new System.Drawing.Point(488, 432);
            this.txtquantcomensal.Name = "txtquantcomensal";
            this.txtquantcomensal.Size = new System.Drawing.Size(85, 20);
            this.txtquantcomensal.TabIndex = 18;
            this.txtquantcomensal.Leave += new System.EventHandler(this.txtquantcomensal_Leave);
            // 
            // cmbDificuldade
            // 
            this.cmbDificuldade.FormattingEnabled = true;
            this.cmbDificuldade.Location = new System.Drawing.Point(93, 431);
            this.cmbDificuldade.Name = "cmbDificuldade";
            this.cmbDificuldade.Size = new System.Drawing.Size(113, 21);
            this.cmbDificuldade.TabIndex = 19;
            this.cmbDificuldade.SelectedIndexChanged += new System.EventHandler(this.cmbDificuldade_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(408, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Unidade:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(240, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Quantidade:";
            // 
            // btnApagar
            // 
            this.btnApagar.Location = new System.Drawing.Point(679, 99);
            this.btnApagar.Name = "btnApagar";
            this.btnApagar.Size = new System.Drawing.Size(49, 23);
            this.btnApagar.TabIndex = 22;
            this.btnApagar.Text = "Apagar";
            this.btnApagar.UseVisualStyleBackColor = true;
            this.btnApagar.Click += new System.EventHandler(this.btnApagar_Click);
            // 
            // frmGerirReceitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 540);
            this.Controls.Add(this.btnApagar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbDificuldade);
            this.Controls.Add(this.txtquantcomensal);
            this.Controls.Add(this.txttempodeex);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.cmbUnidade);
            this.Controls.Add(this.dgvLinhaIngrediente);
            this.Controls.Add(this.cmbIngredientes);
            this.Controls.Add(this.txtNomeReceita);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.txtPasosParaExec);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmGerirReceitas";
            this.Text = "w";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLinhaIngrediente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.TextBox txtPasosParaExec;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNomeReceita;
        private System.Windows.Forms.ComboBox cmbIngredientes;
        private System.Windows.Forms.DataGridView dgvLinhaIngrediente;
        private System.Windows.Forms.ComboBox cmbUnidade;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.TextBox txttempodeex;
        private System.Windows.Forms.TextBox txtquantcomensal;
        private System.Windows.Forms.ComboBox cmbDificuldade;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnApagar;
    }
}