using NoMasAccidentesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Repositories
{
    public interface ISolicitudCapacitacionRepository
    {
        object getSolicitudCapacitacion();

        object insertSolicitudCapacitacion(SolicitudCapacitacion solicitud);

        object getSolicitudCapacitacionByContrato(int id);

        object editSolicitudCapacitacion(SolicitudCapacitacion solicitud, int id);
    }
}
