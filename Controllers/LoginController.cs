using API_Livros.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Threading.Tasks;
using API_Livros.Repositorio;

namespace API_Livros.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Entry(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   UserModel user = _userService.LookforLogin(loginModel.Login);


                    if (user != null)
                    {
                        if(user.PasswordCheck(loginModel.Password))
                        {
                            return RedirectToAction("Index", "Home");
                                                    //Ação    Controller
                        }
                        TempData["MensagemErro"] = $"Usuário ou senha inválidos.";
                    }
                    else
                        TempData["MensagemErro"] = $"Usuário ou senha inválidos.";

                }
                return View("Index");
            }
            catch (Exception error)
            {
                TempData["MensagemErro"] = $"Erro ao realizar o login (ˉ﹃ˉ), detalhes do erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
