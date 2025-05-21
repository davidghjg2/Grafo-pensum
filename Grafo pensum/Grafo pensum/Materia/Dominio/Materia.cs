using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo_pensum.Materia.Dominio
{
    [Serializable]
    public class Materia
    {
        [Serializable]
        public class req
        {
            public Carrera.Dominio.Carrera carrera { get; set; }
            public string codigos { get; set; }

            public req()  // Necesario para Mongo
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

        public string Id { get; set; }
        public string Codigo;
        public string Nombre { get; set; }
        public bool Visitado;
        public bool EnProceso;
        public string Descripcion;
        public int uv;
        public int nivel;
        public req[] reqs;
        public req[] desb;


        public Materia()
        {
            Nombre = string.Empty;
            Visitado = false; 
            EnProceso = false;
            reqs = new req[0];
            desb = new req[0];
            Descripcion = string.Empty;
            Codigo = string.Empty;
            nivel = 1;
        }

        public Materia(string nombre)
        {
            Nombre = nombre;
            Visitado = false;
            EnProceso = false;
            reqs = new req[0];
            desb = new req[0];
            Descripcion = string.Empty;
            Codigo= string.Empty;
            nivel=1;
        }

        public Materia(string nombre, string descripcion, string codigo)
        {
            Nombre = nombre;
            Visitado = false;
            EnProceso = false;
            reqs = new req[0];
            desb = new req[0];
            Descripcion = descripcion;
            Codigo = codigo;
            nivel=1;
        }

        public void AgregarSiguiente(Materia desbloquea, Carrera.Dominio.Carrera carrera)
        {
            Array.Resize(ref desb, desb.Length + 1);
            desb[desb.Length - 1] = new req(carrera, desbloquea.Codigo);
        }

        public void AgregarRequisito(Materia requisito, Carrera.Dominio.Carrera carrera)
        {
            Array.Resize(ref reqs, reqs.Length + 1);
            reqs[reqs.Length - 1] = new req(carrera, requisito.Codigo);
            requisito.AgregarSiguiente(this, carrera);
        }
    }
}
