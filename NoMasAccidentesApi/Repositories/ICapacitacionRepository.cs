using NoMasAccidentesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Repositories
{
    public interface ICapacitacionRepository
    {

        object getCapacitaciones();

        object insertCapacitacion(Capacitacion capacitacion);


        object getCapacitacionByCapacitacionId(int capId);

        object getCapacitacionByContrato(int id);
    }
}
