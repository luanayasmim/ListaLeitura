using API_Livros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Livros.Helpers
{
    public interface ISessionOutHelper
    {
        public void StartSession(UserOutModel userOut);
        public void EndSession();
        public UserOutModel SearchSession();
    }
}
