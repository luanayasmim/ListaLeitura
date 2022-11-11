using API_Livros.Helpers.Filters;
using Microsoft.AspNetCore.Mvc;

namespace API_Livros.Controllers
{
    [UserFilter]
    public class RestrictedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
