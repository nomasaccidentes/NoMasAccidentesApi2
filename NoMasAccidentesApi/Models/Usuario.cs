﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Models
{
    public class Usuario
    {

        public int usuario_id { get; set; }
        public string usuario_username { get; set; }
        public string usuario_clave { get; set; }

        public int cliente_id { get; set; }
        public Cliente cliente { get; set; }

        public int profesional_id { get; set; }
        public Profesional profesional { get; set; }

        public int rol_id { get; set; }
        public Rol rol;
        public int usuario_activo { get; set; }

        public Contrato contrato;

    }
}
