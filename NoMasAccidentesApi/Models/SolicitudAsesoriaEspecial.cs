using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Models
{
    public class SolicitudAsesoriaEspecial
    {
        public string solicitudAsesoriaDescripcion { get; set; }
        public int cotrato_id { get; set; }

        public int estadoSolicitudId { get; set; }
        public DateTime solicitudFechaAsesoria { get; set; }

        public string solicitudResolucion { get; set; }

        public DateTime solicitudResolucionFecha { get; set; }

        public int solicitudAsesoriaTipoEspecial { get; set; }
    }
}
