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
            // Botón Agregar
            btnAgregar.Enabled = !edicion;
            btnAgregar.BackColor = btnAgregar.Enabled ? Color.LightGreen : Color.LightGray;
            // Botón Actualizar
            btnActualizar.Enabled = edicion;
            btnActualizar.BackColor = btnActualizar.Enabled ? Color.LightGreen : Color.LightGray;
            // Botón Eliminar
            btnEliminar.Enabled = edicion;
            btnEliminar.BackColor = btnEliminar.Enabled ? Color.LightGreen : Color.LightGray;
            // Botón Buscar
            btnBuscar.Enabled = !edicion;
            btnBuscar.BackColor = btnBuscar.Enabled ? Color.LightGreen : Color.LightGray;
        }


        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtContraseña.Clear();
            txtCorreo.Clear();
            cmbTipoUsuario.SelectedIndex = -1;
            usuarioSeleccionado = null;
        }
               

        private void ObtenerTodosUsuarios()
        {
            try
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
                        usuario.TipoUsuario == 1 ? "Administrador" : "Estudiante",
                        usuario.Id,
                        usuario.Contraseña,
                        usuario.Nombre,
                        usuario.Apellido,
                        usuario.Correo
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarNivelesUsuario()
        {
            cmbTipoUsuario.Items.Add("Administrador");
            cmbTipoUsuario.Items.Add("Estudiante");
            cmbTipoUsuario.SelectedIndex = 0;
        }

        private bool ValidarCampos()
        {
            // Validación de campos vacíos
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

            // Validación de solo letras en Nombre y Apellido
            if (txtNombre.Text.Any(char.IsDigit) || txtApellido.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Nombre y Apellido no deben contener números", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validación básica de correo
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
            cmbTipoUsuario.SelectedIndex = usuario.TipoUsuario - 1;

            HabilitarBotones(true);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            if (IdYaExiste(txtId.Text))
            {
                MessageBox.Show("El ID ya está registrado. Ingrese uno diferente.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CorreoYaExiste(txtCorreo.Text))
            {
                MessageBox.Show("El correo ya está registrado. Ingrese uno diferente.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            var nuevoUsuario = new DominioUsuario
            {
                Id = txtId.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Contraseña = txtContraseña.Text,
                Correo = txtCorreo.Text,
                TipoUsuario = cmbTipoUsuario.SelectedIndex + 1
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
            HabilitarBotones(false);
            ObtenerTodosUsuarios();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos() || usuarioSeleccionado == null) return;

            if (!usuarioSeleccionado.Correo.Equals(txtCorreo.Text, StringComparison.OrdinalIgnoreCase)
                 && CorreoYaExiste(txtCorreo.Text))
            {
                MessageBox.Show("El nuevo correo ya está en uso por otro usuario.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            usuarioSeleccionado.Nombre = txtNombre.Text;
            usuarioSeleccionado.Apellido = txtApellido.Text;
            usuarioSeleccionado.Contraseña = txtContraseña.Text;
            usuarioSeleccionado.Correo = txtCorreo.Text;
            usuarioSeleccionado.TipoUsuario = cmbTipoUsuario.SelectedIndex + 1;

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


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarBotones(false);
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Obtener el ID (usuario) desde la columna colId
            string id = dgvUsuarios.Rows[e.RowIndex].Cells["colId"].Value?.ToString();
            if (string.IsNullOrEmpty(id)) return;

            // Buscar el usuario por su ID
            var (usuario, error) = usuarioInfra.ObtenerUsuarioPorId(id);
            if (error != null || usuario == null) return;

            // Cargar los datos en los TextBox
            usuarioSeleccionado = usuario;
            txtId.Text = usuario.Id;
            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtContraseña.Text = usuario.Contraseña;
            txtCorreo.Text = usuario.Correo;
            cmbTipoUsuario.SelectedIndex = usuario.TipoUsuario - 1;

            HabilitarBotones(true);
        }

        private bool IdYaExiste(string id)
        {
            var (usuarios, error) = usuarioInfra.ObtenerTodosUsuarios();
            if (error != null) return false;

            return usuarios.Any(u => u.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        private bool CorreoYaExiste(string correo)
        {
            var (usuarios, error) = usuarioInfra.ObtenerTodosUsuarios();
            if (error != null) return false;

            return usuarios.Any(u => u.Correo.Equals(correo, StringComparison.OrdinalIgnoreCase));
        }
    }
}
