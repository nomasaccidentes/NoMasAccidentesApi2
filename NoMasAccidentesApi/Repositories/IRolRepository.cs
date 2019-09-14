using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NoMasAccidentesApi.Models;

namespace NoMasAccidentesApi.Repositories
{
    public interface IRolRepository
    {
        object GetRol();

        object InsertRol(Rol rol);

        object DeleteRol(int id);

        object EditaRol(Rol rol, int id);
    }
}
