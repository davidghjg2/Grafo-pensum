using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioUsuario = Grafo_pensum.Usuario.Dominio.Usuario;
using MongoDB.Driver;

namespace Grafo_pensum.Usuario.DB.Mongo
{
    internal class UsuarioMongoData : UsuarioInterfazBase
    {
        private readonly IMongoClient client;
        private readonly IMongoDatabase database;

        public UsuarioMongoData(string connectionString, string databaseName)
        {
            client = new MongoClient(connectionString);
            database = client.GetDatabase(databaseName);
        }

        public (bool, Exception) InsertarUsuario(DominioUsuario usuario)
        {
            try
            {
                var collection = database.GetCollection<UsuarioMongo>("usuarios");
                UsuarioMongo data = new UsuarioMongo
                {
                    Id = usuario.Id,
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    Contraseña = usuario.Contraseña,
                    Correo = usuario.Correo,
                    TipoUsuario = usuario.TipoUsuario
                };
                collection.InsertOne(data);
                return (true, null);
            }
            catch (Exception e)
            {
                return (false, e);
            }
        }

        // Insertar múltiples usuarios 
        public (bool, Exception) InsertarUsuario(DominioUsuario[] usuarios)
        {
            try
            {
                var collection = database.GetCollection<UsuarioMongo>("usuarios");
                UsuarioMongo[] data = new UsuarioMongo[0];

                foreach (DominioUsuario u in usuarios)
                {
                    Array.Resize(ref data, data.Length + 1);
                    data[data.Length - 1] = new UsuarioMongo
                    {
                        Id = u.Id,
                        Nombre = u.Nombre,
                        Apellido = u.Apellido,
                        Contraseña = u.Contraseña,
                        Correo = u.Correo,
                        TipoUsuario = u.TipoUsuario
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

        // Obtener usuario por Id
        public (DominioUsuario, Exception) ObtenerUsuarioPorId(string id)
        {
            try
            {
                var collection = database.GetCollection<UsuarioMongo>("usuarios");
                UsuarioMongo data = collection.Find(u => u.Id == id).FirstOrDefault();

                if (data == null)
                    return (null, null);

                DominioUsuario usuario = new DominioUsuario
                {
                    Id = data.Id,
                    Nombre = data.Nombre,
                    Apellido = data.Apellido,
                    Contraseña = data.Contraseña,
                    Correo = data.Correo,
                    TipoUsuario = data.TipoUsuario
                };
                return (usuario, null);
            }
            catch (Exception e)
            {
                return (null, e);
            }
        }

        // Obtener todos los usuarios
        public (DominioUsuario[], Exception) ObtenerTodosUsuarios()
        {
            try
            {
                DominioUsuario[] retorno = new DominioUsuario[0];
                var collection = database.GetCollection<UsuarioMongo>("usuarios");
                UsuarioMongo[] data = collection.Find(_ => true).ToList().ToArray();

                foreach (UsuarioMongo u in data)
                {
                    Array.Resize(ref retorno, retorno.Length + 1);
                    retorno[retorno.Length - 1] = new DominioUsuario
                    {
                        Id = u.Id,
                        Nombre = u.Nombre,
                        Apellido = u.Apellido,
                        Contraseña = u.Contraseña,
                        Correo = u.Correo,
                        TipoUsuario = u.TipoUsuario
                    };
                }
                return (retorno, null);
            }
            catch (Exception e)
            {
                return (null, e);
            }
        }


        // Actualizar usuario 
        public (bool, Exception) ActualizarUsuario(DominioUsuario usuario)
        {
            try
            {
                var collection = database.GetCollection<UsuarioMongo>("usuarios");
                var filter = Builders<UsuarioMongo>.Filter.Eq(u => u.Id, usuario.Id);
                var update = Builders<UsuarioMongo>.Update
                    .Set(u => u.Nombre, usuario.Nombre)
                    .Set(u => u.Apellido, usuario.Apellido)
                    .Set(u => u.Contraseña, usuario.Contraseña)
                    .Set(u => u.Correo, usuario.Correo)
                    .Set(u => u.TipoUsuario, usuario.TipoUsuario);

                collection.UpdateOne(filter, update);
                return (true, null);
            }
            catch (Exception e)
            {
                return (false, e);
            }
        }

        // Eliminar usuario
        public (bool, Exception) EliminarUsuario(DominioUsuario usuario)
        {
            try
            {
                var collection = database.GetCollection<UsuarioMongo>("usuarios");
                var filter = Builders<UsuarioMongo>.Filter.Eq(u => u.Id, usuario.Id);
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
