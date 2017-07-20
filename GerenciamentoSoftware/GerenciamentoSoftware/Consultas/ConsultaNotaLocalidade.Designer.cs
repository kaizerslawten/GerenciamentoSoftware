namespace GerenciamentoSoftware.Consultas
{
    partial class ConsultaNotaLocalidade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultaNotaLocalidade));
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_cancelcadsoftware = new System.Windows.Forms.Button();
            this.btn_cadsoftware = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Selecione a Localidade:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(137, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(371, 21);
            this.comboBox1.TabIndex = 54;
            // 
            // btn_cancelcadsoftware
            // 
            this.btn_cancelcadsoftware.Location = new System.Drawing.Point(641, 13);
            this.btn_cancelcadsoftware.Name = "btn_cancelcadsoftware";
            this.btn_cancelcadsoftware.Size = new System.Drawing.Size(95, 40);
            this.btn_cancelcadsoftware.TabIndex = 53;
            this.btn_cancelcadsoftware.Text = "Cancelar";
            this.btn_cancelcadsoftware.UseVisualStyleBackColor = true;
            this.btn_cancelcadsoftware.Click += new System.EventHandler(this.btn_cancelcadsoftware_Click);
            // 
            // btn_cadsoftware
            // 
            this.btn_cadsoftware.Location = new System.Drawing.Point(526, 13);
            this.btn_cadsoftware.Name = "btn_cadsoftware";
            this.btn_cadsoftware.Size = new System.Drawing.Size(95, 40);
            this.btn_cadsoftware.TabIndex = 52;
            this.btn_cadsoftware.Text = "Consultar";
            this.btn_cadsoftware.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(723, 453);
            this.dataGridView1.TabIndex = 51;
            // 
            // ConsultaNotaLocalidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 524);
            this.ControlBox = false;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_cancelcadsoftware);
            this.Controls.Add(this.btn_cadsoftware);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConsultaNotaLocalidade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConsultaNotaLocalidade";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btn_cancelcadsoftware;
        private System.Windows.Forms.Button btn_cadsoftware;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}