using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Grafo_pensum.Usuario.DB.Mongo
{
    internal class UsuarioMongo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("nickUsuario")]
        public string NickUsuario { get; set; }

        [BsonElement("contraseña")]
        public string Contraseña { get; set; }

        [BsonElement("correo")]
        public string Correo { get; set; }

        [BsonElement("nivelUsuario")]
        public int NivelUsuario { get; set; }

        public UsuarioMongo() 
        {
            Nombre = string.Empty;
            NickUsuario = string.Empty;
            Contraseña = string.Empty;
            Correo = string.Empty;
            NivelUsuario = 2;
        }

        public UsuarioMongo(string id, string nombre, string nickUsuario, string contraseña, string correo, int nivelUsuario)
        {
            Id = id;
            Nombre = nombre;
            NickUsuario = nickUsuario;
            Contraseña = contraseña;
            Correo = correo;
            NivelUsuario = nivelUsuario;
        }
    }
}
