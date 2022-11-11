using API_Livros.Data;
using API_Livros.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_Livros.Repositorio
{
    public class UserService : IUserService
    {
        private readonly BancoContext _bancoContext;
        public UserService(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public UserModel LookforLogin(string login)
        {
            return _bancoContext.Users.FirstOrDefault(x => x.LoginUser.ToUpper() == login.ToUpper());
        }
        public UserModel LookforEmail(string email, string login)
        {
            return _bancoContext.Users.FirstOrDefault(x => x.EmailUser.ToUpper() == email.ToUpper() && x.LoginUser.ToUpper() == login.ToUpper());

        }

        List<UserModel> IUserService.BuscarTodos()
        {
            return _bancoContext.Users
                .Include(x => x.Books)    //Buscando os livros de cada usuário
                .ToList();
        }

        public UserModel ListarPorId(int id)
        {
            return _bancoContext.Users.FirstOrDefault(x => x.UserModelId == id);
        }

        public UserModel Adicionar(UserModel user)
        {
            //Inserindo livro no banco
            user.RegisterDateUser = DateTime.Now;
            user.SetPasswordHash();
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
            userDB.EmailUser = user.EmailUser;
            userDB.PasswordUser = user.PasswordUser;
            user.UpdateDateUser = DateTime.Now;

            _bancoContext.Users.Update(userDB);
            _bancoContext.SaveChanges();
            return userDB;
        }

        public UserModel ChangePassword(ChangePasswordModel passwordModel)
        {
            UserModel userDb = ListarPorId(passwordModel.Id);
            if (userDb == null) throw new Exception("Não foi possivel encontrar o usuário cadastrado!");
            if (!userDb.PasswordCheck(passwordModel.CurrentPassword)) throw new Exception("A senha informada não corresponde a senha atual!");
            if (userDb.PasswordCheck(passwordModel.NewPassword)) throw new Exception("A nova senha não deve ser a mesma que a senha atual!");

            userDb.SetNewPassword(passwordModel.NewPassword);
            userDb.UpdateDateUser = DateTime.Now;

            _bancoContext.Users.Update(userDb);
            _bancoContext.SaveChanges();

            return userDb;
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
