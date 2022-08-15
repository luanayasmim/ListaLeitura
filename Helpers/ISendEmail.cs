using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Livros.Helpers
{
    public interface ISendEmail
    {
        bool Send(string email, string subject, string compose);
    }
}
