using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo_pensum.Pensum.Dominio
{
    internal interface PensumInterfaz
    {
        (bool, Exception) InsertarPensum(Pensum Pensum);
        (bool, Exception) InsertarPensum(Pensum[] Pensums);
        (Pensum, Exception) ObtenerPensum(string id);
        (Pensum[], Exception) ObtenerPensums(string Pensum);
        (Pensum[], Exception) ObtenerPensums();
        (bool, Exception) ActualizarPensum(Pensum Pensum);
        (bool, Exception) ActualizarPensum(Pensum[] Pensums);
        (bool, Exception) EliminarPensum(Pensum Pensum);
        (bool, Exception) EliminarPensum(Pensum[] Pensums);
    }
}
