﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
