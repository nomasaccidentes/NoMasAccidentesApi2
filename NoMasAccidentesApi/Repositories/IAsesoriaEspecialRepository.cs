using NoMasAccidentesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Repositories
{
    public interface IAsesoriaEspecialRepository
    {
        object getAsesorias();

        object getAsesoriaByContrato(int contrato_id);

        object insertAsesoria(AsesoriaEspecial asesoria);

        object cerrarAsesoria(AsesoriaEspecial asesoria, int asesoria_id);


        object getAsesoriaById(int id);
    }
}
