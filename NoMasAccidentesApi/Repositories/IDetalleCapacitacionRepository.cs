using NoMasAccidentesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Repositories
{
    public interface IDetalleCapacitacionRepository
    {
        object getDetalleCapacitacion();

        object getDetalleCapacitacionByCapacitacion(int id);

        object insertDetalleCapacitacion(DetalleCapacitacion detalle);

        object pasarListaDetalleCapacitacion(DetalleCapacitacion detalle, int presente);
    }
}
