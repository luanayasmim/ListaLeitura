using API_Livros.Helpers;
using API_Livros.Models;
using API_Livros.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API_Livros.Controllers
{
    public class ChangePasswordController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISessionHelper _sessionHelper;

        public ChangePasswordController(IUserService userService, ISessionHelper sessionHelper)
        {
            _userService = userService;
            _sessionHelper = sessionHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Change(ChangePasswordModel passwordModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel userLogin = _sessionHelper.SearchSession();
                    passwordModel.Id = userLogin.UserModelId;
                    _userService.ChangePassword(passwordModel);
                    TempData["MensagemSucesso"] = @"A senha foi alterada com sucesso \(￣︶￣*\))";
                }
                return View("Index", passwordModel);
            }
            catch (Exception error)
            {
                TempData["MensagemErro"] = $@"Erro ao alterar a sua senha  (ˉ﹃ˉ), detalhes do erro: {error.Message}";
                return View("Index", passwordModel);
            }
        }
    }
}
