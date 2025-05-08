using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo_pensum
{
    internal class Materia
    {
        public struct req
        {
            public Carrera.Dominio.Carrera carrera;
            public string codigos;
        }

        public string Nombre;
        public bool Visitado;
        public bool EnProceso;
        public int uv;
        public req[] reqs;
        public req[] desb;


        public Materia(string nombre)
        {
            Nombre = nombre;
            Visitado = false;
            EnProceso = false;
            reqs = new req[0];
            desb = new req[0];
        }

        public void AgregarSiguiente(Materia desbloquea, Carrera.Dominio.Carrera carrera)
        {
            Array.Resize(ref desb, desb.Length + 1);
            desb[desb.Length - 1] = new req { carrera = carrera, codigos = desbloquea.Nombre };
        }

        public void AgregarRequisito(Materia requisito, Carrera.Dominio.Carrera carrera)
        {
            Array.Resize(ref reqs, reqs.Length + 1);
            reqs[reqs.Length - 1] = new req { carrera = carrera, codigos = requisito.Nombre };
            requisito.AgregarSiguiente(this, carrera);
        }
    }
}
