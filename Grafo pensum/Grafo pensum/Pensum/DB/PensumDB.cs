using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafo_pensum.Pensum.DB.Mongo;
using Grafo_pensum.Pensum.DB;

namespace Grafo_pensum.Pensum.DB
{
    internal class PensumDB
    {
        public static PensumInterfazBase CrearBase()
        {
            var tipo = Environment.GetEnvironmentVariable("DB_CONTEXT") ?? "mongo";
            switch (tipo)
            {
                case "mongo":
                    var connection = Environment.GetEnvironmentVariable("MONGODB_URI") ?? "mongodb+srv://grafo-user:eR85Qon7uUwf7XSl@cluster-demo.bhk8l.mongodb.net/?retryWrites=true&w=majority&appName=Cluster-demo";
                    var db = Environment.GetEnvironmentVariable("DB_NAME") ?? "pensum";
                    return new PensumMongoData(connection, db);
                default:
                    throw new NotSupportedException($"Base de datos no soportada: {tipo}");
            }
        }
    }
}
