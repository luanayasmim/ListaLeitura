using API_Livros.Data;
using API_Livros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Livros.Repositorio
{
    public class UserService : IUserService
    {
        private readonly BancoContext _bancoContext;
        public UserService(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        List<UserModel> IUserService.BuscarTodos()
        {
            return _bancoContext.Users.ToList();
        }

        public UserModel ListarPorId(int id)
        {
            return _bancoContext.Users.FirstOrDefault(x=>x.UserModelId==id);
        }

        public UserModel Adicionar(UserModel user)
        {
            //Inserindo livro no banco
            user.RegisterDateUser = DateTime.Now;
            _bancoContext.Users.Add(user);
            _bancoContext.SaveChanges();
            return user;
        }

        public UserModel Atualizar(UserModel user)
        {
            UserModel userDB = ListarPorId(user.UserModelId);

            if (userDB == null) throw new SystemException("Houve um erro para atualizar o usuário!");

            userDB.NameUser = user.NameUser;
            userDB.LoginUser = user.LoginUser;
            userDB.ProfileUser = user.ProfileUser;
            userDB.PasswordUser = user.PasswordUser;
            user.UpdateDateUser = DateTime.Now;

            _bancoContext.Users.Update(userDB);
            _bancoContext.SaveChanges();
            return userDB;
        }

        public bool Apagar(int id)
        {
            UserModel userDB = ListarPorId(id);

            if (userDB == null) throw new SystemException("Houve um erro para excluir o usuário!");

            _bancoContext.Users.Remove(userDB);
            _bancoContext.SaveChanges();
            return true;
        }

    }
}
