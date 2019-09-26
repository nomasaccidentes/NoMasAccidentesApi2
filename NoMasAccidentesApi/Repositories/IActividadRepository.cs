using NoMasAccidentesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Repositories
{
    public interface IActividadRepository
    {
        object GetActividad();

        object InsertActividad(Actividad actividad);

        object DeleteActividad(int id);

        object EditaActividad(Actividad actividad, int id);
    }
}
