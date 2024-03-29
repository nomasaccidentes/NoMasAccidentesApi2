﻿using System;
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
    public class ContratoController : ControllerBase
    {
        IContratoRepository contratoRepository;

        public ContratoController(IContratoRepository _contratoRepository)
        {
            contratoRepository = _contratoRepository;
        }


        [Route("api/contrato/GetContrato")]
        [HttpGet]
        public ActionResult GetContrato()
        {
            dynamic result = contratoRepository.GetContrato();

          
            if (result == null)
            {

                return NotFound(new { StatusCode = 204, data = "Sin registros" });
            }


            return Ok(new { StatusCode = 200, data = result });
        }

        [Route("api/contrato/InsertContrato")]
        [HttpPost]
        public ActionResult InsertContrato([FromBody] Contrato contrato)
        {


            var result = contratoRepository.InserContrato(contrato);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [Route("api/contrato/GetContratoByClienteId/{id}")]
        [HttpGet]
        public ActionResult GetContratoByClientId(int id)
        {


            var result = contratoRepository.GetContratoByCliente(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("api/contrato/getLastContrato")]
        [HttpGet]
        public ActionResult GetLastContratoId()
        {


            var result = contratoRepository.GetLastContratoId();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("api/contrato/desactivaContrato/{contratoId}")]
        [HttpPut]
        public ActionResult EditaCliente(int contratoId, [FromBody] Contrato contrato)
        {

            var result = contratoRepository.desactivaContrato(contratoId, contrato);
            if (result == null)
            {
                return NotFound();
            }

            return Ok();
        }


        [Route("api/contrato/GetRestanteAsesoria/{id}")]
        [HttpGet]
        public ActionResult getRestanteAsesoria(int id)
        {


            var result = contratoRepository.obtieneRestanteAsesoria(id);
            if (result == null)
            {

                return NotFound(new { StatusCode = 204, data = "Sin registros" });
            }


            return Ok(new { StatusCode = 200, data = result });
        }

        [Route("api/contrato/GetRestanteCapacitacion/{id}")]
        [HttpGet]
        public ActionResult getRestanteCapacitacion(int id)
        {


            var result = contratoRepository.obtieneRestanteCapacitacion(id);
            if (result == null)
            {

                return NotFound(new { StatusCode = 204, data = "Sin registros" });
            }


            return Ok(new { StatusCode = 200, data = result });
        }


        [Route("api/contrato/getAsesoriasEspecialesByContrato/{id}")]
        [HttpGet]
        public ActionResult getAsesoriasEspecialesByContrato(int id)
        {


            var result = contratoRepository.getAsesoriasEspecialesByContrato(id);
            if (result == null)
            {

                return NotFound(new { StatusCode = 204, data = "Sin registros" });
            }


            return Ok(new { StatusCode = 200, data = result });
        }



        


        [Route("api/contrato/GetContratoAccidente")]
        [HttpGet]
        public ActionResult GetContratoAccidente()
        {
            dynamic result = contratoRepository.getContratoConAccidente();


            if (result == null)
            {

                return NotFound(new { StatusCode = 204, data = "Sin registros" });
            }


            return Ok(new { StatusCode = 200, data = result });
        }






    }
}