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
        UserModel LookforEmail(string email, string login);
        List<UserModel> BuscarTodos();
        UserModel ListarPorId(int id);
        UserModel Adicionar(UserModel livro);
        UserModel Atualizar(UserModel livro);
        UserModel ChangePassword(ChangePasswordModel passwordModel);
        bool Apagar(int id);


    }
}
