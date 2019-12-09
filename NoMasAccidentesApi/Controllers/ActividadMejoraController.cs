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
    public class ActividadMejoraController : ControllerBase
    {
        IActividadMejoraRepository actividadMejoraRepository;

        public ActividadMejoraController(IActividadMejoraRepository _actividadMejoraRepository)
        {
            actividadMejoraRepository = _actividadMejoraRepository;
        }

        [Route("api/actividadMejora/getActividadById/{id}")]
        [HttpGet]
        public ActionResult getActividadById(int id)
        {

            var result = actividadMejoraRepository.getActividadMejoraByAsesoria(id);
            if (result == null)
            {

                return NotFound(new { StatusCode = 204, data = "Sin registros" });
            }


            return Ok(new { StatusCode = 200, data = result });
        }

        [Route("api/actividadMejora/insertActividadMejora")]
        [HttpPost]
        public ActionResult insertActividad([FromBody] ActividadMejora actividad)
        {

            var result = actividadMejoraRepository.insertActividadMejora(actividad);
            if (result == null)
            {

                return NotFound(new { StatusCode = 204, data = "Sin registros" });
            }


            return Ok(new { StatusCode = 200, data = result });
        }

        [Route("api/actividadMejora/editaActividadMejora/{id}")]
        [HttpPut]
        public ActionResult editaActividad([FromBody] ActividadMejora actividad, int id)
        {

            var result = actividadMejoraRepository.editActividadMejora(actividad, id);
            if (result == null)
            {

                return NotFound();
            }


            return Ok(1);
        }

        [Route("api/actividadMejora/eliminaActividadMejora/{id}")]
        [HttpDelete]
        public ActionResult eliminaActividad(int id)
        {

            var result = actividadMejoraRepository.deleteActividad(id);
            if (result == null)
            {

                return NotFound();
            }


            return Ok(1);
        }

    }
}