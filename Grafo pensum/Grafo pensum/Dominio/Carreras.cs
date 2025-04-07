using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Grafo_pensum
{
    internal class Carreras
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("departamento")]
        public string Departamento { get; set; }

        public Carreras()
        {
            Nombre = string.Empty;
            Departamento = string.Empty;
        }

        public Carreras(string nombre, string departamento)
        {
            Nombre = nombre;
            Departamento = departamento;
        }
    }
}
