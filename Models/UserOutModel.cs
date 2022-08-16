using API_Livros.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace API_Livros.Models
{
    public class UserOutModel
    {

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

        public string VerificationCode()
        {
            string code = Guid.NewGuid().ToString().Substring(0, 6);
            Code = code;
            return code;
        }
    }
}
