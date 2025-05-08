using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafo_pensum.Carrera.Dominio;
using Grafo_pensum.DB;
using Grafo_pensum.DB.Carrera;

namespace Grafo_pensum.Carrera.Infra
{
    internal class CarreraInfra : CarreraInterfaz
    {
        private readonly CarreraInterfazBase db = CarreraDB.CrearBase();
        public (bool, Exception) InsertarCarrera(Dominio.Carrera carrera)
        {
            (bool, Exception) result = db.InsertarCarrera(carrera);
            return result;
        }

        public (bool, Exception) InsertarCarrera(Dominio.Carrera[] carrera)
        {
            (bool, Exception) result = db.InsertarCarrera(carrera);
            return result;
        }

        public (Dominio.Carrera, Exception) ObtenerCarrera(string carrera)
        {
            Dominio.Carrera carrera1 = new Dominio.Carrera();
            return (carrera1, null);
        }

        public (Dominio.Carrera[], Exception) ObtenerCarreras(string carrera)
        {
            Dominio.Carrera[] carrera1 = null;
            return (carrera1, null);
        }

        public (Dominio.Carrera[], Exception) ObtenerCarreras()
        {
            (Dominio.Carrera[], Exception) data = db.ObtenerCarreras();
            return data;
        }

        public (bool, Exception) ActualizarCarrera(Dominio.Carrera carrera)
        {
            (bool, Exception) result = db.ActualizarCarrera(carrera);
            return result;
        }

        public (bool, Exception) ActualizarCarrera(Dominio.Carrera[] carrera)
        {
            return (true, null);
        }

        public (bool, Exception) EliminarCarrera(Dominio.Carrera carrera)
        {
            (bool, Exception) result = db.EliminarCarrera(carrera);
            return result;
        }

        public (bool, Exception) EliminarCarrera(Dominio.Carrera[] carrera)
        {
            return (true, null);
        }
    }
}
