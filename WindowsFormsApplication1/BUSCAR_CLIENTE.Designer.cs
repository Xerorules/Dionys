namespace WindowsFormsApplication1
{
    partial class BUSCAR_CLIENTE
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.cboMC_DISTRITO = new System.Windows.Forms.ComboBox();
            this.cboMC_PROVINCIA = new System.Windows.Forms.ComboBox();
            this.cboMC_DEPARTAMENTO = new System.Windows.Forms.ComboBox();
            this.cboTipoCliente = new System.Windows.Forms.ComboBox();
            this.txtFDNI = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(399, -4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "BUSCAR CLIENTES";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvClientes);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.cboMC_DISTRITO);
            this.groupBox2.Controls.Add(this.cboMC_PROVINCIA);
            this.groupBox2.Controls.Add(this.cboMC_DEPARTAMENTO);
            this.groupBox2.Controls.Add(this.cboTipoCliente);
            this.groupBox2.Controls.Add(this.txtFDNI);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(4, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(930, 599);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.AllowUserToResizeColumns = false;
            this.dgvClientes.AllowUserToResizeRows = false;
            this.dgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvClientes.BackgroundColor = System.Drawing.Color.MediumTurquoise;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClientes.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvClientes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvClientes.Location = new System.Drawing.Point(8, 81);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.RowHeadersVisible = false;
            this.dgvClientes.Size = new System.Drawing.Size(708, 509);
            this.dgvClientes.TabIndex = 13;
            this.dgvClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DimGray;
            this.button1.Font = new System.Drawing.Font("Gabriola", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(760, 430);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 105);
            this.button1.TabIndex = 12;
            this.button1.Text = "BUSCAR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboMC_DISTRITO
            // 
            this.cboMC_DISTRITO.FormattingEnabled = true;
            this.cboMC_DISTRITO.Location = new System.Drawing.Point(760, 316);
            this.cboMC_DISTRITO.Name = "cboMC_DISTRITO";
            this.cboMC_DISTRITO.Size = new System.Drawing.Size(142, 21);
            this.cboMC_DISTRITO.TabIndex = 11;
            this.cboMC_DISTRITO.SelectedIndexChanged += new System.EventHandler(this.cboMC_DISTRITO_SelectedIndexChanged);
            // 
            // cboMC_PROVINCIA
            // 
            this.cboMC_PROVINCIA.FormattingEnabled = true;
            this.cboMC_PROVINCIA.Location = new System.Drawing.Point(753, 185);
            this.cboMC_PROVINCIA.Name = "cboMC_PROVINCIA";
            this.cboMC_PROVINCIA.Size = new System.Drawing.Size(149, 21);
            this.cboMC_PROVINCIA.TabIndex = 10;
            this.cboMC_PROVINCIA.SelectedIndexChanged += new System.EventHandler(this.cboMC_PROVINCIA_SelectedIndexChanged);
            // 
            // cboMC_DEPARTAMENTO
            // 
            this.cboMC_DEPARTAMENTO.FormattingEnabled = true;
            this.cboMC_DEPARTAMENTO.Location = new System.Drawing.Point(753, 81);
            this.cboMC_DEPARTAMENTO.Name = "cboMC_DEPARTAMENTO";
            this.cboMC_DEPARTAMENTO.Size = new System.Drawing.Size(149, 21);
            this.cboMC_DEPARTAMENTO.TabIndex = 9;
            this.cboMC_DEPARTAMENTO.SelectedIndexChanged += new System.EventHandler(this.cboMC_DEPARTAMENTO_SelectedIndexChanged);
            // 
            // cboTipoCliente
            // 
            this.cboTipoCliente.FormattingEnabled = true;
            this.cboTipoCliente.Location = new System.Drawing.Point(511, 43);
            this.cboTipoCliente.Name = "cboTipoCliente";
            this.cboTipoCliente.Size = new System.Drawing.Size(129, 21);
            this.cboTipoCliente.TabIndex = 8;
            // 
            // txtFDNI
            // 
            this.txtFDNI.Location = new System.Drawing.Point(344, 43);
            this.txtFDNI.Name = "txtFDNI";
            this.txtFDNI.Size = new System.Drawing.Size(133, 20);
            this.txtFDNI.TabIndex = 7;
            this.txtFDNI.TextChanged += new System.EventHandler(this.txtFDNI_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(301, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(796, 289);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 35);
            this.label7.TabIndex = 5;
            this.label7.Text = "DISTRITO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(783, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 35);
            this.label6.TabIndex = 4;
            this.label6.Text = "PROVINCIA";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(772, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 35);
            this.label5.TabIndex = 3;
            this.label5.Text = "DEPARTAMENTO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(525, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 35);
            this.label4.TabIndex = 2;
            this.label4.Text = "TIPO CLIENTE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(374, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 35);
            this.label3.TabIndex = 1;
            this.label3.Text = "RUC/DNI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 35);
            this.label2.TabIndex = 0;
            this.label2.Text = "BUSCAR POR NOMBRE";
            // 
            // BUSCAR_CLIENTE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(939, 640);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BUSCAR_CLIENTE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BUSCAR_CLIENTE";
            this.Load += new System.EventHandler(this.BUSCAR_CLIENTE_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cboMC_DISTRITO;
        private System.Windows.Forms.ComboBox cboMC_PROVINCIA;
        private System.Windows.Forms.ComboBox cboMC_DEPARTAMENTO;
        private System.Windows.Forms.ComboBox cboTipoCliente;
        private System.Windows.Forms.TextBox txtFDNI;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView dgvClientes;
    }
}