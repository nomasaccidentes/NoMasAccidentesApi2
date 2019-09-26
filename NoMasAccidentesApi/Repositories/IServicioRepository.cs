using NoMasAccidentesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Repositories
{
    public interface IServicioRepository
    {
        object GetServicio();

        object InsertServicio(Servicio servicio);

        object DeleteServicio(int id);

        object EditaServicio(Servicio servicio, int id);
    }
}
