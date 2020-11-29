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
    public partial class Vistaproveedor_ingreso : Form
    {
        public Vistaproveedor_ingreso()
        {
            InitializeComponent();
        }


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

        private void Vistaproveedor_ingreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (cmbbuscar.Text.Equals("Razon_social"))
            {
                this.BuscarRazon_Social();
            }
            else
            {
                this.BuscarNum_Documento();
            }
        }

        private void datagridproveedor_DoubleClick(object sender, EventArgs e)
        {

            Frmingreso Form = Frmingreso.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.datagridproveedor.CurrentRow.Cells["idproveedor"].Value);
            par2 = Convert.ToString(this.datagridproveedor.CurrentRow.Cells["razonsocial"].Value);
            Form.SetProveedor(par1,par2);
            this.Hide();
        }
    }
}
