using API_Livros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Livros.Repositorio
{
    public interface IUserOutService
    {
        UserOutModel Add(UserOutModel userOut);
        UserOutModel LookforId(int id);

    }
}
