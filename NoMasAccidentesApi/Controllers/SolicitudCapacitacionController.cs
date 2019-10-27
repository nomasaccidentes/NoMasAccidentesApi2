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
    public class SolicitudCapacitacionController : ControllerBase
    {
        ISolicitudCapacitacionRepository solicitudCapacitacion;

        public SolicitudCapacitacionController(ISolicitudCapacitacionRepository _solicitudCapacitacion)
        {
            solicitudCapacitacion = _solicitudCapacitacion;
        }

        [Route("api/solicitudCapacitacion/getSolicitud")]
        [HttpGet]
        public IActionResult GetSolicitudAsesoria()
        {
            dynamic result = solicitudCapacitacion.getSolicitudCapacitacion();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("api/solicitudCapacitacion/insertSolicitud")]
        [HttpPost]
        public IActionResult InsertSolicitud([FromBody] SolicitudCapacitacion solicitud)
        {
            dynamic result = solicitudCapacitacion.insertSolicitudCapacitacion(solicitud);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("api/solicitudCapacitacion/capByContrato/{id}")]
        [HttpGet]
        public IActionResult GetSolByContrato(int id)
        {
            dynamic result = solicitudCapacitacion.getSolicitudCapacitacionByContrato(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [Route("api/solicitudCapacitacion/editaSolicitudCapacitacion/{id}")]
        [HttpPut]
        public IActionResult GetSolByContrato([FromBody] SolicitudCapacitacion solicitud, int id)

        {
            dynamic result = solicitudCapacitacion.editSolicitudCapacitacion(solicitud, id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok("editado correctamente");
        }
    }
}