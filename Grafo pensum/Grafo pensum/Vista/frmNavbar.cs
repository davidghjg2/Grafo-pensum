using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grafo_pensum.Infra.Vista;
using Grafo_pensum.Vista;

namespace Grafo_pensum
{
    public partial class frmNavbar : Form
    {
        private Panel panelContenedor;
        public frmNavbar()
        {
            InitializeComponent();
            InicializarPanel();

        }
        private void InicializarPanel()
        {
            panelContenedor = new Panel();
            panelContenedor.Size = new Size(1300, 516);  // Tamaño del panel
            panelContenedor.Location = new Point(0, 50); // Posición
            panelContenedor.AutoScroll = true;  // Activar Scroll si el contenido es grande
            this.Controls.Add(panelContenedor);

            CargarFormulario(new frmInicio());
        }
        private void CargarFormulario(Form form)
        {
            panelContenedor.Controls.Clear();  // Limpiar contenido anterior
            form.TopLevel = false;  // Evita que sea una ventana independiente
            form.FormBorderStyle = FormBorderStyle.None;  // Sin bordes
            form.Dock = DockStyle.Top;  // Ajustar ancho al panel
            form.StartPosition = FormStartPosition.CenterParent;
            panelContenedor.Controls.Add(form);
            form.Show();
        }

        private void tsCRUDMateria_Click(object sender, EventArgs e)
        {
            CargarFormulario(new frmCRUDMateria());
        }

        private void tsLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();  
            frmLogin login = new frmLogin();
            login.Show();
            login.FormClosed += (s, args) => this.Close();

        }

        private void tsPensum_Click(object sender, EventArgs e)
        {
            CargarFormulario(new frmVerPensum());
        }

        private void tsMateria_Click(object sender, EventArgs e)
        {
            CargarFormulario(new frmVerMateria());
        }

        private void tsCRUDPensum_Click(object sender, EventArgs e)
        {
            CargarFormulario(new frmCRUDPensum());
        }

        private void tsCRUDCarrera_Click(object sender, EventArgs e)
        {
            CargarFormulario(new fmrCRUDCarrera());
        }

        private void tsMantenimiento_Click(object sender, EventArgs e)
        {

        }

        private void tsCRUDUsuarios_Click(object sender, EventArgs e)
        {
            CargarFormulario(new frmCRUDUsuarios());
        }
    }
}
