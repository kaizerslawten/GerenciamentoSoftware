namespace GerenciamentoSoftware.Consultas
{
    partial class ConsultaSoftwareNome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultaSoftwareNome));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_cancelcadsoftware = new System.Windows.Forms.Button();
            this.btn_cadsoftware = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(723, 453);
            this.dataGridView1.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Nome do Software:";
            // 
            // btn_cancelcadsoftware
            // 
            this.btn_cancelcadsoftware.Location = new System.Drawing.Point(643, 13);
            this.btn_cancelcadsoftware.Name = "btn_cancelcadsoftware";
            this.btn_cancelcadsoftware.Size = new System.Drawing.Size(95, 40);
            this.btn_cancelcadsoftware.TabIndex = 44;
            this.btn_cancelcadsoftware.Text = "Cancelar";
            this.btn_cancelcadsoftware.UseVisualStyleBackColor = true;
            this.btn_cancelcadsoftware.Click += new System.EventHandler(this.btn_cancelcadsoftware_Click);
            // 
            // btn_cadsoftware
            // 
            this.btn_cadsoftware.Location = new System.Drawing.Point(528, 13);
            this.btn_cadsoftware.Name = "btn_cadsoftware";
            this.btn_cadsoftware.Size = new System.Drawing.Size(95, 40);
            this.btn_cadsoftware.TabIndex = 43;
            this.btn_cadsoftware.Text = "Consultar";
            this.btn_cadsoftware.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(116, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(394, 21);
            this.comboBox1.TabIndex = 45;
            // 
            // ConsultaSoftwareNome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 524);
            this.ControlBox = false;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_cancelcadsoftware);
            this.Controls.Add(this.btn_cadsoftware);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConsultaSoftwareNome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Consulta de Software pelo Nome";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_cancelcadsoftware;
        private System.Windows.Forms.Button btn_cadsoftware;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}