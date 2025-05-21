using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace Grafo_pensum.Carrera.Dominio
{
    public class Carrera
    {
        public string Id { get; set; }

        public string Nombre { get; set; }

        public string Departamento { get; set; }

        public Carrera()
        {
            Nombre = string.Empty;
            Departamento = string.Empty;
        }

        public Carrera(string nombre, string departamento)
        {
            Nombre = nombre;
            Departamento = departamento;
        }
    }
}