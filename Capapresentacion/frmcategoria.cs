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
    public partial class frmcategoria : Form
    {
        public frmcategoria()
        {
            InitializeComponent();
        }

        private void frmcategoria_Load(object sender, EventArgs e)
        {
            this.mostrar();
        }




        private void ocultarcolumnas()
        {
            this.datagridcategoria.Columns[0].Visible = false;
            this.datagridcategoria.Columns[1].Visible = false;
        }


        public void mostrar()
        {
            this.datagridcategoria.DataSource = Ncategoria.Mostrar();
            this.ocultarcolumnas();
            label2.Text = "Total de registros" + Convert.ToString(datagridcategoria.Rows.Count);
        }

        public void buscarnombre()
        {
            this.datagridcategoria.DataSource = Ncategoria.Buscarnombre(txtbuscar.Text);
            this.ocultarcolumnas();
            label2.Text = "Total de registros" + Convert.ToString(datagridcategoria.Rows.Count);
        }

        private void datagridcategoria_DoubleClick(object sender, EventArgs e)
        {

            frmarticulo form = frmarticulo.Getinstancia();
            string par1, par2;
            par1 = Convert.ToString(this.datagridcategoria.CurrentRow.Cells["idcategoria"].Value);
            par2 = Convert.ToString(this.datagridcategoria.CurrentRow.Cells["Nombre"].Value);
            form.Setcategoria(par1,par2);
            this.Hide();
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            this.buscarnombre();
        }
    }
}
