using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Livros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Route : ControllerBase
    {

        //Route
        [Route("~/api/Chamado/Cadastrar")]

        [HttpPost]

        public async Task<ActionResult> UnicoArquivo([FromForm] CadastrarFormDataViewModel modelo)
        {
            //Retorna 200
            return Ok(new { });

        }
        //Depois mudar para Model
        public class CadastrarFormDataViewModel

        {

            [FromForm(Name = "anexoChamado[]")]

            public List<IFormFile> Anexos { get; set; } = new List<IFormFile>();

        }
    }
}
