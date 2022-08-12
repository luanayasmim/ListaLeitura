using API_Livros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Livros.Repositorio
{
    public interface IUserService
    {
        UserModel LookforLogin(string login);
        List<UserModel> BuscarTodos();
        UserModel ListarPorId(int id);
        UserModel Adicionar(UserModel livro);
        UserModel Atualizar(UserModel livro);
        bool Apagar(int id);

    }
}
