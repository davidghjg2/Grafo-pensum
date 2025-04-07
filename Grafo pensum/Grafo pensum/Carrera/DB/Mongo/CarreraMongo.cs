using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Grafo_pensum.DB.Mongo.Carrera
{
    internal class CarreraMongo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("departamento")]
        public string Departamento { get; set; }

        public CarreraMongo()
        {
            Nombre = string.Empty;
            Departamento = string.Empty;
        }

        public CarreraMongo(string nombre, string departamento)
        {
            Nombre = nombre;
            Departamento = departamento;
        }
    }
}
