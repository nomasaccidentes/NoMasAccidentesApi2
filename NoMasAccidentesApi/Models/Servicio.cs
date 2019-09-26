using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Models
{
    public class Servicio
    {
        public int servicio_id { get; set; }
        public string servicio_nombre { get; set; }
        public int servicio_activo { get; set; }
    }
}
