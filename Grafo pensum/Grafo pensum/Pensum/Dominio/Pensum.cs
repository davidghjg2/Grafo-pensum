using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo_pensum.Pensum.Dominio
{
    internal class Pensum
    {
        public string Id { get; set; }
        public string Codigo { get; set; }
        public Materia.Dominio.Materia[] nodos;
        public Carrera.Dominio.Carrera carrera;

        public Pensum() {
            Id = string.Empty;
            nodos = new Materia.Dominio.Materia[0];
            carrera = null;
            Codigo = string.Empty;
        }

        public Pensum(Carrera.Dominio.Carrera carrera)
        {
            nodos = new Materia.Dominio.Materia[0];
            this.carrera = carrera;
        }

        public Pensum(Carrera.Dominio.Carrera carrera, string id)
        {
            nodos = new Materia.Dominio.Materia[0];
            this.Id = id;
            this.carrera = carrera;
        }

        public Pensum(Carrera.Dominio.Carrera carrera, Materia.Dominio.Materia[] materia, string codigo)
        {
            nodos = materia;
            this.carrera = carrera;
            Codigo= codigo;
        }

        public Exception AgregarNodo(Materia.Dominio.Materia materia)
        {
            if (buscarNodo(materia.Codigo) != null)
                return new Exception("No se pueden tener materias repetidas en el pensum");

            Array.Resize(ref nodos, nodos.Length + 1);
            nodos[nodos.Length - 1] = materia;
            return null;
        }

        public Exception EnlazarNodo(string nodo, string requisito)
        {
            Materia.Dominio.Materia materia = buscarNodo(nodo);
            Materia.Dominio.Materia req = buscarNodo(requisito);

            if(req.Codigo == materia.Codigo)
                return new Exception("Una materia noo puede definir como requisito a si mismo");

            bool validacion = materia.reqs.Any(r => r.codigos == req.Codigo);

            if (validacion)
                return new Exception("No se puede agregar como requsito a una misma materia mas de 1 vez");

            materia.nivel = req.nivel + 1;
            materia.AgregarRequisito(req, this.carrera);
            return null;
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
                if (nodo.Codigo == nombre)
                    return nodo;
            }
            return null;
        }

        private int DFS(Materia.Dominio.Materia nodo, Materia.Dominio.Materia[] orden, int indice)
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
                orden[indice] = nodo;
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

        private int alturaGrafo(Materia.Dominio.Materia inicio)
        {
            if (inicio == null)
                return 0;

            int maxAultura = 0;

            foreach (Materia.Dominio.Materia.req requisito in inicio.desb)
            {
                Materia.Dominio.Materia desb = buscarNodo(requisito.codigos);
                int altura = alturaGrafo(desb);

                if(altura > maxAultura)
                    maxAultura = altura;
            }

            return maxAultura + 1;
        }

        private void BFS(ref Materia.Dominio.Materia[] materias, Materia.Dominio.Materia materia, int nivel)
        {
           

            if (materia == null)
                return;

            if(nivel == 1)
            {
                bool yaExiste = materias.Any(m => m.Codigo == materia.Codigo);

                if (!yaExiste)
                {
                    Array.Resize(ref materias, materias.Length + 1);
                    materias[materias.Length - 1] = materia;
                }
            }
            else if(nivel > 1)
            {
                foreach(Materia.Dominio.Materia.req deb in materia.desb)
                {
                    Materia.Dominio.Materia requisito = buscarNodo(deb.codigos);
                    BFS(ref materias, requisito, nivel - 1);
                }
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

        public Materia.Dominio.Materia[] ObtenerMaterias()
        {
            restaurar();
            Materia.Dominio.Materia[] orden = new Materia.Dominio.Materia[nodos.Length];
            int indice = 0;

            foreach (Materia.Dominio.Materia nodo in nodos)
            {
                if (!nodo.Visitado)
                    indice = DFS(nodo, orden, indice);
            }

            Array.Reverse(orden);
            return orden;
        }

        public Materia.Dominio.Materia[] BFS()
        {
            restaurar();
            Materia.Dominio.Materia[] datos = new Materia.Dominio.Materia[0];
            
            int altura = alturaGrafo(nodos[0]);

            for (int i = 1; i <= altura; i++)
                BFS(ref datos, nodos[0], i);

            return datos;
        }
    }
}
