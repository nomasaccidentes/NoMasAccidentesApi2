using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Models
{
    public class Capacitacion
    {
        public string capacitacionDetalle { get; set; }
        public DateTime capacitacionFecha { get; set; }
        public int contrato_id { get; set; }
        public int profesionalId { get; set; }

    }
}
