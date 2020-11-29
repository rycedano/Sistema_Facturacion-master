using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capadatos.SQLserver;
using Capanegocio;

namespace Capapresentacion
{
    public partial class Frmventa : Form
    {
        public Frmventa()
        {
            InitializeComponent();
            Avisos();
        }

        public void Avisos()
        {
            this.Ttmensaje.SetToolTip(this.Txtcliente, "Seleccione un Cliente");
            this.Ttmensaje.SetToolTip(this.Txtserie, "Ingrese una serie del comprobante");
            this.Ttmensaje.SetToolTip(this.Txtcorrelativo, "Ingrese un número del comprobante");
            this.Ttmensaje.SetToolTip(this.Txtcantidad, "Ingrese la Cantidad del Artículo a Vender");
            this.Ttmensaje.SetToolTip(this.Txtarticulo, "Seleccione un Artículo");
            this.Txtidcliente.Visible = false;
            this.Txtidarticulo.Visible = false;
            this.Txtcliente.ReadOnly = true;
            this.Txtarticulo.ReadOnly = true;
            this.Datetimefechavenc.Enabled = false;
            this.Txtpreciocompra.ReadOnly = true;
            this.Txtstockactual.ReadOnly = true;
        }

        private bool IsNuevo = false;
        public int Idtrabajador = Datoscahe.Idusuario;
        private DataTable dtDetalle;
        private decimal totalPagado = 0;
        private static Frmventa _Instancia;


        public static Frmventa Getinstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new Frmventa();
            }
            return _Instancia;
        }

        public void setCliente(string idcliente, string nombre)
        {
            this.Txtidcliente.Text = idcliente;
            this.Txtcliente.Text = nombre;
        }

        public void setArticulo(string iddetalle_ingreso, string nombre,
            decimal precio_compra, decimal precio_venta, int stock,
            DateTime fecha_vencimiento)
        {
            this.Txtidarticulo.Text = iddetalle_ingreso;
            this.Txtarticulo.Text = nombre;
            this.Txtpreciocompra.Text = Convert.ToString(precio_compra);
            this.Txtprecioventa.Text = Convert.ToString(precio_venta);
            this.Txtstockactual.Text = Convert.ToString(stock);
            this.Datetimefechavenc.Value = fecha_vencimiento;
        }

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
            this.Txtidventa.Text = string.Empty;
            this.Txtidcliente.Text = string.Empty;
            this.Txtcliente.Text = string.Empty;
            this.Txtserie.Text = string.Empty;
            this.Txtcorrelativo.Text = string.Empty;
            this.Txtigv.Text = string.Empty;
            this.Lbltotalpagado.Text = "0,0";
            this.Txtigv.Text = "18";
            this.crearTabla();
        }
        private void limpiarDetalle()
        {
            this.Txtidarticulo.Text = string.Empty;
            this.Txtarticulo.Text = string.Empty;
            this.Txtstockactual.Text = string.Empty;
            this.Txtcantidad.Text = string.Empty;
            this.Txtpreciocompra.Text = string.Empty;
            this.Txtprecioventa.Text = string.Empty;
            this.Txtdescuento.Text = string.Empty;
        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.Txtidventa.ReadOnly = !valor;
            this.Txtserie.ReadOnly = !valor;
            this.Txtcorrelativo.ReadOnly = !valor;
            this.Txtigv.ReadOnly = !valor;
            this.Datetimefecha.Enabled = valor;
            this.Cmbcomprovante.Enabled = valor;
            this.Txtcantidad.ReadOnly = !valor;
            this.Txtpreciocompra.ReadOnly = !valor;
            this.Txtprecioventa.ReadOnly = !valor;
            this.Txtstockactual.ReadOnly = !valor;
            this.Txtdescuento.ReadOnly = !valor;
            this.Datetimefechavenc.Enabled = valor;

            this.Btnarticulo.Enabled = valor;
            this.Btnbuscarcliente.Enabled = valor;
            this.Btnagregar.Enabled = valor;
            this.Btnquitar.Enabled = valor;
        }

        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo) //Alt + 124
            {
                this.Habilitar(true);
                this.Btnnuevo.Enabled = false;
                this.Btnguardar.Enabled = true;
                this.Btncancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.Btnnuevo.Enabled = true;
                this.Btnguardar.Enabled = false;
                this.Btncancelar.Enabled = false;
            }

        }

        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.Datagridventaslistado.Columns[0].Visible = false;
            this.Datagridventaslistado.Columns[1].Visible = false;

        }

        //Método Mostrar
        private void Mostrar()
        {
            this.Datagridventaslistado.DataSource = Nventa.Mostrar();
            this.OcultarColumnas();
            Lbltotal.Text = "Total de Registros: " + Convert.ToString(Datagridventaslistado.Rows.Count);
        }

        //Método BuscarFechas
        private void BuscarFechas()
        {
            this.Datagridventaslistado.DataSource = Nventa.BuscarFechas(this.Datetime1.Value.ToString("dd/MM/yyyy"),
                this.Datetime2.Value.ToString("dd/MM/yyyy"));
            this.OcultarColumnas();
            Lbltotal.Text = "Total de Registros: " + Convert.ToString(Datagridventaslistado.Rows.Count);
        }

        private void MostrarDetalle()
        {
            this.Datagridventasmanten.DataSource = Nventa.MostrarDetalle(this.Txtidventa.Text);

        }
        private void crearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("iddetalle_ingreso", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("cantidad", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("descuento", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Impuesto", System.Type.GetType("System.Decimal"));
            //Relacionar nuestro DataGRidView con nuestro DataTable
            this.Datagridventasmanten.DataSource = this.dtDetalle;

        }

        private void Frmventa_Load(object sender, EventArgs e)
        {
            
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.crearTabla();
        }

        private void Frmventa_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void Btnbuscarcliente_Click(object sender, EventArgs e)
        {
            Frmvistaclienteventa Form = new Frmvistaclienteventa();
            Form.ShowDialog();
        }

        private void Btnarticulo_Click(object sender, EventArgs e)
        {
            Frmvistaarticuloventa Form = new Frmvistaarticuloventa();
            Form.ShowDialog();
        }

        private void Btnbuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }

       // DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)Datagridventaslistado.Rows[e.RowIndex].Cells["Eliminar"];
       // ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value)

        private void Btneliminar_Click(object sender, EventArgs e)
        {
            if (Chkeliminar.Checked)
            {
                int Indice = 0;
                if (Convert.ToBoolean(Datagridventaslistado.Rows[Indice].Cells[0].Value) != false)
                {                  
                    try
                    {
                        DialogResult Opcion;
                        Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (Opcion == DialogResult.OK)
                        {
                            string Codigo;
                            string Rpta = "";
                            foreach (DataGridViewRow row in Datagridventaslistado.Rows)
                            {
                                if (Convert.ToBoolean(row.Cells[0].Value))
                                {
                                    Codigo = Convert.ToString(row.Cells[1].Value);
                                    Rpta = Nventa.Eliminar(Convert.ToInt32(Codigo));

                                    if (Rpta.Equals("OK"))
                                    {
                                        this.MensajeOk("Se Eliminó Correctamente la venta");
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
                    Erroricono.SetError(Datagridventaslistado,"Debe seleccionar una venta a Eliminar");
                    MensajeError("Debe seleccionar una venta a Eliminar");
                }
            }
            else
            {
                MensajeError("Debe selecionar el cheque de Eliminar");
                Erroricono.SetError(Chkeliminar,"Debe Marcar la Casilla ");
            }                     
        }

        private void Datagridventaslistado_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Datagridventaslistado_DoubleClick(object sender, EventArgs e)
        {
            this.Txtidventa.Text = Convert.ToString(this.Datagridventaslistado.CurrentRow.Cells["idventa"].Value);
            this.Txtcliente.Text = Convert.ToString(this.Datagridventaslistado.CurrentRow.Cells["cliente"].Value);
            this.Datetimefecha.Value = Convert.ToDateTime(this.Datagridventaslistado.CurrentRow.Cells["fecha"].Value);
            this.Cmbcomprovante.Text = Convert.ToString(this.Datagridventaslistado.CurrentRow.Cells["tipo_comprovante"].Value);
            this.Txtserie.Text = Convert.ToString(this.Datagridventaslistado.CurrentRow.Cells["serie"].Value);
            this.Txtcorrelativo.Text = Convert.ToString(this.Datagridventaslistado.CurrentRow.Cells["correlativo"].Value);
            this.Lbltotalpagado.Text = Convert.ToString(this.Datagridventaslistado.CurrentRow.Cells["total"].Value);
            //this.Txtigv.Text = Convert.ToString(this.Datagridventaslistado.CurrentRow.Cells["Impuesto"].Value);
            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;
        }

        private void Chkeliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkeliminar.Checked)
            {
                this.Datagridventaslistado.Columns[0].Visible = true;
            }
            else
            {
                this.Datagridventaslistado.Columns[0].Visible = false;
            }
        }

        private void Datagridventaslistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Datagridventaslistado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)Datagridventaslistado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
            else
            {
                MensajeError("Debe Seleccionar Una venta a Eliminar");
            }
        }

        private void Btnnuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.limpiarDetalle();
            this.Habilitar(true);
            this.Txtserie.Focus();
        }

        private void Btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.Txtidcliente.Text == string.Empty || this.Txtserie.Text == string.Empty
                    || this.Txtcorrelativo.Text == string.Empty || this.Txtigv.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    Erroricono.SetError(Txtidcliente, "Ingrese un Valor");
                    Erroricono.SetError(Txtserie, "Ingrese un Valor");
                    Erroricono.SetError(Txtcorrelativo, "Ingrese un Valor");
                    Erroricono.SetError(Txtigv, "Ingrese un Valor");
                }
                else
                {

                    if (this.IsNuevo)
                    {
                        rpta = Nventa.Insertar(Convert.ToInt32(this.Txtidcliente.Text), Idtrabajador,
                            Datetimefecha.Value, Cmbcomprovante.Text, Txtserie.Text, Txtcorrelativo.Text,
                            Convert.ToDecimal(Txtigv.Text), dtDetalle);

                    }
                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.Botones();
                    this.Limpiar();
                    this.limpiarDetalle();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Btnagregar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.Txtidarticulo.Text == string.Empty || this.Txtcantidad.Text == string.Empty
                    || this.Txtdescuento.Text == string.Empty || this.Txtprecioventa.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    Erroricono.SetError(Txtidarticulo, "Ingrese un Valor");
                    Erroricono.SetError(Txtcantidad, "Ingrese un Valor");
                    Erroricono.SetError(Txtdescuento, "Ingrese un Valor");
                    Erroricono.SetError(Txtprecioventa, "Ingrese un Valor");
                }
                else
                {
                    bool registrar = true;
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["iddetalle_ingreso"]) == Convert.ToInt32(this.Txtidarticulo.Text))
                        {
                            registrar = false;
                            this.MensajeError("YA se encuentra el artículo en el detalle");
                        }
                    }
                    if (registrar && Convert.ToInt32(Txtcantidad.Text) <= Convert.ToInt32(Txtstockactual.Text))
                    {
                        decimal subTotal = Convert.ToDecimal(this.Txtcantidad.Text) * Convert.ToDecimal(this.Txtprecioventa.Text) - Convert.ToDecimal(this.Txtdescuento.Text);
                        totalPagado += subTotal;
                        this.Lbltotalpagado.Text = totalPagado.ToString("#0.00#");
                        //Agregar ese detalle al datalistadoDetalle
                        DataRow row = this.dtDetalle.NewRow();
                        row["iddetalle_ingreso"] = Convert.ToInt32(this.Txtidarticulo.Text);
                        row["articulo"] = this.Txtarticulo.Text;
                        row["cantidad"] = Convert.ToInt32(this.Txtcantidad.Text);
                        row["precio_venta"] = Convert.ToDecimal(this.Txtprecioventa.Text);
                        row["descuento"] = Convert.ToDecimal(this.Txtdescuento.Text);
                        row["subtotal"] = subTotal;
                        this.dtDetalle.Rows.Add(row);
                        this.limpiarDetalle();

                    }
                    else
                    {
                        MensajeError("No hay Stock Suficiente");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Btnquitar_Click(object sender, EventArgs e)
        {
            try
            {
                int indiceFila = this.Datagridventasmanten.CurrentCell.RowIndex;
                DataRow row = this.dtDetalle.Rows[indiceFila];
                //Disminuir el totalPAgado
                this.totalPagado -= Convert.ToDecimal(row["subtotal"].ToString());
                this.Lbltotalpagado.Text = totalPagado.ToString("#0.00#");
                //Removemos la fila
                this.dtDetalle.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MensajeError("No hay fila para remover" + ex);
            }
        }

        private void Btncomprovante_Click(object sender, EventArgs e)
        {
            Frmreportefactura Form = new Frmreportefactura();
            Form.Idventa = Convert.ToInt32(this.Datagridventaslistado.CurrentRow.Cells["idventa"].Value);
            Form.ShowDialog();
        }
    }
}
