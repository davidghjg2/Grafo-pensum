using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafo_pensum.DB.Usuario;
using Grafo_pensum.DB;
using Grafo_pensum.Usuario.Dominio;
using Grafo_pensum.Usuario.DB;

namespace Grafo_pensum.Usuario.Infra
{
    internal class UsuarioInfra : UsuarioInterfaz
    {
        private readonly UsuarioInterfazBase db = UsuarioDB.CrearBase();

        public (bool, Exception) InsertarUsuario(Dominio.Usuario usuario)
        {
            (bool, Exception) result = db.InsertarUsuario(usuario);
            return result;
        }


        public (Dominio.Usuario, Exception) ObtenerUsuarioPorId(string id)
        {
            Dominio.Usuario usuario = new Dominio.Usuario();
            return (usuario, null);
        }

        public (Dominio.Usuario[], Exception) ObtenerTodosUsuarios()
        {
            (Dominio.Usuario[], Exception) result = db.ObtenerTodosUsuarios();
            return result;
        }

        public (bool, Exception) ActualizarUsuario(Dominio.Usuario usuario)
        {
            (bool, Exception) result = db.ActualizarUsuario(usuario);
            return result;
        }

        public (bool, Exception) EliminarUsuario(Dominio.Usuario usuario)
        {
            (bool, Exception) result = db.EliminarUsuario(usuario);
            return result;
        }

        //Autenticación
        public (Dominio.Usuario, Exception) Login(string id, string contraseña)
        {
            (Dominio.Usuario, Exception) result = db.ObtenerUsuarioPorId(id); // Busca por ID
            if (result.Item1 == null || result.Item1.Contraseña != contraseña)
                return (null, new Exception("Credenciales incorrectas"));
            return result;
        }
    }
}
