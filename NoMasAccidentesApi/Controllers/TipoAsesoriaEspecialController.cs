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
    public class TipoAsesoriaEspecialController : ControllerBase
    {

        ITipoAsesoriaEspecialRepository tipoAsesoriaEspecialRepository;

        public TipoAsesoriaEspecialController(ITipoAsesoriaEspecialRepository _tipoAsesoriaEspecialRepository)
        {
            tipoAsesoriaEspecialRepository = _tipoAsesoriaEspecialRepository;
        }


        [Route("api/tipoAsesoriaEspecial/getTipos")]
        [HttpGet]
        public ActionResult getAsesorias()
        {

            var result = tipoAsesoriaEspecialRepository.getTipoAsesoriaEspecial();
            if (result == null)
            {

                return NotFound(new { StatusCode = 204, data = "Sin registros" });
            }


            return Ok(new { StatusCode = 200, data = result });
        }

        [Route("api/tipoAsesoriaEspecial/insertAsesoria")]
        [HttpPost]
        public ActionResult InsertCapacitacion([FromBody] TipoAsesoriaEspecial asesoria)
        {

            var result = tipoAsesoriaEspecialRepository.insertTipoAsesoriaEspecial(asesoria);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }

        [Route("api/tipoAsesoriaEspecial/editTipoAsesoriaEspecial/{id}")]
        [HttpPut]
        public ActionResult cierraAsesoria([FromBody] TipoAsesoriaEspecial asesoria, int id)
        {

            var result = tipoAsesoriaEspecialRepository.editTipoAsesoriaEspecial(asesoria, id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("api/tipoAsesoriaEspecial/deleteTipoAsesoriaEspecial/{id}")]
        [HttpDelete]
        public ActionResult deleteTipo( int id)
        {

            var result = tipoAsesoriaEspecialRepository.deleteTipoAsesoriaEspecial(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}