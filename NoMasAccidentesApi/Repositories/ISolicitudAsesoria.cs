using NoMasAccidentesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Repositories
{
   public interface ISolicitudAsesoria
    {

        object getSolicitudesAsesoria();

        object insertSolicitudAsesoria(SolicitudAsesoria solicitud);

        object getSolicitudesAsesoriaByContrato(int id);

        object editaSolicitudAsesoria(SolicitudAsesoria solicitud, int id);
    }
}
