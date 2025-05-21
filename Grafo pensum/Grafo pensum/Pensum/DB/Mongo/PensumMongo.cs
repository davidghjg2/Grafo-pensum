using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Grafo_pensum.DB.Carrera;

namespace Grafo_pensum.Pensum.DB.Mongo
{
    internal class PensumMongo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("codigo")]
        public string codigo { get; set; }

        [BsonElement("carrera")]
        public Carrera.Dominio.Carrera Carrera { get; set; }

        [BsonElement("materia")]
        public Materia.Dominio.Materia[] Materia { get; set; }

        [Serializable]
        public class req
        {
            public Carrera.Dominio.Carrera carrera { get; set; }
            public string codigos { get; set; }

            // Constructor por defecto necesario para la deserialización
            public req()
            {
                carrera = null;
                codigos = string.Empty;
            }

            public req(Carrera.Dominio.Carrera carrera, string codigos)
            {
                this.carrera = carrera;
                this.codigos = codigos;
            }
        }


        public PensumMongo() 
        {
            Id = string.Empty;
            codigo = string.Empty;
            Carrera = null;
            Materia = new Materia.Dominio.Materia[0];
        }

        public PensumMongo(Carrera.Dominio.Carrera carrera, Materia.Dominio.Materia[] materia, string codigo)
        {
            Carrera = carrera;
            Materia = materia;
            this.codigo = codigo;
        }
    }
}
