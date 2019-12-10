using NoMasAccidentesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Repositories
{
    public interface IPagosRepository
    {

        object InsertPagosByContrato(PagoContrato pagosContrato);

        object getPagosByContratoId(int contratoId);

        object ingresaPagoContrato(PagoContrato pago, int id);
    }
}
