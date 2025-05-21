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
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }

        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("apellido")]
        public string Apellido { get; set; }

        [BsonElement("contraseña")]
        public string Contraseña { get; set; }

        [BsonElement("correo")]
        public string Correo { get; set; }

        [BsonElement("TipoUsuario")]
        public int TipoUsuario { get; set; }

        public Usuario()
        {
            Id = string.Empty;
            Nombre = string.Empty;
            Apellido = string.Empty;
            Contraseña = string.Empty;
            Correo = string.Empty;
            TipoUsuario = 2;
        }

        public Usuario(string id, string nombre, string apellido, string contraseña, string correo, int tipoUsuario)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Contraseña = contraseña;
            Correo = correo;
            TipoUsuario = tipoUsuario;
        }
    }
}
