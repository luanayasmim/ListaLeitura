using API_Livros.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Threading.Tasks;
using API_Livros.Repositorio;
using API_Livros.Helpers;

namespace API_Livros.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISessionHelper _session;
        public LoginController(IUserService userService, ISessionHelper session)
        {
            _userService = userService;
            _session = session;
        }

        public IActionResult Index()
        {
            //Se o usuário estiver logado, redireciona para a home
            if (_session.SearchSession() != null)
                return RedirectToAction("Index", "Home");

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
                            _session.StartSession(user);
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

        public IActionResult Exit()
        {
            _session.EndSession();
            return RedirectToAction("Index", "Login");
        }

        public IActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendLink(ResetPasswordModel resetPassword)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = _userService.LookforEmail(resetPassword.Email, resetPassword.Login);


                    if (user != null)
                    {
                        string newPassword = user.DoNewPassword();
                        _userService.Atualizar(user);
                        TempData["MensagemSucesso"] = $"A sua nova senha foi enviada no seu e-mail.";
                        return RedirectToAction("Index", "Login");
                    }
                    else
                        TempData["MensagemErro"] = $"Não foi possível redefinir a senha, verifique os dados informados.";

                }
                return View("Index");
            }
            catch (Exception error)
            {
                TempData["MensagemErro"] = $"Erro ao redefinir a sua senha (ˉ﹃ˉ), detalhes do erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
