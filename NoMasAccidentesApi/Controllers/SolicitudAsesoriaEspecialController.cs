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
    public class SolicitudAsesoriaEspecialController : ControllerBase
    {
        ISolicitudAsesoriaEspecialRepository solicitudAsesoriaEspecialRepository;

        public SolicitudAsesoriaEspecialController(ISolicitudAsesoriaEspecialRepository _solicitudAsesoriaEspecialRepository)
        {
            solicitudAsesoriaEspecialRepository = _solicitudAsesoriaEspecialRepository;
        }

        
        [Route("api/solicitudAsesoriaEspecial/getSolicitud")]
        [HttpGet]
        public IActionResult GetSolicitudAsesoria()
        {
            dynamic result = solicitudAsesoriaEspecialRepository.getAsesoriasEspeciales();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [Route("api/solicitudAsesoriaEspecial/insertSolicitud")]
        [HttpPost]
        public IActionResult InsertSolicitud([FromBody] SolicitudAsesoriaEspecial solicitud)
        {
            dynamic result = solicitudAsesoriaEspecialRepository.insertAsesoriaEspecial(solicitud);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("api/solicitudAsesoriaEspecial/solByContrato/{id}")]
        [HttpGet]
        public IActionResult GetSolByContrato(int id)
        {
            dynamic result = solicitudAsesoriaEspecialRepository.getAsesoriaEspecialByContratoId(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("api/solicitudAsesoriaEspecial/editaSolicitudAsesoria/{id}")]
        [HttpPut]
        public IActionResult GetSolByContrato([FromBody] SolicitudAsesoriaEspecial solicitud, int id)

        {
            dynamic result = solicitudAsesoriaEspecialRepository.editaSolicitudAsesoriaEspecial(solicitud, id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok("editado correctamente");
        }
    }
}