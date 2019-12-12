using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Models
{
    public class AsesoriaEspecial
    {

        public int asesoriaEspecialId { get; set; }
        public string asesoriaEspecialNombre { get; set; }
        public DateTime asesoriaEspecialFecha { get; set; }

        public int profesionalId { get; set; }
        public int contratoId { get; set; }


        public int tipoAsesoriaEspecialId { get; set; }

        public int asesoriaFinalizada { get; set; }

        public string asesoriaComentarioResolucion { get; set; }

    }
}
