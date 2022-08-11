using API_Livros.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Livros.Models
{
    public class UserModel
    {
        public int UserModelId { get; set; } // Chave primária

        //[Required(ErrorMessage ="Informe o nome!")]
        public string NameUser { get; set; }

        //[Required(ErrorMessage = "Informe o Usuário!")]
        public string LoginUser { get; set; }

        //[Required(ErrorMessage = "Informe o Email!")]
        //[EmailAddress(ErrorMessage ="O email informado não é válido!")]
        public string EmailUser { get; set; }

        //[Required(ErrorMessage = "Informe o Perfil de Acesso!")]
        public ProfileEnum ProfileUser { get; set; }

        //[Required(ErrorMessage = "Informe a senha!")]
        public string PasswordUser { get; set; }

        public DateTime RegisterDateUser { get; set; }
        public DateTime? UpdateDateUser { get; set; } // ? - informa que o campo pode ser nulo
    }
}
