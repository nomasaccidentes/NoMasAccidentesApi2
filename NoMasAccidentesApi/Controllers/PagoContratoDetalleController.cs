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
    public class PagoContratoDetalleController : ControllerBase
    {
        IPagoContratoDetalleRepository pagoContratoDetalleRepository;

        public PagoContratoDetalleController(IPagoContratoDetalleRepository _pagoContratoDetalleRepository)
        {
            pagoContratoDetalleRepository = _pagoContratoDetalleRepository;
        }


        [Route("api/pagosDetalle/InsertPagosDetalle")]
        [HttpPost]
        public ActionResult InsertContrato([FromBody] PagoContratoDetalle pagoContrato)
        {

            var response = pagoContratoDetalleRepository.insertPagoContratoDetalle(pagoContrato);
            return Ok();

        }

        [Route("api/pagosDetalle/getPagosDetalleByPagoId/{id}")]
        [HttpGet]
        public ActionResult getPagos(int id)
        {

            var result = pagoContratoDetalleRepository.getPagoContratoById(id);
            if (result == null)
            {

                return NotFound(new { StatusCode = 204, data = "Sin registros" });
            }


            return Ok(new { StatusCode = 200, data = result });

        }

    }
}