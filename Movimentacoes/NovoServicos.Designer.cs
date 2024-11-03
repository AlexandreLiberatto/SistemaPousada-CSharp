namespace SistemaHotel.Movimentacoes
{
    partial class FrmNovoServics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNovoServics));
            this.grid = new System.Windows.Forms.DataGridView();
            this.dtBuscar = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnHospede = new System.Windows.Forms.Button();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnRel = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbServico = new System.Windows.Forms.ComboBox();
            this.cbQuartos = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.GridColor = System.Drawing.SystemColors.Control;
            this.grid.Location = new System.Drawing.Point(27, 148);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(647, 186);
            this.grid.TabIndex = 136;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellClick);
            // 
            // dtBuscar
            // 
            this.dtBuscar.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBuscar.Location = new System.Drawing.Point(581, 12);
            this.dtBuscar.Name = "dtBuscar";
            this.dtBuscar.Size = new System.Drawing.Size(93, 20);
            this.dtBuscar.TabIndex = 135;
            this.dtBuscar.Value = new System.DateTime(2019, 5, 5, 13, 44, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(532, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 134;
            this.label3.Text = "Buscar:";
            // 
            // btnHospede
            // 
            this.btnHospede.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnHospede.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHospede.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnHospede.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHospede.Location = new System.Drawing.Point(224, 58);
            this.btnHospede.Name = "btnHospede";
            this.btnHospede.Size = new System.Drawing.Size(23, 23);
            this.btnHospede.TabIndex = 133;
            this.btnHospede.Text = "+";
            this.btnHospede.UseVisualStyleBackColor = false;
            this.btnHospede.Click += new System.EventHandler(this.BtnHospede_Click);
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Enabled = false;
            this.txtQuantidade.Location = new System.Drawing.Point(109, 101);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(109, 20);
            this.txtQuantidade.TabIndex = 132;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 131;
            this.label2.Text = "Quantidade:";
            // 
            // txtNome
            // 
            this.txtNome.Enabled = false;
            this.txtNome.Location = new System.Drawing.Point(108, 60);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(110, 20);
            this.txtNome.TabIndex = 130;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 129;
            this.label1.Text = "Hóspede:";
            // 
            // txtValor
            // 
            this.txtValor.Enabled = false;
            this.txtValor.Location = new System.Drawing.Point(344, 101);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(82, 20);
            this.txtValor.TabIndex = 125;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(303, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 126;
            this.label4.Text = "Valor:";
            // 
            // BtnRel
            // 
            this.BtnRel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRel.Enabled = false;
            this.BtnRel.FlatAppearance.BorderSize = 0;
            this.BtnRel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.BtnRel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRel.Image = ((System.Drawing.Image)(resources.GetObject("BtnRel.Image")));
            this.BtnRel.Location = new System.Drawing.Point(444, 355);
            this.BtnRel.Name = "BtnRel";
            this.BtnRel.Size = new System.Drawing.Size(70, 65);
            this.BtnRel.TabIndex = 146;
            this.BtnRel.UseVisualStyleBackColor = true;
            this.BtnRel.Click += new System.EventHandler(this.BtnRel_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcluir.Enabled = false;
            this.btnExcluir.FlatAppearance.BorderSize = 0;
            this.btnExcluir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.Location = new System.Drawing.Point(356, 355);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(70, 65);
            this.btnExcluir.TabIndex = 139;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Enabled = false;
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.Location = new System.Drawing.Point(272, 355);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 65);
            this.btnSalvar.TabIndex = 138;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovo.FlatAppearance.BorderSize = 0;
            this.btnNovo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.Location = new System.Drawing.Point(191, 355);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(70, 65);
            this.btnNovo.TabIndex = 137;
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.BtnNovo_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(291, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 147;
            this.label5.Text = "Serviço:";
            // 
            // cbServico
            // 
            this.cbServico.FormattingEnabled = true;
            this.cbServico.Location = new System.Drawing.Point(344, 60);
            this.cbServico.Name = "cbServico";
            this.cbServico.Size = new System.Drawing.Size(139, 21);
            this.cbServico.TabIndex = 148;
            this.cbServico.SelectedValueChanged += new System.EventHandler(this.CbServico_SelectedValueChanged);
            // 
            // cbQuartos
            // 
            this.cbQuartos.FormattingEnabled = true;
            this.cbQuartos.Location = new System.Drawing.Point(581, 60);
            this.cbQuartos.Name = "cbQuartos";
            this.cbQuartos.Size = new System.Drawing.Size(92, 21);
            this.cbQuartos.TabIndex = 150;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(533, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 149;
            this.label6.Text = "Quarto:";
            // 
            // FrmNovoServics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(706, 431);
            this.Controls.Add(this.cbQuartos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbServico);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnRel);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.dtBuscar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnHospede);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmNovoServics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Novo Servicos";
            this.Activated += new System.EventHandler(this.FrmNovoServics_Activated);
            this.Load += new System.EventHandler(this.FrmServicos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnRel;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.DateTimePicker dtBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnHospede;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbServico;
        private System.Windows.Forms.ComboBox cbQuartos;
        private System.Windows.Forms.Label label6;
    }
}