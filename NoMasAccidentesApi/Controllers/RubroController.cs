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
    public class RubroController : ControllerBase
    {
        IRubroRepository rubroRepository;

        public RubroController(IRubroRepository _rubroRepository)
        {
            rubroRepository = _rubroRepository;
        }

        [Route("api/rubro/GetRubro")]
        [HttpGet]
        public ActionResult GetRubro()
        {
            var result = rubroRepository.GetRubro();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("api/rubro/InsertRubro")]
        [HttpPost]
        public ActionResult InsertRol([FromBody] Rubro rubro)
        {

            var result = rubroRepository.InsertRubro(rubro);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("api/rubro/DeleteRubro/{id}")]
        [HttpDelete]
        public ActionResult DeleteRubro(int id)
        {

            var result = rubroRepository.DeleteRubro(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok("Rubro Eliminado Correctamente");
        }


        [Route("api/rubro/EditaRubro/{id}")]
        [HttpPut]
        public ActionResult EditaRubro([FromBody] Rubro rubro, int id)
        {

            var result = rubroRepository.EditaRubro(rubro, id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(rubro);
        }
    }
}