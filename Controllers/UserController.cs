using API_Livros.Helpers.Filters;
using API_Livros.Models;
using API_Livros.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace API_Livros.Controllers
{
    [UserFilter]
    [UserAdmFilter]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        //Construtor da classe
        public UserController(IUserService userService)
        {
            _userService = userService;

        }

        //Métodos GET
        public IActionResult Index()
        {
            var users = _userService.BuscarTodos();
            return View(users);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            //Recebendo informações
            UserModel user = _userService.ListarPorId(id);
            return View(user);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            //Recebendo informações
            UserModel user = _userService.ListarPorId(id);
            return View(user);
        }

        //Métodos POST
        [HttpPost]
        public IActionResult Criar(UserModel p_user) //Sobrecarga do método
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userService.Adicionar(p_user);
                    TempData["MensagemSucesso"] = @"Usuário adicionado com sucesso \(￣︶￣*\))";
                    return RedirectToAction("Index");
                }
                return View(p_user);
            }
            catch (System.Exception error)
            {
                TempData["MensagemErro"] = $@"Erro ao adicionar o usuário (ˉ﹃ˉ), detalhes do erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(UserModel user) //Sobrecarga do método
        {
            try
            {
                UserModel userUpdated = null;
                if (ModelState.IsValid)
                {
                    userUpdated = new UserModel()
                    {
                        UserModelId = user.UserModelId,
                        NameUser = user.NameUser,
                        LoginUser = user.LoginUser,
                        EmailUser = user.EmailUser,
                        ProfileUser = user.ProfileUser,
                        PasswordUser= user.PasswordUser,
                        RegisterDateUser = user.RegisterDateUser,
                        UpdateDateUser = DateTime.Now
                    };
                    user = _userService.Atualizar(userUpdated);
                    TempData["MensagemSucesso"] = @"Usuário atualizado com sucesso \(￣︶￣*\))";
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            catch (System.Exception error)
            {
                TempData["MensagemErro"] = $@"Erro ao atualuzar o usuário (ˉ﹃ˉ), detalhes do erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _userService.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuário apagado com sucesso ༼ つ ◕_◕ ༽つ";
                    return RedirectToAction("Index");

                }
                else
                {
                    TempData["MensagemSucesso"] = @"Não foi possivel apagar o usuário ¯\(°_o)/¯";

                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $@"Não foi possivel apagar o usuário ¯\(°_o)/¯ Detalhe do erro...  {erro.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
