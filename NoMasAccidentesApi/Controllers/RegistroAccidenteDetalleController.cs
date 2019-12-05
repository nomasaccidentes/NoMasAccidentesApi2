using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoMasAccidentesApi.Models;
using NoMasAccidentesApi.Repositories;

namespace NoMasAccidentesApi.Controllers
{
    [Produces("application/json")]
    public class RegistroAccidenteDetalleController : ControllerBase
    {
        IReporteAccidenteDetalleRepository registroAccidenteDetalleRepository;

        public RegistroAccidenteDetalleController(IReporteAccidenteDetalleRepository _registroAccidenteDetalleRepository)
        {
            registroAccidenteDetalleRepository = _registroAccidenteDetalleRepository;
        }

        [Route("api/registroAccidenteDetalle/getRegistrosDetalle")]
        [HttpGet]
        public ActionResult getAsesorias()
        {

            var result = registroAccidenteDetalleRepository.getReporteAccienteDetalle();
            if (result == null)
            {

                return NotFound(new { StatusCode = 204, data = "Sin registros" });
            }


            return Ok(new { StatusCode = 200, data = result });
        }

        [Route("api/registroAccidenteDetalle/registroAccidenteByRegistroId/{id}")]
        [HttpGet]
        public ActionResult getAsesoriasByContrato(int id)
        {

            var result = registroAccidenteDetalleRepository.getReporteAccidenteDetalleByContratoId(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("api/registroAccidenteDetalle/insertRegistroAccidenteDetalle")]
        [HttpPost]
        public ActionResult InsertCapacitacion([FromBody] RegistroAccidenteDetalle registroDetalle)
        {

            var result = registroAccidenteDetalleRepository.insertRegistroAccidenteDetalle(registroDetalle);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }
    }
}