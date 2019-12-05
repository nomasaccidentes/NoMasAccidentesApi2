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

    public class AsesoriaDetalleController : ControllerBase
    {

        IAsesoriaDetalleRepository asesoriaDetalleRepository;

        public AsesoriaDetalleController(IAsesoriaDetalleRepository _asesoriaDetalleRepository)
        {
            asesoriaDetalleRepository = _asesoriaDetalleRepository;
        }

        [Route("api/asesoriaDetalle/getAsesoriasDetalle")]
        [HttpGet]
        public ActionResult getAsesorias()
        {

            var result = asesoriaDetalleRepository.getAsesoriaDetalle();
            if (result == null)
            {

                return NotFound(new { StatusCode = 204, data = "Sin registros" });
            }


            return Ok(new { StatusCode = 200, data = result });
        }

        [Route("api/asesoriaDetalle/getAsesoriaDetallebyId/{id}")]
        [HttpGet]
        public ActionResult getAsesoriasByContrato(int id)
        {

            var result = asesoriaDetalleRepository.getAsesoriaDetalleByAsesoria(id);
            if (result == null)
            {

                return NotFound(new { StatusCode = 204, data = "Sin registros" });
            }


            return Ok(new { StatusCode = 200, data = result });
        }

        [Route("api/asesoriaDetalle/insertAsesoriaDetalle")]
        [HttpPost]
        public ActionResult InsertCapacitacion([FromBody] AsesoriaDetalle asesoria)
        {

            var result = asesoriaDetalleRepository.insertAsesoriaDetalle(asesoria);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }
    }
}