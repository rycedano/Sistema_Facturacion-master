namespace Capapresentacion
{
    partial class Frmvistaclienteventa
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
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Cmbbuscar = new System.Windows.Forms.ComboBox();
            this.Datagridcliente = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnbuscar = new System.Windows.Forms.Button();
            this.txtbuscar = new System.Windows.Forms.TextBox();
            this.lblpro = new System.Windows.Forms.Label();
            this.TabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datagridcliente)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.tabPage1);
            this.TabControl1.Location = new System.Drawing.Point(12, 43);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(776, 428);
            this.TabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Cmbbuscar);
            this.tabPage1.Controls.Add(this.Datagridcliente);
            this.tabPage1.Controls.Add(this.lblTotal);
            this.tabPage1.Controls.Add(this.btnbuscar);
            this.tabPage1.Controls.Add(this.txtbuscar);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 402);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Cmbbuscar
            // 
            this.Cmbbuscar.FormattingEnabled = true;
            this.Cmbbuscar.Items.AddRange(new object[] {
            "Apellidos",
            "Documento"});
            this.Cmbbuscar.Location = new System.Drawing.Point(18, 17);
            this.Cmbbuscar.Name = "Cmbbuscar";
            this.Cmbbuscar.Size = new System.Drawing.Size(121, 21);
            this.Cmbbuscar.TabIndex = 8;
            this.Cmbbuscar.Text = "Apellidos";
            // 
            // Datagridcliente
            // 
            this.Datagridcliente.AllowUserToAddRows = false;
            this.Datagridcliente.AllowUserToDeleteRows = false;
            this.Datagridcliente.AllowUserToOrderColumns = true;
            this.Datagridcliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Datagridcliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar});
            this.Datagridcliente.Location = new System.Drawing.Point(18, 102);
            this.Datagridcliente.MultiSelect = false;
            this.Datagridcliente.Name = "Datagridcliente";
            this.Datagridcliente.ReadOnly = true;
            this.Datagridcliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Datagridcliente.Size = new System.Drawing.Size(732, 255);
            this.Datagridcliente.TabIndex = 7;
            this.Datagridcliente.DoubleClick += new System.EventHandler(this.Datagridcliente_DoubleClick);
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(337, 50);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(29, 13);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "label";
            // 
            // btnbuscar
            // 
            this.btnbuscar.Location = new System.Drawing.Point(340, 15);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(75, 23);
            this.btnbuscar.TabIndex = 2;
            this.btnbuscar.Text = "&Buscar";
            this.btnbuscar.UseVisualStyleBackColor = true;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // txtbuscar
            // 
            this.txtbuscar.Location = new System.Drawing.Point(159, 18);
            this.txtbuscar.Name = "txtbuscar";
            this.txtbuscar.Size = new System.Drawing.Size(133, 20);
            this.txtbuscar.TabIndex = 1;
            // 
            // lblpro
            // 
            this.lblpro.AutoSize = true;
            this.lblpro.BackColor = System.Drawing.Color.White;
            this.lblpro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpro.ForeColor = System.Drawing.Color.Green;
            this.lblpro.Location = new System.Drawing.Point(12, 9);
            this.lblpro.Name = "lblpro";
            this.lblpro.Size = new System.Drawing.Size(75, 24);
            this.lblpro.TabIndex = 6;
            this.lblpro.Text = "Cliente";
            // 
            // Frmvistaclienteventa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 471);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.lblpro);
            this.Name = "Frmvistaclienteventa";
            this.Text = "Frmvistaclienteventa";
            this.Load += new System.EventHandler(this.Frmvistaclienteventa_Load);
            this.TabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datagridcliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox Cmbbuscar;
        private System.Windows.Forms.DataGridView Datagridcliente;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Eliminar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnbuscar;
        private System.Windows.Forms.TextBox txtbuscar;
        private System.Windows.Forms.Label lblpro;
    }
}