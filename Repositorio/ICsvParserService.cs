using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Livros.Repositorio
{
    public interface ICsvParserService
    {
        void ReadCSV(string path);
    }
}
