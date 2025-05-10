using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafo_pensum.Pensum.DB;
using Grafo_pensum.Pensum.Dominio;

namespace Grafo_pensum.Pensum.Infra
{
    internal class PensumInfra : PensumInterfaz
    {
        private readonly PensumInterfazBase db = PensumDB.CrearBase();

        public (bool, Exception) InsertarPensum(Dominio.Pensum Pensum)
        {
            (bool, Exception) result = db.InsertarPensum(Pensum);
            return result;
        }

        public (bool, Exception) InsertarPensum(Dominio.Pensum[] Pensum)
        {
            (bool, Exception) result = db.InsertarPensum(Pensum);
            return result;
        }

        public (Dominio.Pensum, Exception) ObtenerPensum(string id)
        {
            (Dominio.Pensum, Exception) result = db.ObtenerPensum(id);
            return result;
        }

        public (Dominio.Pensum[], Exception) ObtenerPensums(string Pensum)
        {
            Dominio.Pensum[] Pensum1 = null;
            return (Pensum1, null);
        }

        public (Dominio.Pensum[], Exception) ObtenerPensums()
        {
            (Dominio.Pensum[], Exception) data = db.ObtenerPensums();
            return data;
        }

        public (bool, Exception) ActualizarPensum(Dominio.Pensum Pensum)
        {
            (bool, Exception) result = db.ActualizarPensum(Pensum);
            return result;
        }

        public (bool, Exception) ActualizarPensum(Dominio.Pensum[] Pensum)
        {
            return (true, null);
        }

        public (bool, Exception) EliminarPensum(Dominio.Pensum Pensum)
        {
            (bool, Exception) result = db.EliminarPensum(Pensum);
            return result;
        }

        public (bool, Exception) EliminarPensum(Dominio.Pensum[] Pensum)
        {
            return (true, null);
        }
    }
}
