using System.ComponentModel.DataAnnotations;

namespace API_Livros.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Informe o seu usuário!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Informe a sua senha!")]
        public string Password { get; set; }
    }
}
