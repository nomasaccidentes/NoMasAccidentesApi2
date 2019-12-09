using NoMasAccidentesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Repositories
{
    public interface ITipoAsesoriaRepository
    {
        object getTipoAsesoria();

        object insertTipoAsesoria(TipoAsesoria tipo);

        object editTipoAsesoria(TipoAsesoria asesoria, int id);

        object elimiaTipoAsesoria(int id);


        object obtieneIdPorNombre(TipoAsesoria asesoria);
    }
}
