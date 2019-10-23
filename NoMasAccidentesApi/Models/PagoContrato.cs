using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Models
{
    public class PagoContrato
    {
        public int pagoContratoId { get; set; }
        public string pagoContratoDescripcion { get;set; }
        public DateTime pagoContratoVcto { get; set; }
        public int clienteId { get; set; }
    }
}
