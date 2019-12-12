using NoMasAccidentesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Repositories
{
    public interface ITipoAsesoriaEspecialRepository
    {
        object getTipoAsesoriaEspecial();
        object insertTipoAsesoriaEspecial(TipoAsesoriaEspecial asesoriaEspecial);
        object editTipoAsesoriaEspecial(TipoAsesoriaEspecial asesoria, int id);
        object deleteTipoAsesoriaEspecial(int id);

        object obtieneIdPorNombre(TipoAsesoriaEspecial asesoria);
    }
}
