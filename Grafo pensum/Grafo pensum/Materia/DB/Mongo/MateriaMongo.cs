using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Grafo_pensum.Materia.DB.Mongo
{
    internal class MateriaMongo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("descripcion")]
        public string Descripcion { get; set; }

        [BsonElement("codigo")]
        public string Codigo { get; set; }

        [BsonElement("uv")]
        public int Uv {  get; set; }

        [Serializable]
        public struct req
        {
            public Carrera.Dominio.Carrera carrera;
            public string codigos;

            public req(Carrera.Dominio.Carrera carrera, string codigos)
            {
                this.carrera = carrera;
                this.codigos = codigos;
            }
        }

        public MateriaMongo() 
        { 
            Nombre = string.Empty;
            Uv = 0;
            Descripcion = string.Empty;
            Codigo = string.Empty;
        }

        public MateriaMongo(string nombre, int uv, string descripcion, string codigo)
        {
            Nombre = nombre;
            Uv = uv;
            Descripcion = descripcion;
            Codigo = codigo;
        }

    }
}
