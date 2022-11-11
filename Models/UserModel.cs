using API_Livros.Enums;
using API_Livros.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Livros.Models
{
    //[Table("Users")]
    public class UserModel //:SupabaseModel
    {
        //[PrimaryKey("user_id", false)]
        public int UserModelId { get; set; } // Chave primária

        //[Column("user_name")]
        [Required(ErrorMessage = "Informe o nome!")]
        public string NameUser { get; set; }

        //[Column("login")]
        [Required(ErrorMessage = "Informe o Usuário!")]
        public string LoginUser { get; set; }

        //[Column("user_email")]
        [Required(ErrorMessage = "Informe o Email!")]
        //[EmailAddress(ErrorMessage ="O email informado não é válido!")]
        public string EmailUser { get; set; }

        //[Column("user_profile")]
        [Required(ErrorMessage = "Informe o Perfil de Acesso!")]
        public ProfileEnum? ProfileUser { get; set; }

        //[Column("password")]
        [Required(ErrorMessage = "Informe a senha!")]
        public string PasswordUser { get; set; }

        //[Column("register_date")]
        public DateTime RegisterDateUser { get; set; }

        //[Column("updade_date")]
        public DateTime? UpdateDateUser { get; set; } // ? - informa que o campo pode ser nulo

        //Busca a lista de livros 1 - n
        public virtual List<LivroModel> Books { get; set; }

        public bool PasswordCheck(string password)
        {
            return PasswordUser == password.DoHash();
        }

        public void SetNewPassword(string newPassword)
        {
            PasswordUser = newPassword.DoHash();
        }

        public void SetPasswordHash()
        {
            PasswordUser = PasswordUser.DoHash(); //Método de extensão com o uso do this
        }

        public string DoNewPassword()
        {
            string newPassword = Guid.NewGuid().ToString().Substring(0, 8);
            PasswordUser = newPassword.DoHash();
            return newPassword;
        }
    }
}
