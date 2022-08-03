using API_Livros.Models;
using API_Livros.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Livros.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroRepositorio _livroRepositorio;
        private ICsvParserService csvParser;

        //Construtor da classe
        public LivroController(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }
        //Métodos GET
        public IActionResult Index()
        {
            var livros = _livroRepositorio.BuscarTodos();
            return View(livros);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            //Recebendo informações
            LivroModel livro = _livroRepositorio.ListarPorId(id);
            return View(livro);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            //Recebendo informações
            LivroModel livro = _livroRepositorio.ListarPorId(id);
            return View(livro);
        }

        //Métodos POST
        [HttpPost]
        public IActionResult Criar(LivroModel p_livro) //Sobrecarga do método
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _livroRepositorio.Adicionar(p_livro);
                    TempData["MensagemSucesso"] = @"Livro adicionado com sucesso \(￣︶￣*\))";
                    return RedirectToAction("Index");
                }
                return View(p_livro);
            }
            catch (System.Exception error)
            {
                TempData["MensagemErro"] = $@"Erro ao adicionar o livro (ˉ﹃ˉ), detalhes do erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(LivroModel livro) //Sobrecarga do método
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _livroRepositorio.Atualizar(livro);
                    TempData["MensagemSucesso"] = @"Livro atualizado com sucesso \(￣︶￣*\))";
                    return RedirectToAction("Index");
                }
                return View(livro);
            }
            catch (System.Exception error)
            {
                TempData["MensagemErro"] = $@"Erro ao atualuzar o livro (ˉ﹃ˉ), detalhes do erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _livroRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Livro apagado com sucesso ༼ つ ◕_◕ ༽つ";
                    return RedirectToAction("Index");

                }
                else
                {
                    TempData["MensagemSucesso"] = @"Não foi possivel apagar o livro ¯\(°_o)/¯";

                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $@"Não foi possivel apagar o livro ¯\(°_o)/¯ Detalhe do erro...  {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        //CSV Helper
        public IActionResult Importar()
        {
            return View();
        }
        public IActionResult UnicoArquivo(string file)
        {
            csvParser.ReadCSV(file);
            return RedirectToAction("Importar");
        }
    }
}
