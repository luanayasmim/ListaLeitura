using System;
using System.ComponentModel.DataAnnotations;

namespace API_Livros.Models
{
    public class UserOutModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome!")]
        public string NameUserOut { get; set; }

        [Required(ErrorMessage = "Informe o Usuário!")]
        public string LoginUserOut { get; set; }

        [Required(ErrorMessage = "Informe o Email!")]
        [EmailAddress(ErrorMessage = "O email informado não é válido!")]
        public string EmailUserOut { get; set; }

        [Required(ErrorMessage = "Informe a senha!")]
        public string PasswordUserOut { get; set; }


        [Required(ErrorMessage = "Confirme a sua nova senha")]
        [Compare("PasswordUserOut", ErrorMessage = "A senha deve ser igual à informada anteriormente!")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }

        public string VerifyEmail { get; set; }

        public string VerificationCode()
        {
            string code = Guid.NewGuid().ToString().Substring(0, 6);
            this.Code = code;
            return code;
        }
    }
}
