namespace GerenciamentoSoftware.Relatorios
{
    partial class consulta1
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.softidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.softnomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.softnomeExecutavelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.softversaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.softSODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.softfabricanteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.softdescricaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.softusoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.softcategoriaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.softstatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.softmotivorestricaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.softsolicitanteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.softanalistatiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.softresponsavellicencaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.softnormativoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.softhomologincDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.softhomologdataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.softdataatualizacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.softwareBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tSMDataSet = new GerenciamentoSoftware.TSMDataSet();
            this.softwareTableAdapter = new GerenciamentoSoftware.TSMDataSetTableAdapters.softwareTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSMDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.softidDataGridViewTextBoxColumn,
            this.softnomeDataGridViewTextBoxColumn,
            this.softnomeExecutavelDataGridViewTextBoxColumn,
            this.softversaoDataGridViewTextBoxColumn,
            this.softSODataGridViewTextBoxColumn,
            this.softfabricanteDataGridViewTextBoxColumn,
            this.softdescricaoDataGridViewTextBoxColumn,
            this.softusoDataGridViewTextBoxColumn,
            this.softcategoriaDataGridViewTextBoxColumn,
            this.softstatusDataGridViewTextBoxColumn,
            this.softmotivorestricaoDataGridViewTextBoxColumn,
            this.softsolicitanteDataGridViewTextBoxColumn,
            this.softanalistatiDataGridViewTextBoxColumn,
            this.softresponsavellicencaDataGridViewTextBoxColumn,
            this.softnormativoDataGridViewTextBoxColumn,
            this.softhomologincDataGridViewTextBoxColumn,
            this.softhomologdataDataGridViewTextBoxColumn,
            this.softdataatualizacaoDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.softwareBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(32, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(548, 245);
            this.dataGridView1.TabIndex = 0;
            // 
            // softidDataGridViewTextBoxColumn
            // 
            this.softidDataGridViewTextBoxColumn.DataPropertyName = "soft_id";
            this.softidDataGridViewTextBoxColumn.HeaderText = "soft_id";
            this.softidDataGridViewTextBoxColumn.Name = "softidDataGridViewTextBoxColumn";
            this.softidDataGridViewTextBoxColumn.ReadOnly = true;
            this.softidDataGridViewTextBoxColumn.Visible = false;
            // 
            // softnomeDataGridViewTextBoxColumn
            // 
            this.softnomeDataGridViewTextBoxColumn.DataPropertyName = "soft_nome";
            this.softnomeDataGridViewTextBoxColumn.HeaderText = "Nome Software";
            this.softnomeDataGridViewTextBoxColumn.Name = "softnomeDataGridViewTextBoxColumn";
            this.softnomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // softnomeExecutavelDataGridViewTextBoxColumn
            // 
            this.softnomeExecutavelDataGridViewTextBoxColumn.DataPropertyName = "soft_nomeExecutavel";
            this.softnomeExecutavelDataGridViewTextBoxColumn.HeaderText = "Nome Executavel";
            this.softnomeExecutavelDataGridViewTextBoxColumn.Name = "softnomeExecutavelDataGridViewTextBoxColumn";
            this.softnomeExecutavelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // softversaoDataGridViewTextBoxColumn
            // 
            this.softversaoDataGridViewTextBoxColumn.DataPropertyName = "soft_versao";
            this.softversaoDataGridViewTextBoxColumn.HeaderText = "Versao";
            this.softversaoDataGridViewTextBoxColumn.Name = "softversaoDataGridViewTextBoxColumn";
            this.softversaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // softSODataGridViewTextBoxColumn
            // 
            this.softSODataGridViewTextBoxColumn.DataPropertyName = "soft_SO";
            this.softSODataGridViewTextBoxColumn.HeaderText = "SO";
            this.softSODataGridViewTextBoxColumn.Name = "softSODataGridViewTextBoxColumn";
            this.softSODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // softfabricanteDataGridViewTextBoxColumn
            // 
            this.softfabricanteDataGridViewTextBoxColumn.DataPropertyName = "soft_fabricante";
            this.softfabricanteDataGridViewTextBoxColumn.HeaderText = "Fabricante";
            this.softfabricanteDataGridViewTextBoxColumn.Name = "softfabricanteDataGridViewTextBoxColumn";
            this.softfabricanteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // softdescricaoDataGridViewTextBoxColumn
            // 
            this.softdescricaoDataGridViewTextBoxColumn.DataPropertyName = "soft_descricao";
            this.softdescricaoDataGridViewTextBoxColumn.HeaderText = "Descricao";
            this.softdescricaoDataGridViewTextBoxColumn.Name = "softdescricaoDataGridViewTextBoxColumn";
            this.softdescricaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // softusoDataGridViewTextBoxColumn
            // 
            this.softusoDataGridViewTextBoxColumn.DataPropertyName = "soft_uso";
            this.softusoDataGridViewTextBoxColumn.HeaderText = "Uso";
            this.softusoDataGridViewTextBoxColumn.Name = "softusoDataGridViewTextBoxColumn";
            this.softusoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // softcategoriaDataGridViewTextBoxColumn
            // 
            this.softcategoriaDataGridViewTextBoxColumn.DataPropertyName = "soft_categoria";
            this.softcategoriaDataGridViewTextBoxColumn.HeaderText = "Categoria";
            this.softcategoriaDataGridViewTextBoxColumn.Name = "softcategoriaDataGridViewTextBoxColumn";
            this.softcategoriaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // softstatusDataGridViewTextBoxColumn
            // 
            this.softstatusDataGridViewTextBoxColumn.DataPropertyName = "soft_status";
            this.softstatusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.softstatusDataGridViewTextBoxColumn.Name = "softstatusDataGridViewTextBoxColumn";
            this.softstatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // softmotivorestricaoDataGridViewTextBoxColumn
            // 
            this.softmotivorestricaoDataGridViewTextBoxColumn.DataPropertyName = "soft_motivo_restricao";
            this.softmotivorestricaoDataGridViewTextBoxColumn.HeaderText = "Motivo restricao";
            this.softmotivorestricaoDataGridViewTextBoxColumn.Name = "softmotivorestricaoDataGridViewTextBoxColumn";
            this.softmotivorestricaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // softsolicitanteDataGridViewTextBoxColumn
            // 
            this.softsolicitanteDataGridViewTextBoxColumn.DataPropertyName = "soft_solicitante";
            this.softsolicitanteDataGridViewTextBoxColumn.HeaderText = "Solicitante";
            this.softsolicitanteDataGridViewTextBoxColumn.Name = "softsolicitanteDataGridViewTextBoxColumn";
            this.softsolicitanteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // softanalistatiDataGridViewTextBoxColumn
            // 
            this.softanalistatiDataGridViewTextBoxColumn.DataPropertyName = "soft_analista_ti";
            this.softanalistatiDataGridViewTextBoxColumn.HeaderText = "Analista TI";
            this.softanalistatiDataGridViewTextBoxColumn.Name = "softanalistatiDataGridViewTextBoxColumn";
            this.softanalistatiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // softresponsavellicencaDataGridViewTextBoxColumn
            // 
            this.softresponsavellicencaDataGridViewTextBoxColumn.DataPropertyName = "soft_responsavel_licenca";
            this.softresponsavellicencaDataGridViewTextBoxColumn.HeaderText = "Responsavel licenca";
            this.softresponsavellicencaDataGridViewTextBoxColumn.Name = "softresponsavellicencaDataGridViewTextBoxColumn";
            this.softresponsavellicencaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // softnormativoDataGridViewTextBoxColumn
            // 
            this.softnormativoDataGridViewTextBoxColumn.DataPropertyName = "soft_normativo";
            this.softnormativoDataGridViewTextBoxColumn.HeaderText = "Normativo";
            this.softnormativoDataGridViewTextBoxColumn.Name = "softnormativoDataGridViewTextBoxColumn";
            this.softnormativoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // softhomologincDataGridViewTextBoxColumn
            // 
            this.softhomologincDataGridViewTextBoxColumn.DataPropertyName = "soft_homolog_inc";
            this.softhomologincDataGridViewTextBoxColumn.HeaderText = "Incidente Homologacao ";
            this.softhomologincDataGridViewTextBoxColumn.Name = "softhomologincDataGridViewTextBoxColumn";
            this.softhomologincDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // softhomologdataDataGridViewTextBoxColumn
            // 
            this.softhomologdataDataGridViewTextBoxColumn.DataPropertyName = "soft_homolog_data";
            this.softhomologdataDataGridViewTextBoxColumn.HeaderText = "Homologacao Data";
            this.softhomologdataDataGridViewTextBoxColumn.Name = "softhomologdataDataGridViewTextBoxColumn";
            this.softhomologdataDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // softdataatualizacaoDataGridViewTextBoxColumn
            // 
            this.softdataatualizacaoDataGridViewTextBoxColumn.DataPropertyName = "soft_data_atualizacao";
            this.softdataatualizacaoDataGridViewTextBoxColumn.HeaderText = "Data Atualizacao";
            this.softdataatualizacaoDataGridViewTextBoxColumn.Name = "softdataatualizacaoDataGridViewTextBoxColumn";
            this.softdataatualizacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // softwareBindingSource
            // 
            this.softwareBindingSource.DataMember = "software";
            this.softwareBindingSource.DataSource = this.tSMDataSet;
            // 
            // tSMDataSet
            // 
            this.tSMDataSet.DataSetName = "TSMDataSet";
            this.tSMDataSet.EnforceConstraints = false;
            this.tSMDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // softwareTableAdapter
            // 
            this.softwareTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(154, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Relatório Todos os Softwares";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 328);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Exportar CSV";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // consulta1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(620, 363);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "consulta1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "consulta1";
            this.Load += new System.EventHandler(this.consulta1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSMDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private TSMDataSet tSMDataSet;
        private System.Windows.Forms.BindingSource softwareBindingSource;
        private TSMDataSetTableAdapters.softwareTableAdapter softwareTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn softidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn softnomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn softnomeExecutavelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn softversaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn softSODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn softfabricanteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn softdescricaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn softusoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn softcategoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn softstatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn softmotivorestricaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn softsolicitanteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn softanalistatiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn softresponsavellicencaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn softnormativoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn softhomologincDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn softhomologdataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn softdataatualizacaoDataGridViewTextBoxColumn;

    }
}