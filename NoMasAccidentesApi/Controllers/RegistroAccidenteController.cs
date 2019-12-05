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
    public class RegistroAccidenteController : ControllerBase
    {


        IRegistroAccidenteRepository registroAccidenteRepository;

        public RegistroAccidenteController(IRegistroAccidenteRepository _registroAccidenteRepository)
        {
            registroAccidenteRepository = _registroAccidenteRepository;
        }

        [Route("api/registroAccidente/getRegistros")]
        [HttpGet]
        public ActionResult getAsesorias()
        {

            var result = registroAccidenteRepository.getAccidentes();
            if (result == null)
            {

                return NotFound(new { StatusCode = 204, data = "Sin registros" });
            }


            return Ok(new { StatusCode = 200, data = result });
        }

        [Route("api/registroAccidente/registroAccidenteByContrato/{id}")]
        [HttpGet]
        public ActionResult getAsesoriasByContrato(int id)
        {

            var result = registroAccidenteRepository.getAccidentesByContratoId(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("api/registroAccidente/insertRegistroAccidente")]
        [HttpPost]
        public ActionResult InsertCapacitacion([FromBody] RegistroAccidente registro)
        {

            var result = registroAccidenteRepository.insertRegistroAccidente(registro);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }
    }
}