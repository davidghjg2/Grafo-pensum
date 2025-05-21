using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafo_pensum.Carrera.Dominio;
using MongoDB.Driver;

namespace Grafo_pensum.DB.Mongo.Carrera
{
    internal class CarreraMongoData : CarreraInterfazBase
    {
        private readonly IMongoClient client;
        private readonly IMongoDatabase database;

        public CarreraMongoData(string connectionString, string databaseName)
        {
            client = new MongoClient(connectionString);
            database = client.GetDatabase(databaseName);
        }

        public (bool, Exception) InsertarCarrera(Grafo_pensum.Carrera.Dominio.Carrera carrera)
        {
            try
            {
                var collection = database.GetCollection<CarreraMongo>("carreras");

                CarreraMongo data = new CarreraMongo
                {
                    Nombre = carrera.Nombre,
                    Departamento = carrera.Departamento,
                };

                collection.InsertOne(data);

                return (true, null);
            }
            catch (Exception e)
            {
                return (false, e);
            }
            
        }

        public (bool, Exception) InsertarCarrera(Grafo_pensum.Carrera.Dominio.Carrera[] carrera)
        {
            try
            {
                var collection = database.GetCollection<CarreraMongo>("carreras");

                CarreraMongo[] data = new CarreraMongo[0];

                foreach (Grafo_pensum.Carrera.Dominio.Carrera c in carrera)
                {
                    Array.Resize(ref data, data.Length + 1);
                    data[data.Length - 1] = new CarreraMongo
                    {
                        Nombre = c.Nombre,
                        Departamento= c.Departamento,
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

        public (Grafo_pensum.Carrera.Dominio.Carrera[], Exception) ObtenerCarreras()
        {
            try
            {
                Grafo_pensum.Carrera.Dominio.Carrera[] retorno = new Grafo_pensum.Carrera.Dominio.Carrera[0];
                var collection = database.GetCollection<CarreraMongo>("carreras");
                CarreraMongo[] data = collection.Find(_ => true).ToList().ToArray();

                foreach(CarreraMongo carrera in data)
                {
                    Array.Resize(ref retorno, retorno.Length + 1);
                    retorno[retorno.Length - 1] = new Grafo_pensum.Carrera.Dominio.Carrera
                    {
                        Id = carrera.Id,
                        Nombre = carrera.Nombre,
                        Departamento = carrera.Departamento,
                    };
                }
                return (retorno, null);
            }
            catch (Exception e)
            {
                return (null, e);
            }
        }

        public (bool, Exception) ActualizarCarrera(Grafo_pensum.Carrera.Dominio.Carrera carrera)
        {
            try
            {
                var collection = database.GetCollection<CarreraMongo>("carreras");
                var filter = Builders<CarreraMongo>.Filter.Eq(c => c.Id, carrera.Id);
                var update = Builders<CarreraMongo>.Update.Set(c => c.Nombre, carrera.Nombre).Set(c => c.Departamento, carrera.Departamento);
                collection.UpdateOne(filter, update);
                return (true, null);
            }
            catch (Exception e)
            {
                return (false, e);
            }
        }

        public (bool, Exception) EliminarCarrera(Grafo_pensum.Carrera.Dominio.Carrera carrera)
        {
            try
            {
                var collection = database.GetCollection<CarreraMongo>("carreras");
                var filter = Builders<CarreraMongo>.Filter.Eq(c => c.Id, carrera.Id);
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
