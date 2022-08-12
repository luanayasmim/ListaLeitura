using API_Livros.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using API_Livros.Enums;

namespace API_Livros.Helpers.Filters
{
    public class UserAdmFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string sessionUser = context.HttpContext.Session.GetString("sessionUser");

            if (string.IsNullOrEmpty(sessionUser))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { {"controller", "Login" }, {"action", "Index" } });
            }
            else
            {
                UserModel user = JsonConvert.DeserializeObject<UserModel>(sessionUser);
                if (user == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }

                if (user.ProfileUser != ProfileEnum.Adm)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Restricted" }, { "action", "Index" } });
                }
            }
            base.OnActionExecuted(context);
        }
    }
}
