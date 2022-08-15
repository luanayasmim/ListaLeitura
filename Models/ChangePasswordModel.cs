using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Livros.Models
{
    public class ChangePasswordModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe a sua senha atual!")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage ="Informe a nova senha!")]
        public string NewPassword { get; set; }
        
        [Required(ErrorMessage = "Confirme a sua nova senha")]
        [Compare("NewPassword", ErrorMessage ="A senha deve ser igual à informada anteriormente!")]
        public string ConfirmPassword { get; set; }

    }
}
