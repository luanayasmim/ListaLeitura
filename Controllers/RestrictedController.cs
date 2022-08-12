using API_Livros.Helpers.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
