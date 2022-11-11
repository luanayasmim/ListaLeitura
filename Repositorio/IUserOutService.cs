using API_Livros.Models;

namespace API_Livros.Repositorio
{
    public interface IUserOutService
    {
        UserOutModel Add(UserOutModel userOut);
        UserOutModel LookforId(int id);

    }
}
