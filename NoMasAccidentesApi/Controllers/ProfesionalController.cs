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
    public class ProfesionalController : ControllerBase
    {
        IProfesionalRepository profesionalRepository;

        public ProfesionalController(IProfesionalRepository _profesionalRepository)
        {
            profesionalRepository = _profesionalRepository;
        }

        [Route("api/profesional/GetProfesional")]
        [HttpGet]
        public ActionResult GetProfesional()
        {
            var result = profesionalRepository.GetProfesional();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("api/profesional/InsertProfesional")]
        [HttpPost]
        public ActionResult InsertProfesional([FromBody] Profesional profesional)
        {

            var result = profesionalRepository.InsertProfesional(profesional);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(profesional);
        }

        [Route("api/profesional/DeleteProfesional/{id}")]
        [HttpDelete]
        public ActionResult DeleteProfesional(int id)
        {

            var result = profesionalRepository.DeleteProfesional(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok("Profesional Eliminado Correctamente");
        }


        [Route("api/profesional/EditaProfesional/{id}")]
        [HttpPut]
        public ActionResult EditaProfesional([FromBody] Profesional profesional, int id)
        {

            var result = profesionalRepository.EditaProfesional(profesional, id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(profesional);
        }
    }
}