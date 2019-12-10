using NoMasAccidentesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Repositories
{
    public interface IPagoContratoDetalleRepository
    {
        object getPagoContratoById(int pagoContrato);
        object insertPagoContratoDetalle(PagoContratoDetalle pago);
    }
}
