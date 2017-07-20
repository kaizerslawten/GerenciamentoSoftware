namespace GerenciamentoSoftware.Relatorios
{
    partial class software_empresa
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
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.softwarecsnBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet2INSTALADOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet2_INSTALADOS = new GerenciamentoSoftware.DataSet2_INSTALADOS();
            this.software_csnTableAdapter = new GerenciamentoSoftware.DataSet2_INSTALADOSTableAdapters.software_csnTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.softwarecsnBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.equip = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.softwarecsnBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2INSTALADOSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2_INSTALADOS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwarecsnBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 71;
            this.label4.Text = "Equipamento:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(338, 57);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 68;
            this.button3.Text = "&Pesquisar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(17, 148);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(95, 23);
            this.button4.TabIndex = 67;
            this.button4.Text = "&Limpar Filtros";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(17, 465);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 23);
            this.button2.TabIndex = 66;
            this.button2.Text = "Exportar CSV";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // softwarecsnBindingSource1
            // 
            this.softwarecsnBindingSource1.DataMember = "software_csn";
            this.softwarecsnBindingSource1.DataSource = this.dataSet2INSTALADOSBindingSource;
            // 
            // dataSet2INSTALADOSBindingSource
            // 
            this.dataSet2INSTALADOSBindingSource.DataSource = this.dataSet2_INSTALADOS;
            this.dataSet2INSTALADOSBindingSource.Position = 0;
            // 
            // dataSet2_INSTALADOS
            // 
            this.dataSet2_INSTALADOS.DataSetName = "DataSet2_INSTALADOS";
            this.dataSet2_INSTALADOS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // software_csnTableAdapter
            // 
            this.software_csnTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 593);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 63;
            this.button1.Text = "Exportar CSV";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 177);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(748, 256);
            this.dataGridView1.TabIndex = 61;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 25);
            this.label1.TabIndex = 62;
            this.label1.Text = "Compliance de Licenças";
            // 
            // softwarecsnBindingSource
            // 
            this.softwarecsnBindingSource.DataMember = "software_csn";
            // 
            // equip
            // 
            this.equip.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.equip.FormattingEnabled = true;
            this.equip.Location = new System.Drawing.Point(120, 59);
            this.equip.Name = "equip";
            this.equip.Size = new System.Drawing.Size(197, 21);
            this.equip.TabIndex = 73;
            // 
            // software_empresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(821, 512);
            this.Controls.Add(this.equip);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "software_empresa";
            this.Text = "software_empresa";
            this.Load += new System.EventHandler(this.software_empresa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.softwarecsnBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2INSTALADOSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2_INSTALADOS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwarecsnBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.BindingSource softwarecsnBindingSource1;
        private System.Windows.Forms.BindingSource dataSet2INSTALADOSBindingSource;
        private DataSet2_INSTALADOS dataSet2_INSTALADOS;
        private DataSet2_INSTALADOSTableAdapters.software_csnTableAdapter software_csnTableAdapter;
        private System.Windows.Forms.BindingSource softwarecsnBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox equip;
    }
}