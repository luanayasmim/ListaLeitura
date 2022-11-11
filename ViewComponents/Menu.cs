using API_Livros.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace API_Livros.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessionUser = HttpContext.Session.GetString("sessionUser");

            if (string.IsNullOrEmpty(sessionUser)) return null;

            UserModel user = JsonConvert.DeserializeObject<UserModel>(sessionUser);

            return View(user);
        }
    }
}
