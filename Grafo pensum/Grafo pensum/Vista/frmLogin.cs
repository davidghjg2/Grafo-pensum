using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grafo_pensum.Usuario.Infra;
using UsuarioDominio = Grafo_pensum.Usuario.Dominio.Usuario;

namespace Grafo_pensum
{
    public partial class frmLogin : Form
    {
        private readonly AuthService authService;
        public frmLogin()
        {
            InitializeComponent();
            authService = new AuthService();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || txtUsuario.Text == "Usuario" || string.IsNullOrWhiteSpace(maskedTextBox1.Text) || maskedTextBox1.Text == "Contraseña")
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            // Realizar login con el AuthService
            UsuarioDominio usuario = authService.Login(txtUsuario.Text, maskedTextBox1.Text);

            if (usuario != null)
            {
                frmNavbar navbar = new frmNavbar(usuario);
                navbar.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Clear();
                maskedTextBox1.Clear();
            }
        }

    }
}
