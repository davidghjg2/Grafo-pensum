using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo_pensum.Usuario.Dominio
{
    internal interface UsuarioInterfaz
    {
        //CRUD (solo Admin)
        (bool, Exception) InsertarUsuario(Usuario usuario);
        (Usuario, Exception) ObtenerUsuarioPorId(string id);
        (Usuario[], Exception) ObtenerTodosUsuarios();
        (bool, Exception) ActualizarUsuario(Usuario usuario);
        (bool, Exception) EliminarUsuario(Usuario usuario);

        //Autenticación
        (Usuario, Exception) Login(string id, string contraseña); 
    }
}

