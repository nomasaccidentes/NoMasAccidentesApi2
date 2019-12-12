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
    public class AsesoriaEspecialDetalleController : ControllerBase
    {

        IAsesoriaEspecialDetalleRepository asesoriaDetalleRepository;

        public AsesoriaEspecialDetalleController(IAsesoriaEspecialDetalleRepository _asesoriaDetalleRepository)
        {
            asesoriaDetalleRepository = _asesoriaDetalleRepository;
        }

        [Route("api/asesoriaEspecialDetalle/getAsesoriasDetalle")]
        [HttpGet]
        public ActionResult getAsesorias()
        {

            var result = asesoriaDetalleRepository.getAsesoriaEspecialDetalle();
            if (result == null)
            {

                return NotFound(new { StatusCode = 204, data = "Sin registros" });
            }


            return Ok(new { StatusCode = 200, data = result });
        }

        [Route("api/asesoriaEspecialDetalle/getAsesoriaDetallebyId/{id}")]
        [HttpGet]
        public ActionResult getAsesoriasByContrato(int id)
        {

            var result = asesoriaDetalleRepository.getAsesoriaEspecialDetalleByAsesoria(id);
            if (result == null)
            {

                return NotFound(new { StatusCode = 204, data = "Sin registros" });
            }


            return Ok(new { StatusCode = 200, data = result });
        }

        [Route("api/asesoriaEspecialDetalle/insertAsesoriaDetalle")]
        [HttpPost]
        public ActionResult InsertCapacitacion([FromBody] AsesoriaEspecialDetalle asesoria)
        {

            var result = asesoriaDetalleRepository.insertAsesoriaEspecialDetalle(asesoria);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }
    }
}