using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafo_pensum.Materia.Dominio;
using Grafo_pensum.DB.Carrera;
using Grafo_pensum.Materia.DB;

namespace Grafo_pensum.Materia.Infra
{
    internal class MateriaInfra : MateriaInterfaz
    {
        private readonly MateriaInterfazBase db = MateriaDB.CrearBase();

        public (bool, Exception) InsertarMateria(Dominio.Materia Materia)
        {
            (bool, Exception) result = db.InsertarMateria(Materia);
            return result;
        }

        public (bool, Exception) InsertarMateria(Dominio.Materia[] Materia)
        {
            (bool, Exception) result = db.InsertarMateria(Materia);
            return result;
        }

        public (Dominio.Materia, Exception) ObtenerMateria(string Materia)
        {
            Dominio.Materia Materia1 = new Dominio.Materia();
            return (Materia1, null);
        }

        public (Dominio.Materia[], Exception) ObtenerMaterias(string Materia)
        {
            Dominio.Materia[] Materia1 = null;
            return (Materia1, null);
        }

        public (Dominio.Materia[], Exception) ObtenerMaterias()
        {
            (Dominio.Materia[], Exception) data = db.ObtenerMaterias();
            return data;
        }

        public (bool, Exception) ActualizarMateria(Dominio.Materia Materia)
        {
            (bool, Exception) result = db.ActualizarMateria(Materia);
            return result;
        }

        public (bool, Exception) ActualizarMateria(Dominio.Materia[] Materia)
        {
            return (true, null);
        }

        public (bool, Exception) EliminarMateria(Dominio.Materia Materia)
        {
            (bool, Exception) result = db.EliminarMateria(Materia);
            return result;
        }

        public (bool, Exception) EliminarMateria(Dominio.Materia[] Materia)
        {
            return (true, null);
        }
    }
}
