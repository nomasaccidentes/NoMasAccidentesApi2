using NoMasAccidentesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Repositories
{
   public interface IReporteAccidenteDetalleRepository
    {

        object getReporteAccienteDetalle();

        object getReporteAccidenteDetalleByContratoId(int registroAccidente);

        object insertRegistroAccidenteDetalle(RegistroAccidenteDetalle reg_detalle);
    }
}
