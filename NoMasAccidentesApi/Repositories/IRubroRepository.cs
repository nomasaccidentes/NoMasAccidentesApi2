using NoMasAccidentesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Repositories
{
    public interface IRubroRepository
    {
        object GetRubro();

        object InsertRubro(Rubro rubro);

        object DeleteRubro(int id);

        object EditaRubro(Rubro rubro, int id);
    }
}
