using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Models
{
    public class RegistroAccidente
    {
        public int registroAccidenteId { get; set; }
        public string regigstroAccidenteNombre { get; set; }
        public DateTime registroAccidenteFecha { get; set; }
        public int profesionalId { get; set; }
        public int contratoId { get; set; }

        public int asesoriaId { get; set; }
    }
}
