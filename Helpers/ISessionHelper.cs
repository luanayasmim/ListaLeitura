using API_Livros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Livros.Helpers
{
    public interface ISessionHelper
    {
        public void StartSession(UserModel user);
        public void EndSession();
        public UserModel SearchSession();
    }
}
