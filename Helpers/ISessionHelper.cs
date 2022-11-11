using API_Livros.Models;

namespace API_Livros.Helpers
{
    public interface ISessionHelper
    {
        public void StartSession(UserModel user);
        public void EndSession();
        public UserModel SearchSession();
    }
}
