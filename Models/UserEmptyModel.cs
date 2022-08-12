using API_Livros.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Livros.Models
{
    public class UserEmptyModel
    {
        public int UserEmptyModelId { get; set; } // Chave primária

        //[Required(ErrorMessage ="Informe o nome!")]
        public string NameUserEmpty { get; set; }

        //[Required(ErrorMessage = "Informe o Usuário!")]
        public string LoginUserEmpty { get; set; }

        //[Required(ErrorMessage = "Informe o Email!")]
        //[EmailAddress(ErrorMessage ="O email informado não é válido!")]
        public string EmailUserEmpty { get; set; }

        //[Required(ErrorMessage = "Informe o Perfil de Acesso!")]
        public ProfileEnum? ProfileUserEmpty { get; set; }

    }
}
