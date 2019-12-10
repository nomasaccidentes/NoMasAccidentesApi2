using NoMasAccidentesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Repositories
{
    public interface ISolicitudAsesoriaEspecialRepository
    {

        object getAsesoriaEspecialByContratoId(int contrato);

        object insertAsesoriaEspecial(SolicitudAsesoriaEspecial solicitudAsesoriaEspecial);

        object editaSolicitudAsesoriaEspecial(SolicitudAsesoriaEspecial solicitudAsesoriaEspecial, int id);

        object getAsesoriasEspeciales();
    }
}
