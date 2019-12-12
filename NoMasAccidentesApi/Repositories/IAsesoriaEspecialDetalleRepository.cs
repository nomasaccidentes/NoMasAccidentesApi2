using NoMasAccidentesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Repositories
{
    public interface IAsesoriaEspecialDetalleRepository
    {

        object getAsesoriaEspecialDetalle();

        object getAsesoriaEspecialDetalleByAsesoria(int asesoriaId);

        object insertAsesoriaEspecialDetalle(AsesoriaEspecialDetalle asesoria);
    }
}
