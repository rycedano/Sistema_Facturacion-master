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
    public partial class frmpresentacion : Form
    {
        public frmpresentacion()
        {
            InitializeComponent();
            this.ttmensaje.SetToolTip(this.txtnombre, "Ingrese el Nombre de la Presentacion");
        }

        private bool Isnuevo = false;
        private bool Iseditar = false;

        private void Mensajeok(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Mensajeerror(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void limpiar()
        {
            this.txtnombre.Text = string.Empty;
            this.txtdescripcion.Text = string.Empty;
            this.txtidpresentacion.Text = string.Empty;
        }

        private void habilitar(bool valor)
        {
            this.txtnombre.ReadOnly = !valor;
            this.txtdescripcion.ReadOnly = !valor;
            this.txtidpresentacion.ReadOnly = !valor;
        }



        private void Botones()
        {
            if (this.Isnuevo || this.Iseditar)
            {
                this.habilitar(true);
                this.btnnuevo.Enabled = false;
                this.btnguardar.Enabled = true;
                this.btneditar.Enabled = false;
                this.btncancelar.Enabled = true;

            }
            else
            {
                this.habilitar(true);
                this.btnnuevo.Enabled = true;
                this.btnguardar.Enabled = false;
                this.btneditar.Enabled = true;
                this.btncancelar.Enabled = false;
            }
        }

        private void ocultarcolumnas()
        {
            this.datagridcategoria.Columns[0].Visible = false;
            this.datagridcategoria.Columns[1].Visible = false;
        }


        public void mostrar()
        {
            this.datagridcategoria.DataSource = Npresentacion.Mostrar();
            this.ocultarcolumnas();
            label2.Text = "Total de registros" + Convert.ToString(datagridcategoria.Rows.Count);
        }

        public void buscarnombre()
        {
            this.datagridcategoria.DataSource = Npresentacion.BuscarNombre(txtbuscar.Text);
            this.ocultarcolumnas();
            label2.Text = "Total de registros" + Convert.ToString(datagridcategoria.Rows.Count);
        }


        private void frmpresentacion_Load(object sender, EventArgs e)
        {

            this.mostrar();
            this.habilitar(false);
            this.Botones();
        }

        private void Btnbuscar_Click(object sender, EventArgs e)
        {
            this.buscarnombre();
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            this.buscarnombre();
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            this.Isnuevo = true;
            this.Iseditar = false;
            this.Botones();
            this.limpiar();
            this.habilitar(true);
            this.txtnombre.Focus();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if (this.txtnombre.Text == string.Empty)
                {
                    Mensajeerror(" Faltan ingresar algunos datos");
                    erroricono.SetError(txtnombre, "Ingrese un Nombre");
                }
                else
                {
                    if (this.Isnuevo)
                    {

                        respuesta = Npresentacion.Insertar(this.txtnombre.Text.Trim().ToUpper(), this.txtdescripcion.Text.Trim());

                    }
                    else
                    {
                        respuesta = Npresentacion.Editar(Convert.ToInt32(this.txtidpresentacion.Text),
                            this.txtnombre.Text.Trim().ToUpper(), this.txtdescripcion.Text.Trim());

                    }

                    if (respuesta.Equals("OK"))
                    {
                        if (this.Isnuevo)
                        {
                            this.Mensajeok(" Se inserto de forma correcta el registro");
                        }
                        else
                        {
                            this.Mensajeok(" Se actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.Mensajeerror(respuesta);
                    }

                    this.Isnuevo = false;
                    this.Iseditar = false;
                    this.Botones();
                    this.limpiar();
                    this.mostrar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if (!this.txtidpresentacion.Text.Equals(""))
            {
                this.Iseditar = true;
                this.Botones();
                this.habilitar(true);

            }
            else
            {
                this.Mensajeerror(" Debe selecionar una fila primero");
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {

            this.Isnuevo = false;
            this.Iseditar = false;
            this.Botones();
            this.limpiar();
            this.habilitar(false);
        }

        private void btneliminar_Click(object sender, EventArgs e)
        { int Indice = 0;
            if (chkeliminar.Checked)
            {
                if (Convert.ToBoolean(datagridcategoria.Rows[Indice].Cells[0].Value)!=false)
                {
                    try
                    {
                        DialogResult opcion;
                        opcion = MessageBox.Show(" Realmente desea eliminar los registros", "Sistema de ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (opcion == DialogResult.OK)
                        {
                            string codigo;
                            string respuesta = "";

                            foreach (DataGridViewRow row in datagridcategoria.Rows)
                            {
                                if (Convert.ToBoolean(row.Cells[0].Value))
                                {
                                    codigo = Convert.ToString(row.Cells[1].Value);
                                    respuesta = Npresentacion.Eliminar(Convert.ToInt32(codigo));

                                    if (respuesta.Equals("OK"))
                                    {
                                        this.Mensajeok(" Se elimino de forma correcta el registro");
                                    }
                                    else
                                    {
                                        this.Mensajeerror(respuesta);
                                    }
                                }
                            }

                            this.mostrar();
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
                    Mensajeerror("Debe Seleccionar una Presentacion a Eliminar");
                    erroricono.SetError(datagridcategoria,"Selecione una Categoria");
                }
            }
            else
            {
                Mensajeerror("Debe Seleccionar la Casilla de Eliminar");
                erroricono.SetError(chkeliminar, "Seleccione la casilla");
            }          
        }

        private void chkeliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkeliminar.Checked)
            {
                this.datagridcategoria.Columns[0].Visible = true;
            }
            else
            {
                this.datagridcategoria.Columns[0].Visible = false;
            }
        }

        private void datagridcategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == datagridcategoria.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkeliminar = (DataGridViewCheckBoxCell)datagridcategoria.Rows[e.RowIndex].Cells["Eliminar"];
                chkeliminar.Value = !Convert.ToBoolean(chkeliminar.Value);
            }
        }

        private void datagridcategoria_DoubleClick(object sender, EventArgs e)
        {
            this.txtidpresentacion.Text = Convert.ToString(this.datagridcategoria.CurrentRow.Cells["idpresentacion"].Value);
            this.txtnombre.Text = Convert.ToString(this.datagridcategoria.CurrentRow.Cells["Nombre"].Value);
            this.txtdescripcion.Text = Convert.ToString(this.datagridcategoria.CurrentRow.Cells["descripcion"].Value);

            this.tabControl1.SelectedIndex = 1;
        }
    }
    
}
