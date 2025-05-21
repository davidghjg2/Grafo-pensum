using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafo_pensum.Carrera.Dominio;

namespace Grafo_pensum.DB
{
    internal interface CarreraInterfazBase
    {
        (bool, Exception) InsertarCarrera(Grafo_pensum.Carrera.Dominio.Carrera carrera);
        (bool, Exception) InsertarCarrera(Grafo_pensum.Carrera.Dominio.Carrera[] carreras);
        //(Grafo_pensum.Carrera.Dominio.Carrera, Exception) ObtenerCarrera(string carrera);
        //(Carrera.Dominio.Carrera[], Exception) ObtenerCarreras(string carrera);
        (Grafo_pensum.Carrera.Dominio.Carrera[], Exception) ObtenerCarreras();
        (bool, Exception) ActualizarCarrera(Grafo_pensum.Carrera.Dominio.Carrera carrera);
        //(bool, Exception) ActualizarCarrera(Carrera.Dominio.Carrera[] carreras);
        (bool, Exception) EliminarCarrera(Grafo_pensum.Carrera.Dominio.Carrera carrera);
        //(bool, Exception) EliminarCarrera(Carrera.Dominio.Carrera[] carreras);
    }
}
