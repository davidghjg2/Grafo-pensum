using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Grafo_pensum.Usuario.Dominio
{
    public class Usuario
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido {  get; set; }
        public string Contraseña { get; set; }

        public string Correo {  get; set; }
        public int NivelUsuario {  get; set; }

        public Usuario()
        {
            Nombre = string.Empty;
            Apellido = string.Empty;
            Contraseña = string.Empty;
            Correo = string.Empty;
            NivelUsuario = 2;
        }

        public Usuario (string id, string nombre, string apellido, string contraseña, string correo, int nivelUsuario)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Contraseña = contraseña;
            Correo = correo;
            NivelUsuario = nivelUsuario;
        }
    }
}
