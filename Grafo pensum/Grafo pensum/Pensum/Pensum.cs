using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo_pensum
{
    internal class Pensum
    {
        private Materia.Dominio.Materia[] nodos;
        private Carrera.Dominio.Carrera carrera;

        public Pensum(Carrera.Dominio.Carrera carrera)
        {
            nodos = new Materia.Dominio.Materia[0];
            this.carrera = carrera;
        }

        public void AgregarNodo(string nombre)
        {
            Materia.Dominio.Materia nodo = new Materia.Dominio.Materia(nombre);
            Array.Resize(ref nodos, nodos.Length + 1);
            nodos[nodos.Length - 1] = nodo;
        }

        public void EnlazarNodo(string nombre, Carrera.Dominio.Carrera carrera, string requisito)
        {
            Materia.Dominio.Materia nodo = buscarNodo(nombre);
            Materia.Dominio.Materia req = buscarNodo(requisito);
            nodo.AgregarRequisito(req, carrera);
        }

        private void restaurar()
        {
            foreach (Materia.Dominio.Materia nodo in nodos)
                nodo.Visitado = false;
        }

        private Materia.Dominio.Materia buscarNodo(string nombre)
        {
            foreach (Materia.Dominio.Materia nodo in nodos)
            {
                if (nodo.Nombre == nombre)
                    return nodo;
            }
            return null;
        }

        private int DFS(Materia.Dominio.Materia nodo, string[] orden, int indice)
        {
            if (nodo.EnProceso)
                throw new Exception("El grafo tiene un ciclo, no se puede ordenar.");

            if (!nodo.Visitado)
            {
                nodo.EnProceso = true;
                foreach (Materia.Dominio.Materia.req dependencia in nodo.desb)
                {
                    Materia.Dominio.Materia newNodo = buscarNodo(dependencia.codigos);
                    indice = DFS(newNodo, orden, indice);
                }

                nodo.EnProceso = false;
                nodo.Visitado = true;
                orden[indice] = nodo.Nombre;
                indice++;
            }
            return indice;
        }

        private void requisitosRecursivo(Materia.Dominio.Materia nodo, ref string[] requisitos)
        {
            foreach (Materia.Dominio.Materia.req req in nodo.reqs)
            {
                if (req.carrera == this.carrera && !requisitos.Contains(req.codigos))
                {
                    Array.Resize(ref requisitos, requisitos.Length + 1);
                    requisitos[requisitos.Length - 1] = req.codigos;
                }
                Materia.Dominio.Materia requisito = buscarNodo(req.codigos);
                requisitosRecursivo(requisito, ref requisitos);
            }
        }

        private void desbloqueadasRecursivas(Materia.Dominio.Materia nodo, ref string[] desbloqueadas)
        {
            foreach (Materia.Dominio.Materia.req deb in nodo.desb)
            {
                if (deb.carrera == this.carrera && !desbloqueadas.Contains(deb.codigos))
                {
                    Array.Resize(ref desbloqueadas, desbloqueadas.Length + 1);
                    desbloqueadas[desbloqueadas.Length - 1] = deb.codigos;
                }
                Materia.Dominio.Materia desbloquea = buscarNodo(deb.codigos);
                desbloqueadasRecursivas(desbloquea, ref desbloqueadas);
            }
        }

        public string[] ObtenerRequisitos(string materia)
        {
            Materia.Dominio.Materia nodo = buscarNodo(materia);
            if (materia == null)
                throw new Exception("La materia no existe en el gradfo");

            string[] requisitos = new string[0];
            requisitosRecursivo(nodo, ref requisitos);
            return requisitos;
        }

        public string[] ObtenerDesbloqueadas(string nombreMateria)
        {
            Materia.Dominio.Materia materia = buscarNodo(nombreMateria);
            if (materia == null)
            {
                throw new ArgumentException("La materia no existe en el grafo.");
            }

            string[] desbloqueadas = new string[0];
            desbloqueadasRecursivas(materia, ref desbloqueadas);
            return desbloqueadas;
        }

        public string[] ObtenerMaterias()
        {
            restaurar();
            string[] orden = new string[nodos.Length];
            int indice = 0;

            foreach (Materia.Dominio.Materia nodo in nodos)
            {
                if (!nodo.Visitado)
                    indice = DFS(nodo, orden, indice);
            }

            Array.Reverse(orden);
            return orden;
        }
    }
}
