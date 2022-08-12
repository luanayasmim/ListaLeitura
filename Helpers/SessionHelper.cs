using API_Livros.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Livros.Helpers
{
    public class SessionHelper : ISessionHelper
    {
        private readonly IHttpContextAccessor _httpContext;
        public SessionHelper(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public void StartSession(UserModel user)
        {
            string userString = JsonConvert.SerializeObject(user); // Convertendo o objeto pra um json
            _httpContext.HttpContext.Session.SetString("sessionUser", userString); // Recebe uma key e um valor do tipo string
        }
        public void EndSession()
        {
            _httpContext.HttpContext.Session.Remove("sessionUser");
        }

        public UserModel SearchSession()
        {
            string SessionUser = _httpContext.HttpContext.Session.GetString("sessionUser");

            if (string.IsNullOrEmpty(SessionUser)) 
                return null;

            return JsonConvert.DeserializeObject<UserModel>(SessionUser);
        }

    }
}
