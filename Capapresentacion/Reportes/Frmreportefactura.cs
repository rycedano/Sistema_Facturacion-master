using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capapresentacion
{
    public partial class Frmreportefactura : Form
    {
        public Frmreportefactura()
        {
            InitializeComponent();
        }

        private int _Idventa;
        public int Idventa
        {
            get { return _Idventa; }
            set { _Idventa = value; }
        }

        private void Frmreportefactura_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Dsprimcipal.spreporte_factura' table. You can move, or remove it, as needed.
            try
            {
                this.spreporte_facturaTableAdapter.Fill(this.Dsprimcipal.spreporte_factura, Idventa);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception)
            {
                this.reportViewer1.RefreshReport();

            }
          
        }
    }
}
