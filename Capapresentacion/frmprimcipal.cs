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

namespace Capapresentacion
{
    public partial class Frmprimcipal : Form
    {
        private int childFormNumber = 0;

        public Frmprimcipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form
            {
                MdiParent = this,
                Text = "Window " + childFormNumber++
            };
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                _ = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                _ = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void Frmprimcipal_Load(object sender, EventArgs e)
        {
            Nusuario usu = new Nusuario();
            Keyserial.Text = Datoscahe.Keyserial;
            this.Lblactivo.Text = Computadora.Estatus_compu;
            
            List<ToolStripMenuItem> MyItems = ObtenerOPciones(this.Mnustrip);
            foreach (var item in MyItems)
            {
                //item.Enabled = false;
                item.Enabled = usu.Validaropcion(Datoscahe.Idrol, item.Name);
            }
        }

        private void CategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmcategiria form = new Frmcategiria
            {
                MdiParent = this
            };
            form.Show();
        }

        private void PresentacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmpresentacion form = new frmpresentacion
            {
                MdiParent = this
            };
            form.Show();
        }

        private void ArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmarticulo form = frmarticulo.Getinstancia();
            form.MdiParent = this;
            form.Show();
        }

        private void ProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmproveedor form = new frmproveedor
            {
                MdiParent = this
            };
            form.Show();
        }

        private void ClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmcliente form = new Frmcliente
            {
                MdiParent = this
            };
            form.Show();
        }

        private void UsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmusuario form = new frmusuario
            {
                MdiParent = this
            };
            form.Show();
        }


        public static List<ToolStripMenuItem> ObtenerOPciones(MenuStrip menuStrip)
        {
            List<ToolStripMenuItem> MyItem = new List<ToolStripMenuItem>();
            foreach (ToolStripMenuItem i in menuStrip.Items.OfType<ToolStripMenuItem>())
            {

                Obteneritem(i, MyItem);

            }

            return MyItem;

        }

       
        private static void Obteneritem(ToolStripMenuItem item, List<ToolStripMenuItem> items)
        {
            items.Add(item);
            foreach (ToolStripMenuItem ite in item.DropDownItems.OfType<ToolStripMenuItem>())
            {
                if (ite is ToolStripMenuItem item1)
                {
                    Obteneritem(item1, items);
                }
            }
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmingreso Form = Frmingreso.GetInstancia();
            Form.MdiParent = this;
            Form.Show();
            Datoscahe.Idusuario =Convert.ToInt32 (Form.Idtrabajador);
            
        }

        private void tsventas_Click(object sender, EventArgs e)
        {
            Frmventa Form = Frmventa.Getinstancia();
            Form.MdiParent = this;
            Form.Show();

        }

        private void mnusalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
