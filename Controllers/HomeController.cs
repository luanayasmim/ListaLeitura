using API_Livros.Helpers.Filters;
using API_Livros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

/*
 * Toda a interação do projeto é feita atráves da Controller
 * Ela tem acesso direto à Model e a View do projeto 
 * Ou seja Todas as requisições que são feitas na view a Controller pode selecionar o que é pedido na Model 
 * E voltar a informação para View
 * 
 */
namespace API_Livros.Controllers
{
    [UserFilter]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            //Instaciando a homeModel
            HomeModel home = new HomeModel();
            home.Nome = "Luana";

            //Passando informação para a view
            return View(home);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
