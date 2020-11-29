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
    public partial class Frmvistaclienteventa : Form
    {
        public Frmvistaclienteventa()
        {
            InitializeComponent();
        }


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

        private void Frmvistaclienteventa_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
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

        private void Datagridcliente_DoubleClick(object sender, EventArgs e)
        {
            Frmventa From = Frmventa.Getinstancia();
            string par1, par2;
            par1 = Convert.ToString(this.Datagridcliente.CurrentRow.Cells["idcliente"].Value);
            par2 = Convert.ToString(this.Datagridcliente.CurrentRow.Cells["Apellido"].Value
                + " " + Convert.ToString(this.Datagridcliente.CurrentRow.Cells["nombre"].Value));
            From.setCliente(par1,par2);
            this.Hide();
        }
    }
}
