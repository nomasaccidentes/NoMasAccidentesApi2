using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Models
{
    public class Cliente
    {
        public int cliente_id { get; set; }
        public string cliente_nombre;
        public string cliente_direccion;
        public string cliente_rut;
        public Rubro rubro { get; set; }
    }
}
