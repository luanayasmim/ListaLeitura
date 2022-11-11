using API_Livros.Data;
using API_Livros.Models;
using System.Linq;

namespace API_Livros.Repositorio
{
    public class UserOutService : IUserOutService
    {
        private readonly BancoContext _dbContext;

        public UserOutService(BancoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserOutModel Add(UserOutModel userOut)
        {
            userOut.VerificationCode();
            _dbContext.UsersOut.Add(userOut);
            _dbContext.SaveChanges();
            return userOut;
        }

        public UserOutModel LookforId(int id)
        {
            return _dbContext.UsersOut.FirstOrDefault(x => x.Id == id);
        }
    }
}
