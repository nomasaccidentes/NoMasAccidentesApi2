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
    public class SolicitudAsesoriaController : ControllerBase
    {

        ISolicitudAsesoria solicitudAsesoria;

        public SolicitudAsesoriaController(ISolicitudAsesoria _solicitudAsesoria)
        {
            solicitudAsesoria = _solicitudAsesoria;
        }

        [Route("api/solicitudAsesoria/getSolicitud")]
        [HttpGet]
        public IActionResult GetSolicitudAsesoria()
        {
            dynamic result = solicitudAsesoria.getSolicitudesAsesoria();
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("api/solicitudAsesoria/insertSolicitud")]
        [HttpPost]
        public IActionResult InsertSolicitud([FromBody] SolicitudAsesoria solicitud)
        {
                dynamic result = solicitudAsesoria.insertSolicitudAsesoria(solicitud);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("api/solicitudAsesoria/solByContrato/{id}")]
        [HttpGet]
        public IActionResult GetSolByContrato(int id)
        {
            dynamic result = solicitudAsesoria.getSolicitudesAsesoriaByContrato(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("api/solicitudAsesoria/editaSolicitudAsesoria/{id}")]
        [HttpPut]
        public IActionResult GetSolByContrato([FromBody] SolicitudAsesoria solicitud,  int id)

        {
            dynamic result = solicitudAsesoria.editaSolicitudAsesoria(solicitud, id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok("editado correctamente");
        }



        
    }
}