using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo_pensum.Carrera.Dominio
{
    internal interface CarreraInterfaz
    {
        (bool, Exception) InsertarCarrera(Carrera carrera);
        (bool, Exception) InsertarCarrera(Carrera[] carreras);
        (Carrera, Exception) ObtenerCarrera(string carrera);
        (Carrera[], Exception) ObtenerCarreras(string carrera);
        (Carrera[], Exception) ObtenerCarreras();
        (bool, Exception) ActualizarCarrera(Carrera carrera);
        (bool, Exception) ActualizarCarrera(Carrera[] carreras);
        (bool, Exception) EliminarCarrera(Carrera carrera);
        (bool, Exception) EliminarCarrera(Carrera[] carreras);
    }
}
