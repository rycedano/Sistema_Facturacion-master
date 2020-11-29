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
    public partial class Frmvistaarticuloventa : Form
    {
        public Frmvistaarticuloventa()
        {
            InitializeComponent();
            Mostrararticulo();
        }

        private void OcultarColumnas()
        {
            this.Datagridcliente.Columns[0].Visible = false;
            this.Datagridcliente.Columns[1].Visible = false;
        }

       

        //Método BuscarApellidos
        private void Buscararticulonombre()
        {
            this.Datagridcliente.DataSource = Nventa.MostrarArticulo_Venta_Nombre(this.txtbuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(Datagridcliente.Rows.Count);
        }


        private void Buscararticulocodigo()
        {
            this.Datagridcliente.DataSource = Nventa.MostrarArticulo_Venta_Codigo(this.txtbuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(Datagridcliente.Rows.Count);
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (Cmbbuscar.Text.Equals("Codigo"))
            {
                this.Buscararticulocodigo();
            }
            else if (Cmbbuscar.Text.Equals("Nombre"))
            {
                this.Buscararticulonombre();
            }
        }

        private void Datagridcliente_DoubleClick(object sender, EventArgs e)
        {
            Frmventa Form = Frmventa.Getinstancia();
            string par1, par2;
            decimal par3, par4;
            int par5; DateTime par6;
            par1 = Convert.ToString(this.Datagridcliente.CurrentRow.Cells["iddetalleingreso"].Value);
            par2 = Convert.ToString(this.Datagridcliente.CurrentRow.Cells["nombre"].Value);
            par3 = Convert.ToDecimal(this.Datagridcliente.CurrentRow.Cells["precio_compra"].Value);
            par4 = Convert.ToDecimal(this.Datagridcliente.CurrentRow.Cells["precio_venta"].Value);
            par5 = Convert.ToInt32(this.Datagridcliente.CurrentRow.Cells["Stock_actual"].Value);
            par6 = Convert.ToDateTime(this.Datagridcliente.CurrentRow.Cells["fecha_vencimiento"].Value);
            Form.setArticulo(par1,par2,par3,par4,par5,par6);
            this.Hide();
        }

        public void Mostrararticulo()
        {
            Datagridcliente.DataSource = Narticulo.Mostrar();
        }

    }
}
