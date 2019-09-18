using System;
using System.Collections;
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
    public class ClienteController : ControllerBase
    {
        IClienteRepository clienteRepository;

        public ClienteController(IClienteRepository _clienteRepository)
        {
            clienteRepository = _clienteRepository;
        }

        [Route("api/cliente/GetCliente")]
        [HttpGet]
        public ActionResult GetCliente()
        {
            dynamic result = clienteRepository.GetCliente();
        
            // Se instancia un array list para poder agregar las clses
            ArrayList arr = new ArrayList();

            foreach (dynamic res in result)
            {
                Rubro r = new Rubro
                {
                    rubro_activo = Convert.ToInt32(res.RUBRO_ACTIVO),
                    rubro_id = Convert.ToInt32(res.RUBRO_ID),
                    rubro_nombre = res.RUBRO_NOMBRE
                };

                Cliente cliente = new Cliente
                {
                    cliente_id = Convert.ToInt32(res.CLIENTE_ID),
                    cliente_direccion = res.CLIENTE_DIRECCION,
                    cliente_nombre = res.CLIENTE_NOMBRE,
                    cliente_rut = res.CLIENTE_RUT,
                    cliente_activo = Convert.ToInt32(res.CLIENTE_ACTIVO),
                    rubro_id = r.rubro_id,
                    rubro = r

                };


                arr.Add(cliente);
            }

            if (result == null)
            {

                return NotFound(new { StatusCode = 204, data = "Sin registros" });
            }


            return Ok(new { StatusCode = 200, data = arr });
        }

        [Route("api/cliente/InsertCliente")]
        [HttpPost]
        public ActionResult InsertCliente([FromBody] Cliente cliente)
        {


            Console.WriteLine(cliente);
            var result = clienteRepository.InsertCliente(cliente);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("api/cliente/DeleteCliente/{id}")]
        [HttpDelete]
        public ActionResult DeleteCliente(int id)
        {

            var result = clienteRepository.DeleteCliente(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok("Cliente Eliminado Correctamente");
        }


        [Route("api/cliente/EditaCliente/{id}")]
        [HttpPut]
        public ActionResult EditaCliente([FromBody] Cliente cliente, int id)
        {

            var result = clienteRepository.EditaCliente(cliente, id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }
    }
}