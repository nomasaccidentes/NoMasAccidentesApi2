using NoMasAccidentesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Repositories
{
   public  interface IRegistroAccidenteRepository
    {

        object getAccidentes();

        object getAccidentesByContratoId(int contratoId);

        object insertRegistroAccidente(RegistroAccidente registro);

        object registroByAsesoriaId(int asesoriaId);

        object getAccidentabilidad(int contratoId);
    }
}
