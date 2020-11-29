namespace Capapresentacion
{
    partial class Frmcliente
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
            this.Txtemailcli = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Txttelefono = new System.Windows.Forms.TextBox();
            this.Txtnumdocumento = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Cmbtipodocumento = new System.Windows.Forms.ComboBox();
            this.Dtfechanacimiento = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.Cmbsexo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Txtapellidos = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Txtdireccion = new System.Windows.Forms.TextBox();
            this.Txtnombre = new System.Windows.Forms.TextBox();
            this.Txtidcliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Cmbbuscar = new System.Windows.Forms.ComboBox();
            this.Datagridcliente = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.Chkeliminar = new System.Windows.Forms.CheckBox();
            this.btnimprimir = new System.Windows.Forms.Button();
            this.btneliminar = new System.Windows.Forms.Button();
            this.btnbuscar = new System.Windows.Forms.Button();
            this.txtbuscar = new System.Windows.Forms.TextBox();
            this.lblpro = new System.Windows.Forms.Label();
            this.Erroricono = new System.Windows.Forms.ErrorProvider(this.components);
            this.ttmensaje = new System.Windows.Forms.ToolTip(this.components);
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datagridcliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Erroricono)).BeginInit();
            this.SuspendLayout();
            // 
            // Txtemailcli
            // 
            this.Txtemailcli.Location = new System.Drawing.Point(520, 116);
            this.Txtemailcli.Name = "Txtemailcli";
            this.Txtemailcli.Size = new System.Drawing.Size(179, 20);
            this.Txtemailcli.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(445, 119);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Email:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(445, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Telefono:";
            // 
            // Txttelefono
            // 
            this.Txttelefono.Location = new System.Drawing.Point(520, 155);
            this.Txttelefono.Name = "Txttelefono";
            this.Txttelefono.Size = new System.Drawing.Size(179, 20);
            this.Txttelefono.TabIndex = 17;
            // 
            // Txtnumdocumento
            // 
            this.Txtnumdocumento.Location = new System.Drawing.Point(127, 151);
            this.Txtnumdocumento.Name = "Txtnumdocumento";
            this.Txtnumdocumento.Size = new System.Drawing.Size(179, 20);
            this.Txtnumdocumento.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Numero Documento:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 402);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimiento";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.Cmbtipodocumento);
            this.groupBox1.Controls.Add(this.Dtfechanacimiento);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Cmbsexo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Txtapellidos);
            this.groupBox1.Controls.Add(this.Txtemailcli);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.Txttelefono);
            this.groupBox1.Controls.Add(this.Txtnumdocumento);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnNuevo);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.btnEditar);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Txtdireccion);
            this.groupBox1.Controls.Add(this.Txtnombre);
            this.groupBox1.Controls.Add(this.Txtidcliente);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(18, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(729, 375);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "tipodocumento:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // Cmbtipodocumento
            // 
            this.Cmbtipodocumento.FormattingEnabled = true;
            this.Cmbtipodocumento.Items.AddRange(new object[] {
            "Dni",
            "Passport",
            "Cedula"});
            this.Cmbtipodocumento.Location = new System.Drawing.Point(127, 116);
            this.Cmbtipodocumento.Name = "Cmbtipodocumento";
            this.Cmbtipodocumento.Size = new System.Drawing.Size(121, 21);
            this.Cmbtipodocumento.TabIndex = 29;
            this.Cmbtipodocumento.Text = "Cedula";
            // 
            // Dtfechanacimiento
            // 
            this.Dtfechanacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtfechanacimiento.Location = new System.Drawing.Point(355, 186);
            this.Dtfechanacimiento.Name = "Dtfechanacimiento";
            this.Dtfechanacimiento.Size = new System.Drawing.Size(84, 20);
            this.Dtfechanacimiento.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(253, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Fecha Nacimiento:";
            // 
            // Cmbsexo
            // 
            this.Cmbsexo.FormattingEnabled = true;
            this.Cmbsexo.Items.AddRange(new object[] {
            "F",
            "M"});
            this.Cmbsexo.Location = new System.Drawing.Point(127, 183);
            this.Cmbsexo.Name = "Cmbsexo";
            this.Cmbsexo.Size = new System.Drawing.Size(121, 21);
            this.Cmbsexo.TabIndex = 26;
            this.Cmbsexo.Text = "F";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Sexo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(445, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Apellidos:";
            // 
            // Txtapellidos
            // 
            this.Txtapellidos.Location = new System.Drawing.Point(520, 63);
            this.Txtapellidos.Name = "Txtapellidos";
            this.Txtapellidos.Size = new System.Drawing.Size(192, 20);
            this.Txtapellidos.TabIndex = 23;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(394, 298);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 10;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.Btnnuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(475, 298);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.Btnguardar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(556, 298);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 8;
            this.btnEditar.Text = "E&ditar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.Btneditar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(637, 298);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.Btncancelar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Direccion:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nombre:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Txtdireccion
            // 
            this.Txtdireccion.Location = new System.Drawing.Point(127, 225);
            this.Txtdireccion.Multiline = true;
            this.Txtdireccion.Name = "Txtdireccion";
            this.Txtdireccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Txtdireccion.Size = new System.Drawing.Size(244, 67);
            this.Txtdireccion.TabIndex = 3;
            // 
            // Txtnombre
            // 
            this.Txtnombre.Location = new System.Drawing.Point(127, 70);
            this.Txtnombre.Name = "Txtnombre";
            this.Txtnombre.Size = new System.Drawing.Size(244, 20);
            this.Txtnombre.TabIndex = 2;
            // 
            // Txtidcliente
            // 
            this.Txtidcliente.Location = new System.Drawing.Point(127, 25);
            this.Txtidcliente.Name = "Txtidcliente";
            this.Txtidcliente.Size = new System.Drawing.Size(133, 20);
            this.Txtidcliente.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Codigo";
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.tabPage1);
            this.TabControl1.Controls.Add(this.tabPage2);
            this.TabControl1.Location = new System.Drawing.Point(12, 51);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(776, 428);
            this.TabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Cmbbuscar);
            this.tabPage1.Controls.Add(this.Datagridcliente);
            this.tabPage1.Controls.Add(this.lblTotal);
            this.tabPage1.Controls.Add(this.Chkeliminar);
            this.tabPage1.Controls.Add(this.btnimprimir);
            this.tabPage1.Controls.Add(this.btneliminar);
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
            this.Datagridcliente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Datagridcliente_CellContentClick);
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
            // Chkeliminar
            // 
            this.Chkeliminar.AutoSize = true;
            this.Chkeliminar.Location = new System.Drawing.Point(18, 59);
            this.Chkeliminar.Name = "Chkeliminar";
            this.Chkeliminar.Size = new System.Drawing.Size(61, 17);
            this.Chkeliminar.TabIndex = 5;
            this.Chkeliminar.Text = "eliminar";
            this.Chkeliminar.UseVisualStyleBackColor = true;
            this.Chkeliminar.CheckedChanged += new System.EventHandler(this.Chkeliminar_CheckedChanged);
            // 
            // btnimprimir
            // 
            this.btnimprimir.Location = new System.Drawing.Point(412, 15);
            this.btnimprimir.Name = "btnimprimir";
            this.btnimprimir.Size = new System.Drawing.Size(75, 23);
            this.btnimprimir.TabIndex = 4;
            this.btnimprimir.Text = "&Imprimir";
            this.btnimprimir.UseVisualStyleBackColor = true;
            // 
            // btneliminar
            // 
            this.btneliminar.Location = new System.Drawing.Point(306, 15);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(75, 23);
            this.btneliminar.TabIndex = 3;
            this.btneliminar.Text = "&Eliminar";
            this.btneliminar.UseVisualStyleBackColor = true;
            this.btneliminar.Click += new System.EventHandler(this.Btneliminar_Click);
            // 
            // btnbuscar
            // 
            this.btnbuscar.Location = new System.Drawing.Point(195, 15);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(75, 23);
            this.btnbuscar.TabIndex = 2;
            this.btnbuscar.Text = "&Buscar";
            this.btnbuscar.UseVisualStyleBackColor = true;
            this.btnbuscar.Click += new System.EventHandler(this.Btnbuscar_Click);
            // 
            // txtbuscar
            // 
            this.txtbuscar.Location = new System.Drawing.Point(160, 50);
            this.txtbuscar.Name = "txtbuscar";
            this.txtbuscar.Size = new System.Drawing.Size(100, 20);
            this.txtbuscar.TabIndex = 1;
            // 
            // lblpro
            // 
            this.lblpro.AutoSize = true;
            this.lblpro.BackColor = System.Drawing.Color.White;
            this.lblpro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpro.ForeColor = System.Drawing.Color.Green;
            this.lblpro.Location = new System.Drawing.Point(12, 11);
            this.lblpro.Name = "lblpro";
            this.lblpro.Size = new System.Drawing.Size(75, 24);
            this.lblpro.TabIndex = 4;
            this.lblpro.Text = "Cliente";
            // 
            // Erroricono
            // 
            this.Erroricono.ContainerControl = this;
            // 
            // ttmensaje
            // 
            this.ttmensaje.IsBalloon = true;
            // 
            // Frmcliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 485);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.lblpro);
            this.Name = "Frmcliente";
            this.Text = "Frmcliente";
            this.Load += new System.EventHandler(this.Frmcliente_Load);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datagridcliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Erroricono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Txtemailcli;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Txttelefono;
        private System.Windows.Forms.TextBox Txtnumdocumento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Txtdireccion;
        private System.Windows.Forms.TextBox Txtnombre;
        public System.Windows.Forms.TextBox Txtidcliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl TabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox Cmbbuscar;
        private System.Windows.Forms.DataGridView Datagridcliente;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Eliminar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.CheckBox Chkeliminar;
        private System.Windows.Forms.Button btnimprimir;
        private System.Windows.Forms.Button btneliminar;
        private System.Windows.Forms.Button btnbuscar;
        private System.Windows.Forms.TextBox txtbuscar;
        private System.Windows.Forms.Label lblpro;
        private System.Windows.Forms.ErrorProvider Erroricono;
        private System.Windows.Forms.ToolTip ttmensaje;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txtapellidos;
        private System.Windows.Forms.ComboBox Cmbsexo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker Dtfechanacimiento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Cmbtipodocumento;
    }
}