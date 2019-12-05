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
    public class AsesoriaController : ControllerBase
    {
        IAsesoriaRepository iasesoriaRepository;

        public AsesoriaController(IAsesoriaRepository _iasesoriaRepository)
        {
            iasesoriaRepository = _iasesoriaRepository;
        }


        [Route("api/asesoria/getAsesorias")]
        [HttpGet]
        public ActionResult getAsesorias()
        {

            var result = iasesoriaRepository.getAsesorias();
            if (result == null)
            {

                return NotFound(new { StatusCode = 204, data = "Sin registros" });
            }


            return Ok(new { StatusCode = 200, data = result });
        }

        [Route("api/asesoria/getAsesorias/{id}")]
        [HttpGet]
        public ActionResult getAsesoriasByContrato(int id)
        {

            var result = iasesoriaRepository.getAsesoriaByContrato(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("api/asesorias/insertAsesoria")]
        [HttpPost]
        public ActionResult InsertCapacitacion([FromBody] Asesoria asesoria)
        {

            var result = iasesoriaRepository.insertAsesoria(asesoria);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }

        [Route("api/asesorias/cierraAsesoria/{id}")]
        [HttpPut]
        public ActionResult cierraAsesoria([FromBody] Asesoria asesoria, int id)
        {

            var result = iasesoriaRepository.cerrarAsesoria(asesoria, id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}