using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Models
{
    public class Asesoria
    {
        public int asesoria_id { get; set; }
        public string asesoria_detalle { get; set; }
        public DateTime asesoria_fecha { get; set; }
        public string asesoria_comentario_resolucion { get; set; }

        public int contrato_id { get; set; }
        public int profesional_id { get; set; }

        public int tipo_asesoria_id { get; set; }

        public int asesoria_finalizada { get; set; }
    }
}
