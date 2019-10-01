using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Models
{
    public class Contrato
    {
        public int contrato_id { get; set; }
        public string contrato_descripcion { get; set; }

        public DateTime contrato_fecha_inicio { get; set; }

        public DateTime contrato_fecha_fin { get; set; }

        public int cant_capacitacion { get; set; }

        public int cant_asesoria { get; set; }

        public int contrato_activo { get; set; }

        public int cliente_id { get; set; }

    }
}
