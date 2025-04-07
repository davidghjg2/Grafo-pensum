using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafo_pensum.DB.Mongo.Carrera;

namespace Grafo_pensum.DB.Carrera
{
    internal class CarreraDB
    {
        public static CarreraInterfazBase CrearBase()
        {
            var tipo = Environment.GetEnvironmentVariable("DB_CONTEXT") ?? "mongo";
            switch(tipo)
            {
                case "mongo":
                    var connection = Environment.GetEnvironmentVariable("MONGODB_URI") ?? "mongodb+srv://grafo-user:eR85Qon7uUwf7XSl@cluster-demo.bhk8l.mongodb.net/?retryWrites=true&w=majority&appName=Cluster-demo";
                    var db = Environment.GetEnvironmentVariable("DB_NAME") ?? "pensum";
                    return new CarreraMongoData(connection, db);
                default:
                    throw new NotSupportedException($"Base de datos no soportada: {tipo}");
            }
        }
    }
}
