using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo_pensum.Materia.DB
{
    internal interface MateriaInterfazBase
    {
        (bool, Exception) InsertarMateria(Grafo_pensum.Materia.Dominio.Materia Materia);
        (bool, Exception) InsertarMateria(Grafo_pensum.Materia.Dominio.Materia[] Materias);
        //(Grafo_pensum.Materia.Dominio.Materia, Exception) ObtenerMateria(string Materia);
        //(Materia.Dominio.Materia[], Exception) ObtenerMaterias(string Materia);
        (Grafo_pensum.Materia.Dominio.Materia[], Exception) ObtenerMaterias();
        (bool, Exception) ActualizarMateria(Grafo_pensum.Materia.Dominio.Materia Materia);
        //(bool, Exception) ActualizarMateria(Materia.Dominio.Materia[] Materias);
        (bool, Exception) EliminarMateria(Grafo_pensum.Materia.Dominio.Materia Materia);
        //(bool, Exception) EliminarMateria(Materia.Dominio.Materia[] Materias);
    }
}
