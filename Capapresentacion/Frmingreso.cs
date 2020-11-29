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
    public partial class Frmingreso : Form
    {
        public Frmingreso()
        {
            InitializeComponent();
            this.Ttmensaje.SetToolTip(this.Txtnombreproveedor, "Seleccione el Proveedor");
            this.Ttmensaje.SetToolTip(this.Txtserie, "Ingrese la serie del comprobante");
            this.Ttmensaje.SetToolTip(this.Txtcorrelativo, "Ingrese el número del comprobante");
            this.Ttmensaje.SetToolTip(this.Txtstockinicial, "Ingrese la cantidad de compra");
            this.Ttmensaje.SetToolTip(this.Txtarticulo, "Seleccione el Artículo de compra");
            this.Txtidproveedor.Visible = false;
            this.Txtidarticulo.Visible = false;
            this.Txtnombreproveedor.ReadOnly = true;
            this.Txtarticulo.ReadOnly = true;
        }

        
        public int Idtrabajador = Datoscahe.Idusuario; 
        private bool IsNuevo;
        private DataTable DtDetalle;
        private decimal TotalPagado = 0;
        private static Frmingreso _instancia;

        public static Frmingreso GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new Frmingreso();
            }
            return _instancia;
        }


        public void SetProveedor(string idproveedor, string nombre)
        {
            this.Txtidproveedor.Text = idproveedor;
            this.Txtnombreproveedor.Text = nombre;
        }

        public void SetArticulo(string idarticulo, string nombre)
        {
            this.Txtidarticulo.Text = idarticulo;
            this.Txtarticulo.Text = nombre;
        }


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
            this.Txtidingreso.Text = string.Empty;
            this.Txtidproveedor.Text = string.Empty;
            this.Txtnombreproveedor.Text = string.Empty;
            this.Txtserie.Text = string.Empty;
            this.Txtcorrelativo.Text = string.Empty;
            this.Txtigv.Text = string.Empty;
            this.Lbltotalpagado.Text = "0,0";
            this.Txtigv.Text = "18";
            this.CrearTabla();
        }
        private void LimpiarDetalle()
        {
            this.Txtidarticulo.Text = string.Empty;
            this.Txtarticulo.Text = string.Empty;
            this.Txtstockinicial.Text = string.Empty;
            this.Txtpreciocompra.Text = string.Empty;
            this.Txtprecioventa.Text = string.Empty;
        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.Txtidingreso.ReadOnly = !valor;
            this.Txtserie.ReadOnly = !valor;
            this.Txtcorrelativo.ReadOnly = !valor;
            this.Txtigv.ReadOnly = !valor;
            this.Datetimefecha.Enabled = valor;
            this.Cmbcomprovante.Enabled = valor;
            this.Txtstockinicial.ReadOnly = !valor;
            this.Txtpreciocompra.ReadOnly = !valor;
            this.Txtprecioventa.ReadOnly = !valor;
            this.Datetimefechaprod.Enabled = valor;
            this.Datetimefechavenc.Enabled = valor;

            this.Btnarticulo.Enabled = valor;
            this.Btnproveedor.Enabled = valor;
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
            this.Datagridingresodetalle.Columns[0].Visible = false;
            this.Datagridingresodetalle.Columns[1].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            this.Datagridingresodetalle.DataSource = Ningreso.Mostrar();
            this.OcultarColumnas();
            Lbltotal.Text = "Total de Registros: " + Convert.ToString(Datagridingresodetalle.Rows.Count);
        }

        //Método BuscarFechas
        private void BuscarFechas()
        {
            this.Datagridingresodetalle.DataSource = Ningreso.BuscarFechas(this.Datetime1.Value.ToString("dd/MM/yyyy"),
                this.Datetime2.Value.ToString("dd/MM/yyyy"));
            this.OcultarColumnas();
            Lbltotal.Text = "Total de Registros: " + Convert.ToString(Datagridingresodetalle.Rows.Count);
        }

        private void MostrarDetalle()
        {
            this.Datagridingreso.DataSource = Ningreso.MostrarDetalle(this.Txtidingreso.Text);

        }
        private void CrearTabla()
        {
            this.DtDetalle = new DataTable("Detalle");
            this.DtDetalle.Columns.Add("idarticulo", System.Type.GetType("System.Int32"));
            this.DtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            this.DtDetalle.Columns.Add("precio_compra", System.Type.GetType("System.Decimal"));
            this.DtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));
            this.DtDetalle.Columns.Add("stock_inicial", System.Type.GetType("System.Int32"));
            this.DtDetalle.Columns.Add("fecha_produccion", System.Type.GetType("System.DateTime"));
            this.DtDetalle.Columns.Add("fecha_vencimiento", System.Type.GetType("System.DateTime"));
            this.DtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
            this.DtDetalle.Columns.Add("Impuesto", System.Type.GetType("System.Decimal"));
            //Relacionar nuestro DataGRidView con nuestro DataTable
            this.Datagridingreso.DataSource = this.DtDetalle;
        }

        private void Btnproveedor_Click(object sender, EventArgs e)
        {
              Vistaproveedor_ingreso  Form = new Vistaproveedor_ingreso();
              Form.ShowDialog();
        }

        private void Btnarticulo_Click(object sender, EventArgs e)
        {
              Frmvistaarticulo_ingreso  Form = new Frmvistaarticulo_ingreso();
              Form.ShowDialog();
        }
         
        private void Btnbuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }

        private void Btnanular_Click(object sender, EventArgs e)
        {

            if (Chkanular.Checked) 
            {
                 int Indice = 0;
                if (Convert.ToBoolean(Datagridingresodetalle.Rows[Indice].Cells[0].Value) != false)
                {
                    try
                    {
                        DialogResult Opcion;
                        Opcion = MessageBox.Show("Realmente Desea Anular los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (Opcion == DialogResult.OK)
                        {
                            string Codigo;
                            string Rpta = "";

                            foreach (DataGridViewRow row in Datagridingresodetalle.Rows)
                            {
                                if (Convert.ToBoolean(row.Cells[0].Value))
                                {
                                    Codigo = Convert.ToString(row.Cells[1].Value);
                                    Rpta = Ningreso.Anular(Convert.ToInt32(Codigo));

                                    if (Rpta.Equals("OK"))
                                    {
                                        this.MensajeOk("Se Anuló Correctamente el Ingreso");
                                    }
                                    else
                                    {
                                        this.MensajeError(Rpta);
                                    }
                                }
                            }
                            this.Mostrar();
                            this.Chkanular.Checked = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + ex.StackTrace);
                    }
                }
                else
                {
                    Erroricono.SetError(Datagridingresodetalle, "Debe Seleccionar un Ingreso a Anular");
                    MensajeError("Seleccione el ingreso a Anular");
                }
              
            }
            else
            {
                MensajeError("Debe Selecionar La casilla de anular primero");
                Erroricono.SetError(Chkanular,"Debe checar para poder Anular");
            }
        }

        private void Chkanular_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkanular.Checked)
            {
                this.Datagridingresodetalle.Columns[0].Visible = true;
            }
            else
            {
                this.Datagridingresodetalle.Columns[0].Visible = false;
            }
        }

        private void Datagridingresodetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Datagridingresodetalle.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)Datagridingresodetalle.Rows[e.RowIndex].Cells["Eliminar"];

                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void Btnnuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.Txtserie.Focus();
            this.LimpiarDetalle();
        }

        private void Btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (this.Txtidproveedor.Text == string.Empty || this.Txtserie.Text == string.Empty
                    || this.Txtcorrelativo.Text == string.Empty || this.Txtigv.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    Erroricono.SetError(Txtidproveedor, "Ingrese un Valor");
                    Erroricono.SetError(Txtserie, "Ingrese un Valor");
                    Erroricono.SetError(Txtcorrelativo, "Ingrese un Valor");
                    Erroricono.SetError(Txtigv, "Ingrese un Valor");
                }
                else
                {
                   if (this.IsNuevo)
                    {
                        Rpta = Ningreso.Insertar3(this.Idtrabajador, Convert.ToInt32(this.Txtidproveedor.Text),
                            Datetimefecha.Value, Cmbcomprovante.Text, Txtserie.Text, Txtcorrelativo.Text,
                            Convert.ToDecimal(Txtigv.Text), "EMITIDO", DtDetalle);

                    }
                    if (Rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }

                    this.IsNuevo = false;
                    this.Botones();
                    this.Limpiar();
                    this.LimpiarDetalle();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" +ex.Message);
            }
        }

        private void Btncancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.LimpiarDetalle();
        }

        private void Btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Txtidarticulo.Text == string.Empty || this.Txtstockinicial.Text == string.Empty
                    || this.Txtpreciocompra.Text == string.Empty || this.Txtprecioventa.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    Erroricono.SetError(Txtidarticulo, "Ingrese un Valor");
                    Erroricono.SetError(Txtstockinicial, "Ingrese un Valor");
                    Erroricono.SetError(Txtpreciocompra, "Ingrese un Valor");
                    Erroricono.SetError(Txtprecioventa, "Ingrese un Valor");
                }
                else
                {
                    bool registrar = true;
                    foreach (DataRow row in DtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["idarticulo"]) == Convert.ToInt32(this.Txtidarticulo.Text))
                        {
                            registrar = false;
                            this.MensajeError("YA se encuentra el artículo en el detalle");
                        }
                    }
                    if (registrar)
                    {
                        decimal subTotal = Convert.ToDecimal(this.Txtstockinicial.Text) * Convert.ToDecimal(this.Txtpreciocompra.Text);
                        TotalPagado += subTotal;
                        this.Lbltotalpagado.Text = TotalPagado.ToString("#0.00#");
                        //Agregar ese detalle al datalistadoDetalle
                        DataRow row = this.DtDetalle.NewRow();
                        row["idarticulo"] = Convert.ToInt32(this.Txtidarticulo.Text);
                        row["articulo"] = this.Txtarticulo.Text;
                        row["precio_compra"] = Convert.ToDecimal(this.Txtpreciocompra.Text);
                        row["precio_venta"] = Convert.ToDecimal(this.Txtprecioventa.Text);
                        row["stock_inicial"] = Convert.ToInt32(this.Txtstockinicial.Text);
                        row["fecha_produccion"] = Datetimefechaprod.Value;
                        row["fecha_vencimiento"] = Datetimefechavenc.Value;
                        row["subtotal"] = subTotal;
                        this.DtDetalle.Rows.Add(row);
                        this.LimpiarDetalle();
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
                int indiceFila = this.Datagridingreso.CurrentCell.RowIndex;
                DataRow row = this.DtDetalle.Rows[indiceFila];
                //Disminuir el totalPAgado
                this.TotalPagado -= Convert.ToDecimal(row["subtotal"].ToString());
                this.Lbltotal_pagado.Text = TotalPagado.ToString("#0.00#");
                //Removemos la fila
                this.DtDetalle.Rows.Remove(row);
            }
            catch (Exception )
            {
                MensajeError("No hay fila para remover");
            }
        }

        private void Datagridingresodetalle_DoubleClick(object sender, EventArgs e)
        {
            this.Txtidingreso.Text = Convert.ToString(this.Datagridingresodetalle.CurrentRow.Cells["idingreso"].Value);
            this.Txtnombreproveedor.Text = Convert.ToString(this.Datagridingresodetalle.CurrentRow.Cells["Proveedor"].Value);
            this.Datetimefecha.Value = Convert.ToDateTime(this.Datagridingresodetalle.CurrentRow.Cells["fecha"].Value);
            this.Cmbcomprovante.Text = Convert.ToString(this.Datagridingresodetalle.CurrentRow.Cells["tipo_comprovante"].Value);
            this.Txtserie.Text = Convert.ToString(this.Datagridingresodetalle.CurrentRow.Cells["serie"].Value);
            this.Txtcorrelativo.Text = Convert.ToString(this.Datagridingresodetalle.CurrentRow.Cells["correlativo"].Value);
            this.Lbltotal_pagado.Text = Convert.ToString(this.Datagridingresodetalle.CurrentRow.Cells["total"].Value);
            this.Txtigv.Text = Convert.ToString(this.Datagridingresodetalle.CurrentRow.Cells["Impuesto"].Value);
            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1; 
        }

        private void Frmingreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void Frmingreso_Load(object sender, EventArgs e)
        {
            this.Mostrar(); 
            this.Habilitar(false);
            this.Botones(); 
            this.CrearTabla();

        }
    }    
}
