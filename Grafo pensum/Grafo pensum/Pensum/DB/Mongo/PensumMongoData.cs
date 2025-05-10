using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Grafo_pensum.Pensum.DB.Mongo
{
    internal class PensumMongoData : PensumInterfazBase
    {
        private readonly IMongoClient client;
        private readonly IMongoDatabase database;

        public PensumMongoData(string connectionString, string databaseName)
        {
            client = new MongoClient(connectionString);
            database = client.GetDatabase(databaseName);
        }

        public (bool, Exception) InsertarPensum(Grafo_pensum.Pensum.Dominio.Pensum Pensum)
        {
            try
            {
                var collection = database.GetCollection<PensumMongo>("Pensums");

                PensumMongo data = new PensumMongo
                {
                    codigo = Pensum.Codigo,
                    Carrera = Pensum.carrera,
                    Materia = Pensum.nodos,
                };

                collection.InsertOne(data);

                return (true, null);
            }
            catch (Exception e)
            {
                return (false, e);
            }

        }

        public (bool, Exception) InsertarPensum(Grafo_pensum.Pensum.Dominio.Pensum[] Pensum)
        {
            try
            {
                var collection = database.GetCollection<PensumMongo>("Pensums");

                PensumMongo[] data = new PensumMongo[0];

                foreach (Grafo_pensum.Pensum.Dominio.Pensum c in Pensum)
                {
                    Array.Resize(ref data, data.Length + 1);
                    data[data.Length - 1] = new PensumMongo
                    {
                        codigo = c.Codigo,
                        Carrera = c.carrera,
                        Materia = c.nodos,
                    };
                }

                collection.InsertMany(data);

                return (true, null);
            }
            catch (Exception e)
            {

                return (false, e);
            }
        }

        public (Grafo_pensum.Pensum.Dominio.Pensum[], Exception) ObtenerPensums()
        {
            try
            {
                Grafo_pensum.Pensum.Dominio.Pensum[] retorno = new Grafo_pensum.Pensum.Dominio.Pensum[0];
                var collection = database.GetCollection<PensumMongo>("Pensums");
                PensumMongo[] data = collection.Find(_ => true).ToList().ToArray();

                foreach (PensumMongo Pensum in data)
                {
                    Array.Resize(ref retorno, retorno.Length + 1);
                    retorno[retorno.Length - 1] = new Grafo_pensum.Pensum.Dominio.Pensum
                    {
                        Id = Pensum.Id,
                        Codigo = Pensum.codigo,
                        carrera = Pensum.Carrera,
                        nodos = Pensum.Materia,
                    };
                }
                return (retorno, null);
            }
            catch (Exception e)
            {
                return (null, e);
            }
        }

        public (Grafo_pensum.Pensum.Dominio.Pensum, Exception) ObtenerPensum(string id)
        {
            try
            {
                var collection = database.GetCollection<PensumMongo>("Pensums");
                var filter = Builders<PensumMongo>.Filter.Eq(c => c.Id, id);
                PensumMongo data = collection.Find(filter).FirstOrDefault();

                return (new Grafo_pensum.Pensum.Dominio.Pensum
                {
                    Id = data.Id,
                    carrera = data.Carrera,
                    Codigo = data.codigo,
                    nodos = data.Materia
                }, null);
            }
            catch (Exception e)
            {
                return (null, e);
                throw;
            }
        }

        public (bool, Exception) ActualizarPensum(Grafo_pensum.Pensum.Dominio.Pensum Pensum)
        {
            try
            {
                var collection = database.GetCollection<PensumMongo>("Pensums");
                var filter = Builders<PensumMongo>.Filter.Eq(c => c.Id, Pensum.Id);
                var update = Builders<PensumMongo>.Update.Set(c => c.Materia , Pensum.nodos);
                collection.UpdateOne(filter, update);
                return (true, null);
            }
            catch (Exception e)
            {
                return (false, e);
            }
        }

        public (bool, Exception) EliminarPensum(Grafo_pensum.Pensum.Dominio.Pensum Pensum)
        {
            try
            {
                var collection = database.GetCollection<PensumMongo>("Pensums");
                var filter = Builders<PensumMongo>.Filter.Eq(c => c.Id, Pensum.Id);
                collection.DeleteOne(filter);
                return (true, null);
            }
            catch (Exception e)
            {
                return (false, e);
            }
        }
    }
}
