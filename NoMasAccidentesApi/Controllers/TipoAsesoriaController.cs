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
    public class TipoAsesoriaController : ControllerBase
    {

        ITipoAsesoriaRepository tipoAsesoriaRepository;

        public TipoAsesoriaController(ITipoAsesoriaRepository _tipoAsesoriaRepository)
        {
            tipoAsesoriaRepository = _tipoAsesoriaRepository;
        }

        [Route("api/tipoAsesoria/getTiposAsesoria")]
        [HttpGet]
        public ActionResult getTipoAsesoria()
        {

            var result = tipoAsesoriaRepository.getTipoAsesoria();
            if (result == null)
            {

                return NotFound(new { StatusCode = 204, data = "Sin registros" });
            }


            return Ok(new { StatusCode = 200, data = result });
        }


        [Route("api/tipoAsesoria/insertTipo")]
        [HttpPost]
        public ActionResult insertTipoAsesoria([FromBody] TipoAsesoria tipo)
        {

            var result = tipoAsesoriaRepository.insertTipoAsesoria(tipo);
            if (result == null)
            {

                return NotFound(new { StatusCode = 204, data = "Sin registros" });
            }


            return Ok(new { StatusCode = 200, data = result });
        }

        [Route("api/tipoAsesoria/editTipoAsesoria/{id}")]
        [HttpPut]
        public ActionResult editaTipoAsesoria([FromBody]TipoAsesoria tipo, int id)
        {

            var result = tipoAsesoriaRepository.editTipoAsesoria(tipo, id);
            if (result == null)
            {

                return NotFound(new { StatusCode = 204, data = "Sin registros" });
            }


            return Ok(new { StatusCode = 200, data = result });
        }

        [Route("api/tipoAsesoria/deleteTipoAsesoria/{id}")]
        [HttpPut]
        public ActionResult felete(int id)
        {

            var result = tipoAsesoriaRepository.elimiaTipoAsesoria(id);
            if (result == null)
            {

                return NotFound(new { StatusCode = 204, data = "Sin registros" });
            }


            return Ok(new { StatusCode = 200, data = result });
        }


        [Route("api/tipoAsesoria/getTipoAsesoriaByName")]
        [HttpPost]
        public ActionResult tipoAsesoriaByNombre([FromBody] TipoAsesoria asesoria)
        {

            dynamic result = tipoAsesoriaRepository.obtieneIdPorNombre(asesoria);


            if (result == null)
            {

                return NotFound(new { StatusCode = 204, data = "Sin registros" });
            }


            return Ok(new { StatusCode = 200, data = result });
        }


        
    }
}