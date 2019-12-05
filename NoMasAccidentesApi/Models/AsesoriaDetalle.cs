using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Models
{
    public class AsesoriaDetalle
    {
        public int asesoriaDetalleId {get;set;}
        public string asesoriaDetalleTitulo { get; set; }

        public int asesoriaDetalleCheck { get; set; }

        public int asesoriaId { get; set; }
    }
}
