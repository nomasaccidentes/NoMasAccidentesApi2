using NoMasAccidentesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Repositories
{
    public interface IContratoRepository
    {
        object GetContrato();

        object GetContratoByCliente(int id);

        object InserContrato(Contrato contrato);

        object GetLastContratoId();

        object desactivaContrato(int contratoId, Contrato contrato);

        object obtieneRestanteCapacitacion(int contratoId);

        object obtieneRestanteAsesoria(int contratoId);

        object getAsesoriasEspecialesByContrato(int contratoId);


        object getContratoConAccidente();
    }
}
