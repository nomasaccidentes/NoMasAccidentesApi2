using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Models
{
    public class RegistroAccidenteDetalle
    {
        public int registroAccidenteDetalleId { get; set; }
        public string registroAccidenteDetalleNombre { get; set; }
        public string registroAccidenteDetalleUsuario { get; set; }
        public DateTime registroAccidenteDetalleFecha { get; set; }

        public int registroAccidenteId { get; set; }
    }
}
