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
using Microsoft.Win32;



namespace Capapresentacion
{
    public partial class frmarticulo : Form
    {
        public frmarticulo()
        {
            InitializeComponent();
            this.ttmensaje.SetToolTip(this.txtnombre, "Ingrese el Nombre del Articulo");
            this.ttmensaje.SetToolTip(this.picimagen, "Ingrese la imagen del Articulo");
            this.ttmensaje.SetToolTip(this.txtcategoria, " Seleccione  la categoria del Articulo");
            this.ttmensaje.SetToolTip(this.cmbidpresentacion, " Seleccione la presentacion del Articulo");
            this.txtidcategoria.Visible = false;
            this.txtcategoria.ReadOnly = true;

            this.Llenarcombopre();

            
        }

        private bool Isnuevo = false;
        private bool Iseditar = false;
        private static frmarticulo _Instancia;

        public static frmarticulo Getinstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmarticulo();
            }
            return _Instancia;
        }

        public void Setcategoria(string idcategoria, string nombrecat)
        {
            this.txtidcategoria.Text = idcategoria;
            this.txtcategoria.Text = nombrecat;
        }

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
            this.txtcodigo.Text = string.Empty;
            this.txtnombre.Text = string.Empty;
            this.txtdescripcion.Text = string.Empty;
            this.txtidcategoria.Text = string.Empty;
            this.txtcategoria.Text = string.Empty;
            this.txtidarticulo.Text = string.Empty;
            this.picimagen.Image = global::Capapresentacion.Properties.Resource1.file;
        }

        private void habilitar(bool valor)
        {
            this.txtcodigo.ReadOnly = !valor;
            this.txtnombre.ReadOnly = !valor;
            this.txtdescripcion.ReadOnly = !valor;
            this.btnbuscarcateg.Enabled = valor;
            this.cmbidpresentacion.Enabled = valor;
            this.btncargar.Enabled = valor;
            this.btlimpiar.Enabled = valor; 
            this.txtidarticulo.ReadOnly = !valor;
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
            this.datagridcategoria.Columns[6].Visible = false;
            this.datagridcategoria.Columns[8].Visible = false;

        }


        public void mostrar()
        {
            this.datagridcategoria.DataSource = Narticulo.Mostrar();
            this.ocultarcolumnas();
            label2.Text = "Total de registros" + Convert.ToString(datagridcategoria.Rows.Count);
        }

        public void buscarnombre()
        {
            this.datagridcategoria.DataSource = Narticulo.BuscarNombre(txtbuscar.Text);
            this.ocultarcolumnas();
            label2.Text = "Total de registros" + Convert.ToString(datagridcategoria.Rows.Count);
        }

        private void Llenarcombopre()
        {
            cmbidpresentacion.DataSource = Npresentacion.Mostrar();
            cmbidpresentacion.ValueMember = "idpresentacion";
            cmbidpresentacion.DisplayMember = "Nombre";
        }

        private void frmarticulo_Load(object sender, EventArgs e)
        {
            this.mostrar();
            this.habilitar(false);
            this.Botones();
        }

        private void btncargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                this.picimagen.SizeMode = PictureBoxSizeMode.StretchImage;
                this.picimagen.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void Btlimpiar_Click(object sender, EventArgs e)
        {

            this.picimagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.picimagen.Image = global::Capapresentacion.Properties.Resource1.file;

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
                if (this.txtnombre.Text == string.Empty || this.txtidcategoria.Text == string.Empty || this.txtcodigo.Text == string.Empty)
                {
                    Mensajeerror(" Faltan ingresar algunos datos");
                    erroricono.SetError(txtnombre, "Ingrese un valor");
                    erroricono.SetError(txtcodigo, "Ingrese un valor");
                    erroricono.SetError(txtcategoria, "Ingrese un valor");
                }
                else
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.picimagen.Image.Save(ms,System.Drawing.Imaging.ImageFormat.Png);

                    byte[] imagen = ms.GetBuffer();
                    if (this.Isnuevo)
                    {

                        respuesta = Narticulo.Insertar(this.txtcodigo.Text,this.txtnombre.Text.Trim().ToUpper(), this.txtdescripcion.Text.Trim(),
                            imagen,Convert.ToInt32(this.txtidcategoria.Text),
                            Convert.ToInt32(this.cmbidpresentacion.SelectedValue));

                    }
                    else
                    {
                        respuesta = Narticulo.Editar(Convert.ToInt32(this.txtidarticulo.Text),
                            this.txtcodigo.Text, this.txtnombre.Text.Trim().ToUpper(), this.txtdescripcion.Text.Trim(),
                            imagen, Convert.ToInt32(this.txtidcategoria.Text),
                            Convert.ToInt32(this.cmbidpresentacion.SelectedValue));

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

            if (!this.txtidarticulo.Text.Equals(""))
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

        private void Btncancelar_Click(object sender, EventArgs e)
        {
            this.Isnuevo = false;
            this.Iseditar = false;
            this.Botones();
            this.limpiar();
            this.habilitar(false);
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
            this.txtidarticulo.Text = Convert.ToString(this.datagridcategoria.CurrentRow.Cells["idarticulo"].Value);
            this.txtcodigo.Text = Convert.ToString(this.datagridcategoria.CurrentRow.Cells["codigo"].Value);
            this.txtnombre.Text = Convert.ToString(this.datagridcategoria.CurrentRow.Cells["Nombre"].Value);
            this.txtdescripcion.Text = Convert.ToString(this.datagridcategoria.CurrentRow.Cells["descripcion"].Value);

            byte[] imagenbuffer = (byte[]) this.datagridcategoria.CurrentRow.Cells["imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenbuffer);
            this.picimagen.Image = Image.FromStream(ms);
            this.picimagen.SizeMode = PictureBoxSizeMode.StretchImage;

            this.txtidcategoria.Text = Convert.ToString(this.datagridcategoria.CurrentRow.Cells["idcategoria"].Value);
            this.txtcategoria.Text = Convert.ToString(this.datagridcategoria.CurrentRow.Cells["categoria"].Value);
            this.cmbidpresentacion.SelectedValue = Convert.ToString(this.datagridcategoria.CurrentRow.Cells["idpresentacion"].Value);
            this.tabControl1.SelectedIndex = 1;
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

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (chkeliminar.Checked)
            {
                int Indice = 0;
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
                                    respuesta = Narticulo.Eliminar(Convert.ToInt32(codigo));

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
                    Mensajeerror("Debe Seleccionar un Articulo a Eliminar");
                    erroricono.SetError(datagridcategoria,"Seleccione un Articulo");
                }
            }
            else
            {
                Mensajeerror("Debe Checar la casilla de Eliminar");
                erroricono.SetError(chkeliminar,"Selecione la casilla");
            }      
        }

        private void Btnbuscarcateg_Click(object sender, EventArgs e)
        {

            frmcategoria frm = new frmcategoria();
            frm.ShowDialog();

        }
    }
}
