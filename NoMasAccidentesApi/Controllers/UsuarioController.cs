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
        public IActionResult GetUserLogin([FromBody] Login login)
        {


            dynamic result = usuarioRepository.GetUserLogin(login);
            //Se crea una instancia de la clase ro
            if(result != null)
            {
                Usuario u = new Usuario
                {
                    usuario_username = result.USUARIO_USERNAME,
                    usuario_id = Convert.ToInt32(result.USUARIO_ID),
                    usuario_activo = Convert.ToInt32(result.USUARIO_ACTIVO),
                    cliente_id = Convert.ToInt32(result.CLIENTE_ID),
                    profesional_id  = Convert.ToInt32(result.PROFESIONAL_ID),
                    rol_id = Convert.ToInt32(result.ROL_ID)
                };

                if(result.PROFESIONAL_TS_CREACION != null)
                {


                    Profesional p = new Profesional
                    {
                        profesional_id = Convert.ToInt32(result.PROFESIONAL_ID),
                        profesional_nombre = result.PROFESIONAL_NOMBRE,
                        profesional_apellido = result.PROFESIONAL_APELLIDO,
                        profesional_rut = result.PROFESIONAL_RUT,
                        profesional_ts_creacion = result.PROFESIONAL_TS_CREACION,
                       
                    };
                    u.profesional = p;
                }



                if(result.CLIENTE_RUT != null)
                {
                    Rubro rubro = new Rubro
                    {
                        rubro_id = Convert.ToInt32(result.RUBRO_ID),
                        rubro_nombre = result.RUBRO_NOMBRE,
                        rubro_activo = Convert.ToInt32(result.RUBRO_ACTIVO)
                    };

                    Cliente c = new Cliente
                    {
                        cliente_id = Convert.ToInt32(result.CLIENTE_ID),
                        cliente_nombre = result.CLIENTE_NOMBRE,
                        cliente_rut = result.CLIENTE_RUT,
                        cliente_direccion = result.CLIENTE_DIRECCION,
                        rubro = rubro
                    };
                    u.cliente = c;
                }


                Contrato contrato = new Contrato
                {
                    contrato_activo = Convert.ToInt32(result.CONTRATO_ACTIVO),
                    contrato_id = Convert.ToInt32(result.CONTRATO_ID)
                };

                u.contrato = contrato;

                Rol r = new Rol
                {
                    rol_id = Convert.ToInt32(result.ROL_ID),
                    rol_nombre = result.ROL_NOMBRE,
                    rol_activo = Convert.ToInt32(result.ROL_ACTIVO)
                };

                u.rol = r;

                return Ok(new { StatusCode = 200, data = u });
                

                
            }
            

        

            if (result == null)
            {
                return NotFound(new { StatusCode = 204, data = "Usuario Incorrecto" });
            }

            return null;
        }


        [Route("api/usuario/GetUsuarios")]
        [HttpGet]
        public ActionResult GetUsuarios()
        {
            var result = usuarioRepository.GetUsuarios();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [Route("api/usuario/InsertUsuario")]
        [HttpPost]
        public ActionResult InserUsuario([FromBody] UsuarioInsert usuario)
        {

            var result = usuarioRepository.InsertUsuario(usuario);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("api/usuario/DeleteUsuario/{id}")]
        [HttpDelete]
        public ActionResult DeleteUsuario(int id)
        {

            var result = usuarioRepository.DeleteUsuario(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok("Usuario Eliminado Correctamente");
        }


        [Route("api/usuario/EditaUsuario/{id}")]
        [HttpPut]
        public ActionResult EditaUsuario([FromBody] Usuario usuario, int id)
        {

            var result = usuarioRepository.EditaUsuario(usuario, id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }
    }
}