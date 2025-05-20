using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using UsuarioDominio = Grafo_pensum.Usuario.Dominio.Usuario;

namespace Grafo_pensum.Usuario.Infra
{
    public class AuthService
    {
        private readonly IMongoCollection<UsuarioDominio> coleccionUsuarios;

        public AuthService()
        {
            var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI")
                                   ?? "mongodb+srv://grafo-user:eR85Qon7uUwf7XSl@cluster-demo.bhk8l.mongodb.net/?retryWrites=true&w=majority&appName=Cluster-demo";

            var cliente = new MongoClient(connectionString);
            var database = cliente.GetDatabase("pensum");
            coleccionUsuarios = database.GetCollection<UsuarioDominio>("usuarios");
        }

        public UsuarioDominio Login(string id, string contraseña)
        {
            id = id.Trim();
            contraseña = contraseña.Trim();

            var filtro = Builders<UsuarioDominio>.Filter.Eq(u => u.Id, id);
            var usuario = coleccionUsuarios.Find(filtro).FirstOrDefault();

            if (usuario != null && usuario.Contraseña == contraseña)
            {
                return usuario;
            }

            return null;
        }
    }
}