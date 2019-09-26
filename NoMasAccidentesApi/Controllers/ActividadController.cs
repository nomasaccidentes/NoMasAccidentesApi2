using System;
using System.Collections;
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
    public class ActividadController : ControllerBase
    {
        IActividadRepository actividadRepository;

        public ActividadController(IActividadRepository _actividadRepository)
        {
            actividadRepository = _actividadRepository;
        }


        [Route("api/actividad/GetActividad")]
        [HttpGet]
        public ActionResult GetActividad()
        {
            dynamic result = actividadRepository.GetActividad();


            //if (result != null)
            //{
            //    Actividad a = new Actividad
            //    {
            //        actividad_nombre = result.ACTIVIDAD_NOMBRE,
            //        actividad_id = result.ACTIVIDAD_ID
            //    };
            //    a.actividad_id = result.ACTIVIDAD_ACTIVO;

            //    Servicio s = new Servicio
            //    {
            //        servicio_id = result.SERVICIO_ID,
            //        servicio_nombre = result.SERVICIO_NOMBRE
            //    };

            //    a.servicio = s;

            //    return Ok(a);
            //}

            ArrayList arr = new ArrayList();

            foreach (dynamic res in result)
            {
                Actividad a = new Actividad
                {
                    actividad_nombre = res.ACTIVIDAD_NOMBRE,
                    actividad_id = Convert.ToInt32(res.ACTIVIDAD_ID),
                    actividad_activo = Convert.ToInt32(res.ACTIVIDAD_ACTIVO),
                    servicio_id = Convert.ToInt32(res.SERVICIO_ID)
                    
                };
                

                Servicio s = new Servicio
                {
                    servicio_id = Convert.ToInt32(res.SERVICIO_ID),
                    servicio_nombre = res.SERVICIO_NOMBRE,
                    servicio_activo = Convert.ToInt32(res.SERVICIO_ACTIVO)
                };

                a.servicio = s;

                arr.Add(a);
            }

            if (result == null)
            {

                return NotFound(new { StatusCode = 204, data = "Sin registros" });
            }


            return Ok(new { StatusCode = 200, data = arr });


        }

        [Route("api/actividad/InsertActividad")]
        [HttpPost]
        public ActionResult InsertActividad([FromBody] Actividad actividad)
        {

            var result = actividadRepository.InsertActividad(actividad);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(actividad);
        }

        [Route("api/actividad/DeleteActividad/{id}")]
        [HttpDelete]
        public ActionResult DeleteActividad(int id)
        {

            var result = actividadRepository.DeleteActividad(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok("Servicio Eliminado Correctamente");
        }


        [Route("api/actividad/EditaActividad/{id}")]
        [HttpPut]
        public ActionResult EditaActividad([FromBody] Actividad actividad, int id)
        {

            var result = actividadRepository.EditaActividad(actividad, id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(actividad);
        }

    }
}