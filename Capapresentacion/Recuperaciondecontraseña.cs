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
    public partial class Recuperaciondecontraseña : Form
    {
        public Recuperaciondecontraseña()
        {
            InitializeComponent();
        }

        private void Btnenter_Click(object sender, EventArgs e)
        {
            var usuario = new Nusuario();
            usuario.SendEmail(Txtemail.Text,Txtasunto.Text);    
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
