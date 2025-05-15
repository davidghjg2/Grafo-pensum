using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafo_pensum.Usuario.Dominio;

namespace Grafo_pensum.Usuario.DB
{
    internal interface UsuarioInterfazBase
    {
        (bool, Exception) InsertarUsuario(Grafo_pensum.Usuario.Dominio.Usuario usuario);
        (bool, Exception) InsertarUsuario(Grafo_pensum.Usuario.Dominio.Usuario[] usuarios);
        (Grafo_pensum.Usuario.Dominio.Usuario, Exception) ObtenerUsuarioPorId(string id);
        (Grafo_pensum.Usuario.Dominio.Usuario[], Exception) ObtenerTodosUsuarios();
        (bool, Exception) ActualizarUsuario(Grafo_pensum.Usuario.Dominio.Usuario usuario);
        (bool, Exception) EliminarUsuario(Grafo_pensum.Usuario.Dominio.Usuario usuario);
    }
}
