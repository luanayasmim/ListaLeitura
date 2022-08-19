using API_Livros.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Livros.Helpers
{

    public class SessionOutHelper : ISessionOutHelper
    {
        private readonly IHttpContextAccessor _httpContext;
        public SessionOutHelper(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public UserOutModel SearchSession()
        {
            string sessionUserOut = _httpContext.HttpContext.Session.GetString("UserOutAccess");
            
            if (string.IsNullOrEmpty(sessionUserOut)) return null;

            return JsonConvert.DeserializeObject<UserOutModel>(sessionUserOut);
        }

        public void StartSession(UserOutModel userOut)
        {
            //Transformando o objeto em um json
            string value = JsonConvert.SerializeObject(userOut);
            _httpContext.HttpContext.Session.SetString("UserOutAccess", value);
        }

        public void EndSession()
        {
            _httpContext.HttpContext.Session.Remove("UserOutAccess");
        }
    }
}
