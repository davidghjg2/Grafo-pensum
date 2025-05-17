using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grafo_pensum.Usuario.Infra;
using DominioUsuario = Grafo_pensum.Usuario.Dominio.Usuario;

namespace Grafo_pensum.Vista
{
    public partial class frmCRUDUsuarios : Form
    {
        private readonly UsuarioInfra usuarioInfra = new UsuarioInfra();
        private DominioUsuario usuarioSeleccionado = null;

        public frmCRUDUsuarios()
        {
            InitializeComponent();
            CargarNivelesUsuario();
            ObtenerTodosUsuarios();
            LimpiarCampos();
            HabilitarBotones(false);
        }

        private void HabilitarBotones(bool edicion)
        {
            btnAgregar.Enabled = !edicion;
            btnActualizar.Enabled = edicion;
            btnEliminar.Enabled = edicion;
            btnBuscar.Enabled = !edicion;
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtContraseña.Clear();
            txtCorreo.Clear();
            cmbNivelUsuario.SelectedIndex = -1;
            usuarioSeleccionado = null;
        }
               

        private void ObtenerTodosUsuarios()
        {
            dgvUsuarios.Rows.Clear();
            var (usuarios, error) = usuarioInfra.ObtenerTodosUsuarios();

            if (error != null)
            {
                MessageBox.Show($"Error al cargar usuarios: {error.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var usuario in usuarios)
            {
                dgvUsuarios.Rows.Add(
                    usuario.Id,
                    usuario.Nombre,
                    usuario.Apellido,
                    usuario.NivelUsuario == 1 ? "Administrador" : "Estudiante",
                    usuario.Correo
                );
            }
        }

        private void CargarNivelesUsuario()
        {
            cmbNivelUsuario.Items.Add("Administrador");
            cmbNivelUsuario.Items.Add("Estudiante");
            cmbNivelUsuario.SelectedIndex = 0;
        }

        private bool ValidarCampos()
        {
            // Validación de campos vacíos (como ya tenías)
            if (string.IsNullOrWhiteSpace(txtId.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtContraseña.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Todos los campos son requeridos", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validación de solo letras en Nombre y Apellido (nuevo)
            if (txtNombre.Text.Any(char.IsDigit) || txtApellido.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Nombre y Apellido no deben contener números", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validación básica de correo (nuevo)
            if (!txtCorreo.Text.Contains("@") || !txtCorreo.Text.Contains("."))
            {
                MessageBox.Show("Ingrese un correo válido", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Ingrese un ID para buscar", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var (usuario, error) = usuarioInfra.ObtenerUsuarioPorId(txtId.Text);
            if (error != null || usuario == null)
            {
                MessageBox.Show("Usuario no encontrado", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                return;
            }

            usuarioSeleccionado = usuario;
            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtContraseña.Text = usuario.Contraseña;
            txtCorreo.Text = usuario.Correo;
            cmbNivelUsuario.SelectedIndex = usuario.NivelUsuario - 1;

            HabilitarBotones(true);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            var nuevoUsuario = new DominioUsuario
            {
                Id = txtId.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Contraseña = txtContraseña.Text,
                Correo = txtCorreo.Text,
                NivelUsuario = cmbNivelUsuario.SelectedIndex + 1
            };

            var (success, error) = usuarioInfra.InsertarUsuario(nuevoUsuario);
            if (error != null)
            {
                MessageBox.Show($"Error al agregar: {error.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Usuario agregado correctamente", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
            ObtenerTodosUsuarios();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos() || usuarioSeleccionado == null) return;

            usuarioSeleccionado.Nombre = txtNombre.Text;
            usuarioSeleccionado.Apellido = txtApellido.Text;
            usuarioSeleccionado.Contraseña = txtContraseña.Text;
            usuarioSeleccionado.Correo = txtCorreo.Text;
            usuarioSeleccionado.NivelUsuario = cmbNivelUsuario.SelectedIndex + 1;

            var (success, error) = usuarioInfra.ActualizarUsuario(usuarioSeleccionado);
            if (error != null)
            {
                MessageBox.Show($"Error al actualizar: {error.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Usuario actualizado correctamente", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
            HabilitarBotones(false);
            ObtenerTodosUsuarios();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionado == null || string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Seleccione un usuario para eliminar", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacion = MessageBox.Show($"¿Eliminar al usuario {usuarioSeleccionado.Id}?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            var (success, error) = usuarioInfra.EliminarUsuario(usuarioSeleccionado);
            if (error != null)
            {
                MessageBox.Show($"Error al eliminar: {error.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Usuario eliminado correctamente", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
            HabilitarBotones(false);
            ObtenerTodosUsuarios();
        }

        private void dgvUsuarios_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var id = dgvUsuarios.Rows[e.RowIndex].Cells["colId"].Value.ToString();
            var (usuario, error) = usuarioInfra.ObtenerUsuarioPorId(id);

            if (error != null || usuario == null) return;

            usuarioSeleccionado = usuario;
            txtId.Text = usuario.Id;
            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtContraseña.Text = usuario.Contraseña;
            txtCorreo.Text = usuario.Correo;
            cmbNivelUsuario.SelectedIndex = usuario.NivelUsuario - 1;

            HabilitarBotones(true);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarBotones(false);
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
