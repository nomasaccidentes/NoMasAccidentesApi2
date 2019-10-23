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
    public class PagosController : ControllerBase
    {
        IPagosRepository pagosRepository;

        public PagosController(IPagosRepository _pagosRepository)
        {
            pagosRepository = _pagosRepository;
        }


        [Route("api/pagos/InsertPagos")]
        [HttpPost]
        public ActionResult InsertContrato([FromBody] PagoContrato pagoContrato)
        {

            var response = pagosRepository.InsertPagosByContrato(pagoContrato);
            return Ok();

        }
    }
}