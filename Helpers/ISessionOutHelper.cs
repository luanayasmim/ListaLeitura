using API_Livros.Models;

namespace API_Livros.Helpers
{
    public interface ISessionOutHelper
    {
        public void StartSession(UserOutModel userOut);
        public void EndSession();
        public UserOutModel SearchSession();
    }
}
