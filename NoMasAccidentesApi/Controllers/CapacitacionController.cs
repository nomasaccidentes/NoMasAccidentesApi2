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
    public class CapacitacionController : ControllerBase
    {

        ICapacitacionRepository ICapacitacionRepository;

        public CapacitacionController(ICapacitacionRepository _ICapacitacionRepository)
        {
            ICapacitacionRepository = _ICapacitacionRepository;
        }


        [Route("api/capacitacion/getCapacitacion")]
        [HttpGet]
        public ActionResult getCapaciraciones()
        {

            var result = ICapacitacionRepository.getCapacitaciones();
            if (result == null)
            {

                return NotFound(new { StatusCode = 204, data = "Sin registros" });
            }


            return Ok(new { StatusCode = 200, data = result });
        }

        [Route("api/capacitacion/getCapacitacionById/{id}")]
        [HttpGet]
        public ActionResult EditaCliente(int id)
        {

            var result = ICapacitacionRepository.getCapacitacionByContrato(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("api/capacitacion/insertCapacitacion")]
        [HttpPost]
        public ActionResult InsertCapacitacion ([FromBody] Capacitacion capacitacion)
        {

            var result = ICapacitacionRepository.insertCapacitacion(capacitacion);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }




    }
}