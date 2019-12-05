using NoMasAccidentesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Repositories
{
    public interface IAsesoriaRepository
    {
        object getAsesorias();

        object getAsesoriaByContrato(int contrato_id);

        object insertAsesoria(Asesoria asesoria);

        object cerrarAsesoria(Asesoria asesoria, int asesoria_id);
    }
}
