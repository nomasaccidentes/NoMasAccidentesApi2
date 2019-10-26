using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoMasAccidentesApi.Repositories;

namespace NoMasAccidentesApi.Controllers
{
    [Produces("application/json")]
    public class NoMasAccidentesController : ControllerBase
    {
        INoMasAccidentesRepository INoMasAccidentesRepository;
        public NoMasAccidentesController(INoMasAccidentesRepository _INoMasAccidentesRepository)
        {
            INoMasAccidentesRepository = _INoMasAccidentesRepository;
        }


        [Route("api/nomasaccidentes/GetEstadoSolicitud")]
        [HttpGet]
        public ActionResult GetRubro()
        {
            var result = INoMasAccidentesRepository.getEstadoSolicitud();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }


}