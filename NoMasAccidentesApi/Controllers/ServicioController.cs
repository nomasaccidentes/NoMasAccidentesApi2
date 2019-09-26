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
    public class ServicioController : ControllerBase
    {
        IServicioRepository servicioRepository;

        public ServicioController(IServicioRepository _servicioRepository)
        {
            servicioRepository = _servicioRepository;
        }


        [Route("api/servicio/GetServicio")]
        [HttpGet]
        public ActionResult GetServicio()
        {
            var result = servicioRepository.GetServicio();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("api/servicio/InsertServicio")]
        [HttpPost]
        public ActionResult InsertServicio([FromBody] Servicio servicio)
        {

            var result = servicioRepository.InsertServicio(servicio);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(servicio);
        }

        [Route("api/servicio/DeleteServicio/{id}")]
        [HttpDelete]
        public ActionResult DeleteServicio(int id)
        {

            var result = servicioRepository.DeleteServicio(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok("Servicio Eliminado Correctamente");
        }


        [Route("api/servicio/EditaServicio/{id}")]
        [HttpPut]
        public ActionResult EditaServicio([FromBody] Servicio servicio, int id)
        {

            var result = servicioRepository.EditaServicio(servicio, id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(servicio);
        }
    }
}