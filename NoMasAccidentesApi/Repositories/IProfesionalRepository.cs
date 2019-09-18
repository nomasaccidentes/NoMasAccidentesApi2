using NoMasAccidentesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Repositories
{
    public interface IProfesionalRepository
    {
        object GetProfesional();

        object InsertProfesional(Profesional profesional);

        object DeleteProfesional(int id);

        object EditaProfesional(Profesional profesional, int id);
    }
}
