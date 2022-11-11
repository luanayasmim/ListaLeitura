using API_Livros.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace API_Livros.ViewComponents
{
    public class ConfirmUser : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessionUserOut = HttpContext.Session.GetString("UserOutAccess");

            if (string.IsNullOrEmpty(sessionUserOut)) return null;

            UserOutModel userOut = JsonConvert.DeserializeObject<UserOutModel>(sessionUserOut);

            return View(userOut);
        }
    }
}
