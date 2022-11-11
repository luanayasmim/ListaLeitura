using System.ComponentModel.DataAnnotations;

namespace API_Livros.Models
{
    public class ResetPasswordModel
    {
        [Required(ErrorMessage = "Informe o seu usuário!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Informe o email cadastrado!")]
        public string Email { get; set; }

    }
}
