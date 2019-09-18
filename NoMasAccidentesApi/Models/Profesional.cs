using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Models
{
    public class Profesional
    {
        public int profesional_id { get; set; }
        public string profesional_nombre { get; set; }
        public string profesional_apellido { get; set; }
        public string profesional_rut { get; set; }

        public int profesional_activo { get; set; }
        public DateTime profesional_ts_creacion { get; set; }
    }
}
