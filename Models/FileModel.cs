using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Livros.Models
{
    public class FileModel
    {
        public IFormFile FormFile { get; set; }
    }
}
