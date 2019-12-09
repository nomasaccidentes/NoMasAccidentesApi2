using NoMasAccidentesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Repositories
{
    public interface IActividadMejoraRepository
    {
        object getActividadMejoraByAsesoria(int asesoriaId);

        object insertActividadMejora(ActividadMejora actividad);

        object editActividadMejora(ActividadMejora actividad, int id);

        object deleteActividad(int id);
    }
}
