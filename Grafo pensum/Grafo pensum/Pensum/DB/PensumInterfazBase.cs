using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo_pensum.Pensum.DB
{
    internal interface PensumInterfazBase
    {
        (bool, Exception) InsertarPensum(Grafo_pensum.Pensum.Dominio.Pensum Pensum);
        (bool, Exception) InsertarPensum(Grafo_pensum.Pensum.Dominio.Pensum[] Pensums);
        (Grafo_pensum.Pensum.Dominio.Pensum, Exception) ObtenerPensum(string id);
        //(Pensum.Dominio.Pensum[], Exception) ObtenerPensums(string Pensum);
        (Grafo_pensum.Pensum.Dominio.Pensum[], Exception) ObtenerPensums();
        (bool, Exception) ActualizarPensum(Grafo_pensum.Pensum.Dominio.Pensum Pensum);
        //(bool, Exception) ActualizarPensum(Pensum.Dominio.Pensum[] Pensums);
        (bool, Exception) EliminarPensum(Grafo_pensum.Pensum.Dominio.Pensum Pensum);
        //(bool, Exception) EliminarPensum(Pensum.Dominio.Pensum[] Pensums);
    }
}
