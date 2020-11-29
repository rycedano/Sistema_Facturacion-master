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
using Capapresentacion;
using System.Security.Cryptography;

namespace sinnombre
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Txtusuario_Enter(object sender, EventArgs e)
        {
            if (txtusuario.Text == "USUARIO")
            {
                txtusuario.Text = "";
                txtusuario.ForeColor = Color.DimGray;

            }
        }

        private void Txtusuario_Leave(object sender, EventArgs e)
        {
            if (txtusuario.Text == "")
            {
                txtusuario.Text = "USUARIO";
                txtusuario.ForeColor = Color.DimGray;
            }
        }

        private void Txtpassword_Enter(object sender, EventArgs e)
        {
            if (txtpassword.Text == "PASSWORD")
            {
                txtpassword.Text = "";
                txtpassword.ForeColor = Color.DimGray;
                //txtpassword.UseSystemPasswordChar = true;

            }
        }

        private void Txtpassword_Leave(object sender, EventArgs e)
        {

            if (txtpassword.Text == "")
            {
                txtpassword.Text = "PASSWORD";
                txtpassword.ForeColor = Color.DimGray;
                //  txtpassword.UseSystemPasswordChar = false;
            }
        }

        private void Msgerror(string msg)
        {
            lblmsg.Text = "   " + msg;
            lblmsg.Visible = true;
        }

        private void Linkpass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var recuperarcontraseña = new Recuperaciondecontraseña();
            recuperarcontraseña.ShowDialog();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();           
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static string Encrypt(string Str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(Str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        private void Btnlogin_Click(object sender, EventArgs e)
        {
            Nusuario user = new Nusuario();
            var login2 = user.Login2();
            if (login2 == true)
                {
                    if (txtusuario.Text != "USUARIO" & txtusuario.TextLength > 2 & txtpassword.Text != "PASSWORD")
                    {
                        var validologin = user.Loginusuario(txtusuario.Text,txtpassword.Text);

                        if (validologin == true)
                        {
                            Frmprimcipal D = new Frmprimcipal();
                            D.Show();
                            D.FormClosed += Cerrarsesion;
                            this.Hide();
                        }
                        else Msgerror("Usuario o contraseña incorrectos.\n por favor intente de nuevo");
                        txtpassword.Text = "PASSWORD";
                        txtusuario.Focus();
                    }
                    else
                    {
                        Msgerror("porfavor introdusca la contraseña.");
                    }
            }
            else
            {
                MessageBox.Show("ERRORRRRRRRRRR");
            }
        }

            private void Cerrarsesion(object sender, FormClosedEventArgs e)
        {
            txtpassword.Clear();
            //  txtusuario.Clear();
            lblmsg.Visible = false;
            this.Show();
            txtusuario.Focus();
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
           // label1.Text = DateTime.Now.ToString();
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
        }

    
        



    }
}
