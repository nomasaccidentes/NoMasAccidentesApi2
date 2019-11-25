using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Models
{
    public class DetalleCapacitacion
    {
        public int capacitacionDetalleId { get; set; }
        public string capacitacionParticipante { get; set; }
        public string capacitacionCorreo { get; set; }
        public int capacitacionAsiste { get; set; }
        public int capacitacionId { get; set; }
    }
}
