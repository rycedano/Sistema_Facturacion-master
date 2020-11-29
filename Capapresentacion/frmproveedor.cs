using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capanegocio;

namespace Capapresentacion
{
    public partial class frmproveedor : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public frmproveedor()
        {
            InitializeComponent();
            this.ttmensaje.SetToolTip(this.txtrazonsocial, "Ingrese Razón Social del Proveedor");
            this.ttmensaje.SetToolTip(this.txtnumdocumento, "Ingrese Número de Documento del Proveedor");
            this.ttmensaje.SetToolTip(this.txtdireccion, "Ingrese la dirección del Proveedor");
        }

        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtrazonsocial.Text = string.Empty;
            this.txtnumdocumento.Text = string.Empty;
            this.txtdireccion.Text = string.Empty;
            this.txttelefonoprove.Text = string.Empty;
            this.txturlproveedor.Text = string.Empty;
            this.txtemailproveedor.Text = string.Empty;
            this.txtidproveedor.Text = string.Empty;

        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtrazonsocial.ReadOnly = !valor;
            this.txtdireccion.ReadOnly = !valor; 
            this.cmbsectorcomercial.Enabled = valor;
            this.cmbtipodocumento.Enabled = valor;
            this.txtnumdocumento.ReadOnly = !valor;
            this.txttelefonoprove.ReadOnly = !valor;
            this.txturlproveedor.ReadOnly = !valor;
            this.txtemailproveedor.ReadOnly = !valor;
            this.txtidproveedor.ReadOnly = !valor;
        }

        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar) //Alt + 124
            {
                this.Habilitar(true);
                this.btnnuevo.Enabled = false;
                this.btnguardar.Enabled = true;
                this.btneditar.Enabled = false;
                this.btncancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnnuevo.Enabled = true;
                this.btnguardar.Enabled = false;
                this.btneditar.Enabled = true;
                this.btncancelar.Enabled = false;
            }

        }

        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.datagridproveedor.Columns[0].Visible = false;
            this.datagridproveedor.Columns[1].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            this.datagridproveedor.DataSource = Nproveedor.Mostrar();
            this.OcultarColumnas();
            lbltotal.Text = "Total de Registros: " + Convert.ToString(datagridproveedor.Rows.Count);
        }

        //Método BuscarRazon_Social
        private void BuscarRazon_Social()
        {
            this.datagridproveedor.DataSource = Nproveedor.BuscarRazon_social(this.txtbuscar.Text);
            this.OcultarColumnas();
            lbltotal.Text = "Total de Registros: " + Convert.ToString(datagridproveedor.Rows.Count);
        }

        //Método BuscarNum_Documento
        private void BuscarNum_Documento()
        {
            this.datagridproveedor.DataSource = Nproveedor.BuscarNum_Documento(this.txtbuscar.Text);
            this.OcultarColumnas();
            lbltotal.Text = "Total de Registros: " + Convert.ToString(datagridproveedor.Rows.Count);
        }

        private void frmproveedor_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (cmbbuscar.Text.Equals("Razon_Social"))
            {
                this.BuscarRazon_Social();
            }
            else if (cmbbuscar.Text.Equals("Documento"))
            {
                this.BuscarNum_Documento();
            }
        }


        private void btneliminar_Click(object sender, EventArgs e)
        {
            int Indice = 0;
            if (chkeliminar.Checked)
            {
                if (Convert.ToBoolean(datagridproveedor.Rows[Indice].Cells[0].Value)!=false)
                {
                    try
                    {
                        DialogResult opcion;
                        opcion = MessageBox.Show(" Realmente desea eliminar los registros", "Sistema de ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (opcion == DialogResult.OK)
                        {
                            string codigo;
                            string respuesta = "";

                            foreach (DataGridViewRow row in datagridproveedor.Rows)
                            {
                                if (Convert.ToBoolean(row.Cells[0].Value))
                                {
                                    codigo = Convert.ToString(row.Cells[1].Value);
                                    respuesta = Nproveedor.Eliminar(Convert.ToInt32(codigo));

                                    if (respuesta.Equals("OK"))
                                    {
                                        this.MensajeOk(" Se elimino de forma correcta el registro");
                                    }
                                    else
                                    {
                                        this.MensajeError(respuesta);
                                    }
                                }
                            }

                            this.Mostrar();
                            this.chkeliminar.Checked = false;
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message + ex.StackTrace);
                    }
                }
                else
                {
                    MensajeError("Debe Seleccionar un Proveedor");
                    erroricono.SetError(datagridproveedor,"Seleccione un Proveedor");
                }
            }
            else
            {
                MensajeError("Debe Seleccionar la Casilla");
                erroricono.SetError(chkeliminar, "Seleccione la Casilla");
            }
            
        }

        private void chkeliminar_CheckedChanged(object sender, EventArgs e)
        {

            if (chkeliminar.Checked)
            {
                this.datagridproveedor.Columns[0].Visible = true;
            }
            else
            {
                this.datagridproveedor.Columns[0].Visible = false;
            }
        }

        private void datagridproveedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == datagridproveedor.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkeliminar = (DataGridViewCheckBoxCell)datagridproveedor.Rows[e.RowIndex].Cells["Eliminar"];
                chkeliminar.Value = !Convert.ToBoolean(chkeliminar.Value);
            }
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {

            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtrazonsocial.Focus();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if (this.txtrazonsocial.Text == string.Empty || this.txtnumdocumento.Text == string.Empty 
                    || this.txtdireccion.Text == string.Empty)
                {
                    MensajeError(" Faltan ingresar algunos datos");
                    erroricono.SetError(txtrazonsocial, "Ingrese una razon Social");
                    erroricono.SetError(txtnumdocumento, "Ingrese un numero de Documento");
                    erroricono.SetError(txtdireccion, "Ingrese una Direccion");
                }
                else
                {
                    if (this.IsNuevo)
                    {

                        respuesta = Nproveedor.Insertar(this.txtrazonsocial.Text.Trim().ToUpper(),
                            cmbsectorcomercial.Text,cmbtipodocumento.Text,
                            txtnumdocumento.Text,txtdireccion.Text,txttelefonoprove.Text,
                            txtemailproveedor.Text,txturlproveedor.Text);

                    }
                    else
                    {
                        respuesta = Nproveedor.Editar(Convert.ToInt32(this.txtidproveedor.Text),
                          txtrazonsocial.Text.Trim().ToUpper(),
                            cmbsectorcomercial.Text, cmbtipodocumento.Text,
                            txtnumdocumento.Text,txtdireccion.Text,txttelefonoprove.Text,
                            txtemailproveedor.Text,txturlproveedor.Text);

                    }

                    if (respuesta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk(" Se inserto de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk(" Se actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(respuesta);
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

        private void btneditar_Click(object sender, EventArgs e)
        {
            if (!this.txtidproveedor.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);

            }
            else
            {
                this.MensajeError(" Debe selecionar una fila primero");
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.txtidproveedor.Text = string.Empty;
        }

        private void datagridproveedor_DoubleClick(object sender, EventArgs e)
        {

            this.txtidproveedor.Text = Convert.ToString(this.datagridproveedor.CurrentRow.Cells["idproveedor"].Value);
            this.txtrazonsocial.Text = Convert.ToString(this.datagridproveedor.CurrentRow.Cells["razonsocial"].Value);
            this.cmbsectorcomercial.Text = Convert.ToString(this.datagridproveedor.CurrentRow.Cells["sectorcomercial"].Value);
            this.cmbtipodocumento.Text = Convert.ToString(this.datagridproveedor.CurrentRow.Cells["tipodocumento"].Value);
            this.txtnumdocumento.Text = Convert.ToString(this.datagridproveedor.CurrentRow.Cells["Num_documento"].Value);
            this.txtdireccion.Text = Convert.ToString(this.datagridproveedor.CurrentRow.Cells["Direccion"].Value);
            this.txttelefonoprove.Text = Convert.ToString(this.datagridproveedor.CurrentRow.Cells["Telefono"].Value);
            this.txtemailproveedor.Text = Convert.ToString(this.datagridproveedor.CurrentRow.Cells["Email"].Value);
            this.txturlproveedor.Text = Convert.ToString(this.datagridproveedor.CurrentRow.Cells["Url"].Value);

            this.tabControl1.SelectedIndex = 1;
        }
    }
}
