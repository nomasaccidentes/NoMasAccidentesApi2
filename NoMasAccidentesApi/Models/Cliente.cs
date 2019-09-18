using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Models
{
    public class Cliente
    {
        public int cliente_id { get; set; }
        public string cliente_nombre { get; set; }
        public string cliente_direccion { get; set; }
        public string cliente_rut { get; set; }
        public int cliente_activo { get; set; }

        public int rubro_id { get; set; }
        public Rubro rubro { get; set; }
    }
}
