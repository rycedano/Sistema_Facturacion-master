using Capanegocio;
using System;
using System.Windows.Forms;

namespace Capapresentacion
{
    public partial class Frmcliente : Form
    {

        public Frmcliente()
        {
            InitializeComponent();
            this.ttmensaje.SetToolTip(this.Txtnombre, "Ingrese el Nombre del Cliente");
            this.ttmensaje.SetToolTip(this.Txtapellidos, "Ingrese los Apellidos del Cliente");
            this.ttmensaje.SetToolTip(this.Txtdireccion, "Ingrese la dirección del Cliente");
            this.ttmensaje.SetToolTip(this.Txtnumdocumento, "Ingrese el número de documento del Cliente");
        }

        private bool IsNuevo = false;
        private bool IsEditar = false;

        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void Limpiar()
        {
            this.Txtnombre.Text = string.Empty;
            this.Txtapellidos.Text = string.Empty;
            this.Txtnumdocumento.Text = string.Empty;
            this.Txtdireccion.Text = string.Empty;
            this.Txttelefono.Text = string.Empty;
            this.Txtemailcli.Text = string.Empty;
            this.Txtidcliente.Text = string.Empty;

        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.Txtnombre.ReadOnly = !valor;
            this.Txtapellidos.ReadOnly = !valor;
            this.Txtdireccion.ReadOnly = !valor;
            this.Cmbtipodocumento.Enabled = valor;
            this.Txtnumdocumento.ReadOnly = !valor;
            this.Txttelefono.ReadOnly = !valor;
            this.Txtemailcli.ReadOnly = !valor;
            this.Txtidcliente.ReadOnly = !valor;
        }

        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar) //Alt + 124
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }

        }

        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.Datagridcliente.Columns[0].Visible = false;
            this.Datagridcliente.Columns[1].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            this.Datagridcliente.DataSource = Ncliente.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(Datagridcliente.Rows.Count);
        }

        //Método BuscarApellidos
        private void BuscarApellidos()
        {
            this.Datagridcliente.DataSource = Ncliente.BuscarApellidos(this.txtbuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(Datagridcliente.Rows.Count);
        }

        //Método BuscarNum_Documento
        private void BuscarNum_Documento()
        {
            this.Datagridcliente.DataSource = Ncliente.BuscarNum_Documento(this.txtbuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(Datagridcliente.Rows.Count);
        }

        private void Frmcliente_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void Btnbuscar_Click(object sender, EventArgs e)
        {
            if (Cmbbuscar.Text.Equals("Apellidos"))
            {
                this.BuscarApellidos();
            }
            else if (Cmbbuscar.Text.Equals("Documento"))
            {
                this.BuscarNum_Documento();
            }
        }

        private void Btneliminar_Click(object sender, EventArgs e)
        {
            int Indice = 0;
            if (Chkeliminar.Checked)
            {
                if (Convert.ToBoolean(Datagridcliente.Rows[Indice].Cells[0].Value)!=false)
                {
                    try
                    {
                        DialogResult Opcion;
                        Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (Opcion == DialogResult.OK)
                        {
                            string Codigo;
                            string Rpta = "";

                            foreach (DataGridViewRow row in Datagridcliente.Rows)
                            {
                                if (Convert.ToBoolean(row.Cells[0].Value))
                                {
                                    Codigo = Convert.ToString(row.Cells[1].Value);
                                    Rpta = Ncliente.Eliminar(Convert.ToInt32(Codigo));

                                    if (Rpta.Equals("OK"))
                                    {
                                        this.MensajeOk("Se Eliminó Correctamente el registro");
                                    }
                                    else
                                    {
                                        this.MensajeError(Rpta);
                                    }

                                }
                            }
                            this.Mostrar();
                            this.Chkeliminar.Checked = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + ex.StackTrace);
                    }
                }
                else
                {
                    MensajeError("Debe Seleccionar un Cliente a Eliminar");
                    Erroricono.SetError(Datagridcliente, "Selecione un Cliente");
                }
            }
            else
            {
                MensajeError("Debe Seleccionar la Casilla");
                Erroricono.SetError(Chkeliminar,"Selecione la Casilla");
            }
          
        }

        private void Chkeliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkeliminar.Checked)
            {
                this.Datagridcliente.Columns[0].Visible = true;
            }
            else
            {
                this.Datagridcliente.Columns[0].Visible = false;
            }
        }

        private void Datagridcliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Datagridcliente.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)Datagridcliente.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void Datagridcliente_DoubleClick(object sender, EventArgs e)
        {
            this.Txtidcliente.Text = Convert.ToString(this.Datagridcliente.CurrentRow.Cells["idcliente"].Value);
            this.Txtnombre.Text = Convert.ToString(this.Datagridcliente.CurrentRow.Cells["Nombre"].Value);
            this.Txtapellidos.Text = Convert.ToString(this.Datagridcliente.CurrentRow.Cells["Apellido"].Value);
            this.Cmbsexo.Text = Convert.ToString(this.Datagridcliente.CurrentRow.Cells["Sexo"].Value);
            this.Dtfechanacimiento.Value = Convert.ToDateTime(this.Datagridcliente.CurrentRow.Cells["Fecha_nacimiento"].Value);
            this.Cmbtipodocumento.Text = Convert.ToString(this.Datagridcliente.CurrentRow.Cells["tipo_docu"].Value);
            this.Txtnumdocumento.Text = Convert.ToString(this.Datagridcliente.CurrentRow.Cells["num_doc"].Value);
            this.Txtdireccion.Text = Convert.ToString(this.Datagridcliente.CurrentRow.Cells["Direccion"].Value);
            this.Txttelefono.Text = Convert.ToString(this.Datagridcliente.CurrentRow.Cells["Telefono"].Value);
            this.Txtemailcli.Text = Convert.ToString(this.Datagridcliente.CurrentRow.Cells["Email"].Value);

            this.TabControl1.SelectedIndex = 1;
        }

        private void Btnnuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.Txtnombre.Focus();
        }

        private void Btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (this.Txtnombre.Text == string.Empty || this.Txtapellidos.Text == string.Empty ||
                    this.Txtnumdocumento.Text == string.Empty
                    || this.Txtdireccion.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");   
                    Erroricono.SetError(Txtnombre, "Ingrese un Valor");
                    Erroricono.SetError(Txtapellidos, "Ingrese un Valor");
                    Erroricono.SetError(Txtnumdocumento, "Ingrese un Valor");
                    Erroricono.SetError(Txtdireccion, "Ingrese un Valor");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        Rpta = Ncliente.Insertar(this.Txtnombre.Text.Trim().ToUpper(),
                            this.Txtapellidos.Text.Trim().ToUpper(),
                            this.Cmbsexo.Text, Dtfechanacimiento.Value, Cmbtipodocumento.Text,
                            Txtnumdocumento.Text, Txtdireccion.Text, Txttelefono.Text,
                            Txtemailcli.Text);

                    }
                    else
                    {
                        Rpta = Ncliente.Editar(Convert.ToInt32(this.Txtidcliente.Text),
                            this.Txtnombre.Text.Trim().ToUpper(),
                            this.Txtapellidos.Text.Trim().ToUpper(),
                            this.Cmbsexo.Text, Dtfechanacimiento.Value, Cmbtipodocumento.Text,
                            Txtnumdocumento.Text, Txtdireccion.Text, Txttelefono.Text,
                            Txtemailcli.Text);
                    }

                    if (Rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Btneditar_Click(object sender, EventArgs e)
        {

            if (!this.Txtidcliente.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a Modificar");
            }
        }

        private void Btncancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Habilitar(false);
            this.Limpiar();
            this.Txtidcliente.Text = string.Empty;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
