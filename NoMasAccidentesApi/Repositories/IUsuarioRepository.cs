using NoMasAccidentesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Repositories
{
    public interface IUsuarioRepository
    {
        object GetUserLogin(Login login);

        object GetUsuarios();

        object DeleteUsuario(int id);

        object InsertUsuario(Usuario usuario);

        object EditaUsuario(Usuario usuario, int id);
    }
}
