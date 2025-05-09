using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo_pensum.Materia.Dominio
{
    internal interface MateriaInterfaz
    {
        (bool, Exception) InsertarMateria(Materia materia);
        (bool, Exception) InsertarMateria(Materia[] materias);
        (Materia, Exception) ObtenerMateria(string materia);
        (Materia[], Exception) ObtenerMaterias(string materia);
        (Materia[], Exception) ObtenerMaterias();
        (bool, Exception) ActualizarMateria(Materia materia);
        (bool, Exception) ActualizarMateria(Materia[] materias);
        (bool, Exception) EliminarMateria(Materia materia);
        (bool, Exception) EliminarMateria(Materia[] materias);
    }
}
