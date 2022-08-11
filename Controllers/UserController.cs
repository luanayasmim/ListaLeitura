﻿using API_Livros.Models;
using API_Livros.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace API_Livros.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private ICsvParserService _csvParser;

        //Construtor da classe
        public UserController(IUserService userService, ICsvParserService csvParser)
        {
            _userService = userService;
            _csvParser = csvParser;

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
                if (ModelState.IsValid)
                {
                    _userService.Atualizar(user);
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

        //CSV Helper
        [HttpGet]
        public IActionResult Importar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Importar(FileModel file)
        {
            var filePath = Path.GetTempFileName();

            using (var stream = System.IO.File.Create(filePath))
            {
                await file.FormFile.CopyToAsync(stream);
            }
            _csvParser.ReadCSV(filePath);
            return View("Index");
        }

        //Exportar
        public IActionResult Exportar()
        {
            string path = @"C:\Users\lylourenco\Downloads\usuariosExportado.csv";
            _csvParser.WriteCSV(path);
            return RedirectToAction("Index");
        }
    }
}
