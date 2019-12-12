using NoMasAccidentesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Repositories
{
    public interface IClienteRepository
    {
        object GetCliente();

        object InsertCliente(Cliente cliente);

        object DeleteCliente(int id);

        object EditaCliente(Cliente cliente, int id);

        object getCorreoClienteByContratoId(int contratoId);
    }
}
