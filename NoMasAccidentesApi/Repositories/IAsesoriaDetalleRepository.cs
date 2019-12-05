﻿using NoMasAccidentesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Repositories
{
    public interface IAsesoriaDetalleRepository
    {
        object getAsesoriaDetalle();

        object getAsesoriaDetalleByAsesoria(int asesoriaId);

        object insertAsesoriaDetalle(AsesoriaDetalle asesoria);
    }
}
