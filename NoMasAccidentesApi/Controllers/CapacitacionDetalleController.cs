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
    public class CapacitacionDetalleController : ControllerBase
    {

        IDetalleCapacitacionRepository capacitacionDetalle;

        public CapacitacionDetalleController(IDetalleCapacitacionRepository _capacitacionDetalle)
        {
            capacitacionDetalle = _capacitacionDetalle;
        }

        [Route("api/capacitacionDetalle/getCapacitacionDetalleById/{id}")]
        [HttpGet]
        public ActionResult EditaCliente(int id)
        {

            var result = capacitacionDetalle.getDetalleCapacitacionByCapacitacion(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("api/capacitacionDetalle/insertCapacitacion")]
        [HttpPost]
        public ActionResult InsertCapacitacion([FromBody] DetalleCapacitacion capacitacion)
        {

            var result = capacitacionDetalle.insertDetalleCapacitacion(capacitacion);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("api/capacitacionDetalle/updateLista/{id}")]
        [HttpPut]
        public ActionResult PasarLista([FromBody] DetalleCapacitacion capacitacion, int id)
        {

            var result = capacitacionDetalle.pasarListaDetalleCapacitacion(capacitacion, id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}