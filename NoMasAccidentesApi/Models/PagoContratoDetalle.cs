using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Models
{
    public class PagoContratoDetalle
    {
        public int pagoContratoDetalleId { get; set; }
        public string pagoContratoDetalleDes { get; set; }
        public int pagoContratoId { get; set; }
    }
}
