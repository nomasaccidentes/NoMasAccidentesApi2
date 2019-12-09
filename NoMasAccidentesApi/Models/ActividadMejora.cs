using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Models
{
    public class ActividadMejora
    {
        public int actividadMejoraId { get; set; }
        public string actividadMejoraDesc { get; set; }
        public int asesoriaId { get; set; }
    }
}
