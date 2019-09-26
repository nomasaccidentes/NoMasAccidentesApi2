using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Models
{
    public class Actividad
    {
        public int actividad_id { get; set; }
        public string actividad_nombre { get; set; }
        public int actividad_activo { get; set; }

        public int servicio_id { get; set; }

        public Servicio servicio { get; set; }
    }
}
