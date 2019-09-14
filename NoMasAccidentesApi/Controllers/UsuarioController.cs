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
    public class UsuarioController : ControllerBase
    {
        IUsuarioRepository usuarioRepository;

        public UsuarioController(IUsuarioRepository _usuarioRepository)
        {
            usuarioRepository = _usuarioRepository;
        }

        [Route("api/usuario/GetUserLogin")]
        [HttpPost]
        public ActionResult GetUserLogin([FromBody] Login login)
        {

            
            var result = usuarioRepository.GetUserLogin(login);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}