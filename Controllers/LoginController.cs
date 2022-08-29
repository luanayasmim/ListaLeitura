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
        private readonly ISessionOutHelper _sessionOut;
        private readonly ISendEmail _email;
        private readonly IUserOutService _userOutService;

        public LoginController(IUserService userService, ISessionHelper session, ISessionOutHelper sessionOut, ISendEmail email, IUserOutService userOutService)
        {
            _userService = userService;
            _session = session;
            _sessionOut = sessionOut;
            _email = email;
            _userOutService = userOutService;
        }

        public IActionResult Index()
        {
            //Se o usuário estiver logado, redireciona para a home
            if (_session.SearchSession() != null)
                return RedirectToAction("Index", "Home");

            //Se o usuário estiver com uma sessão de cadastro pendente, redireciona para a confirmação
            if (_sessionOut.SearchSession() != null)
                return RedirectToAction("ConfirmUser", "Login");

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
                        if (user.PasswordCheck(loginModel.Password))
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

        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(UserOutModel userOut)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (userOut != null)
                    {
                        userOut.VerificationCode();
                        string subject = "Cadastro - Gerenciador de Leitura";
                        string compose = $"Seu código de verificação é {userOut.Code}";
                        bool emailSent = _email.Send(userOut.EmailUserOut, subject, compose);

                        if (emailSent)
                        {
                            TempData["MensagemSucesso"] = $"O código de validação foi enviado para o seu e-mail.";
                            //Inicia a sessão
                            _sessionOut.StartSession(userOut);
                            //Envia para a confirmação
                            return RedirectToAction("ConfirmUser", "Login");
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"Não foi possível enviar o e-mail com o código. Tente novamente mais tarde!";
                            return RedirectToAction("Index", "Login");
                        }
                    }
                    else
                    {
                        TempData["MensagemErro"] = $"Erro ao criar o seu usuário! Tente novamente mais tarde.";
                        return RedirectToAction("Index", "Login");
                    }
                }
                return RedirectToAction("ConfirmUser", "Login");
            }
            catch (Exception err)
            {
                TempData["MensagemErro"] = $@"Erro ao adicionar o usuário (ˉ﹃ˉ), detalhes do erro: {err.Message}";
                return RedirectToAction("Index", "Login");

            }
        }
        public IActionResult ConfirmUser()
        {
            UserOutModel sessionUserOut = _sessionOut.SearchSession();
            return View(sessionUserOut);
        }

        [HttpPost]
        public IActionResult ConfirmUser(UserOutModel userOut)
        {
            try 
            { 
                string code = userOut.Code;
                string verifyCode = userOut.VerifyEmail;

                if (code == verifyCode)
                {
                    UserModel user = new UserModel()
                    {
                        NameUser = userOut.NameUserOut,
                        LoginUser = userOut.LoginUserOut,
                        EmailUser = userOut.EmailUserOut,
                        PasswordUser = userOut.PasswordUserOut,
                        RegisterDateUser = DateTime.Now,
                        ProfileUser = Enums.ProfileEnum.Comum
                    };

                    _userService.Adicionar(user);
                    TempData["MensagemSucesso"] = $"Usuário cadastrado com sucesso. Aproveite a plataforma!";
                    _sessionOut.EndSession();
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    TempData["MensagemErro"] = $"Erro ao validar o código! Tente novamente mais tarde.";
                    return RedirectToAction("Index", "Login");
                }

            }
            catch (Exception err)
            {

                TempData["MensagemErro"] = $"Erro ao validar o código! Detalhes do erro: {err}";
                return View();
            }
        }

        public IActionResult BackLogin()
        {
            _sessionOut.EndSession();
            TempData["MensagemErro"] = $"O usuário não foi validado!";
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

                        string subject = "Nova senha - Gerenciador de Leitura";
                        string compose = $"A sua nova senha é: {newPassword}";
                        bool emailSent = _email.Send(user.EmailUser, subject, compose);

                        if (emailSent)
                        {
                            _userService.Atualizar(user);
                            TempData["MensagemSucesso"] = $"A sua nova senha foi enviada no seu e-mail.";
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"Não foi possível enviar o e-mail com a nova senha. Tente novamente mais tarde!";
                        }
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
