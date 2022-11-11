using API_Livros.Models;
using CsvHelper.Configuration;

namespace API_Livros.Mappers
{
    public class UserMap : ClassMap<UserModel>
    {
        public UserMap()
        {
            Map(m => m.NameUser).Name("NameUser");
            Map(m => m.LoginUser).Name("LoginUser");
            Map(m => m.EmailUser).Name("EmailUser");
            Map(m => m.ProfileUser).Name("ProfileUser");
            Map(m => m.PasswordUser).Name("PasswordUser");
            Map(m => m.RegisterDateUser).Name("RegisterDateUser");
            Map(m => m.UpdateDateUser).Name("UpdateDateUser");
        }
    }
}
