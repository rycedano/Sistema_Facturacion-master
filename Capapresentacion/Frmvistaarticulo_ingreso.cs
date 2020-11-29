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
    public partial class Frmvistaarticulo_ingreso : Form
    {
        public Frmvistaarticulo_ingreso()
        {
            InitializeComponent();
        }


        private void ocultarcolumnas()
        {
            this.datagridcategoria.Columns[0].Visible = false;
            //this.datagridcategoria.Columns[0].Visible = false;
            //this.datagridcategoria.Columns[1].Visible = false;
            // this.datagridcategoria.Columns[6].Visible = false;
            //this.datagridcategoria.Columns[8].Visible = false;
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

        private void Frmvistaarticulo_ingreso_Load(object sender, EventArgs e)
        {
            this.mostrar();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            this.buscarnombre();
        }

        private void datagridcategoria_DoubleClick(object sender, EventArgs e)
        {
            Frmingreso Form = Frmingreso.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.datagridcategoria.CurrentRow.Cells["idarticulo"].Value);
            par2 = Convert.ToString(this.datagridcategoria.CurrentRow.Cells["nombre"].Value);
            Form.SetArticulo(par1,par2);
            this.Hide();
        }
    }
}
