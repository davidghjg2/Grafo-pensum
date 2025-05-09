using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Grafo_pensum.Materia.DB.Mongo
{
    internal class MateriaMongoData : MateriaInterfazBase
    {
        private readonly IMongoClient client;
        private readonly IMongoDatabase database;

        public MateriaMongoData(string connectionString, string databaseName)
        {
            client = new MongoClient(connectionString);
            database = client.GetDatabase(databaseName);
        }

        public (bool, Exception) InsertarMateria(Grafo_pensum.Materia.Dominio.Materia Materia)
        {
            try
            {
                var collection = database.GetCollection<MateriaMongo>("Materias");

                MateriaMongo data = new MateriaMongo
                {
                    Codigo = Materia.Codigo,
                    Nombre = Materia.Nombre,
                    Uv = Materia.uv,
                    Descripcion = Materia.Descripcion,
                };

                collection.InsertOne(data);

                return (true, null);
            }
            catch (Exception e)
            {
                return (false, e);
            }

        }

        public (bool, Exception) InsertarMateria(Grafo_pensum.Materia.Dominio.Materia[] Materia)
        {
            try
            {
                var collection = database.GetCollection<MateriaMongo>("Materias");

                MateriaMongo[] data = new MateriaMongo[0];

                foreach (Grafo_pensum.Materia.Dominio.Materia c in Materia)
                {
                    Array.Resize(ref data, data.Length + 1);
                    data[data.Length - 1] = new MateriaMongo
                    {
                        Codigo = c.Codigo,
                        Nombre = c.Nombre,
                        Uv = c.uv,
                        Descripcion= c.Descripcion,
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

        public (Grafo_pensum.Materia.Dominio.Materia[], Exception) ObtenerMaterias()
        {
            try
            {
                Grafo_pensum.Materia.Dominio.Materia[] retorno = new Grafo_pensum.Materia.Dominio.Materia[0];
                var collection = database.GetCollection<MateriaMongo>("Materias");
                MateriaMongo[] data = collection.Find(_ => true).ToList().ToArray();

                foreach (MateriaMongo Materia in data)
                {
                    Array.Resize(ref retorno, retorno.Length + 1);
                    retorno[retorno.Length - 1] = new Grafo_pensum.Materia.Dominio.Materia
                    {
                        Id = Materia.Id,
                        Codigo = Materia.Codigo,
                        Nombre = Materia.Nombre,
                        uv = Materia.Uv,
                        Descripcion = Materia.Descripcion,
                    };
                }
                return (retorno, null);
            }
            catch (Exception e)
            {
                return (null, e);
            }
        }

        public (bool, Exception) ActualizarMateria(Grafo_pensum.Materia.Dominio.Materia Materia)
        {
            try
            {
                var collection = database.GetCollection<MateriaMongo>("Materias");
                var filter = Builders<MateriaMongo>.Filter.Eq(c => c.Id, Materia.Id);
                var update = Builders<MateriaMongo>.Update.Set(c => c.Nombre, Materia.Nombre).Set(c => c.Uv, Materia.uv).Set(c => c.Descripcion, Materia.Descripcion).Set(c => c.Codigo, Materia.Codigo);
                collection.UpdateOne(filter, update);
                return (true, null);
            }
            catch (Exception e)
            {
                return (false, e);
            }
        }

        public (bool, Exception) EliminarMateria(Grafo_pensum.Materia.Dominio.Materia Materia)
        {
            try
            {
                var collection = database.GetCollection<MateriaMongo>("Materias");
                var filter = Builders<MateriaMongo>.Filter.Eq(c => c.Id, Materia.Id);
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
