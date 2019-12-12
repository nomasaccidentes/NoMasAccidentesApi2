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

    public class AsesoriaEspecialController : ControllerBase
    {
        IAsesoriaEspecialRepository asesoriaEspecialRepository;

        public AsesoriaEspecialController(IAsesoriaEspecialRepository _asesoriaEspecialRepository)
        {
            asesoriaEspecialRepository = _asesoriaEspecialRepository;
        }


        [Route("api/asesoriaEspecial/getAsesorias")]
        [HttpGet]
        public ActionResult getAsesorias()
        {

            var result = asesoriaEspecialRepository.getAsesorias();
            if (result == null)
            {

                return NotFound(new { StatusCode = 204, data = "Sin registros" });
            }


            return Ok(new { StatusCode = 200, data = result });
        }

        [Route("api/asesoriaEspecial/getAsesorias/{id}")]
        [HttpGet]
        public ActionResult getAsesoriasByContrato(int id)
        {

            var result = asesoriaEspecialRepository.getAsesoriaByContrato(id);
            if (result == null)
            {

                return NotFound(new { StatusCode = 204, data = "Sin registros" });
            }


            return Ok(new { StatusCode = 200, data = result });
        }

        [Route("api/asesoriasEspecial/insertAsesoria")]
        [HttpPost]
        public ActionResult InsertCapacitacion([FromBody] AsesoriaEspecial asesoria)
        {

            var result = asesoriaEspecialRepository.insertAsesoria(asesoria);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }

        [Route("api/asesoriasEspecial/cierraAsesoria/{id}")]
        [HttpPut]
        public ActionResult cierraAsesoria([FromBody] AsesoriaEspecial asesoria, int id)
        {

            var result = asesoriaEspecialRepository.cerrarAsesoria(asesoria, id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("api/asesoriaEspecial/getAsesoriaById/{id}")]
        [HttpGet]
        public ActionResult getAsesoriasById(int id)
        {

            var result = asesoriaEspecialRepository.getAsesoriaById(id);
            if (result == null)
            {

                return NotFound(new { StatusCode = 204, data = "Sin registros" });
            }


            return Ok(new { StatusCode = 200, data = result });
        }

    }
}