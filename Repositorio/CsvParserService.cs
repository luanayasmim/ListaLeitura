using API_Livros.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API_Livros.Repositorio
{
    public class CsvParserService : ICsvParserService
    {

        private readonly ILivroRepositorio _livroRepositorio;
        public CsvParserService(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }
        public void ReadCSV(string path)
        {
            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                };

                using var reader = new StreamReader(path);
                using var csv = new CsvReader(reader, config);
                var livros = csv.GetRecords<LivroModel>();

                foreach (var livro in livros)
                {
                    _livroRepositorio.Adicionar(livro);
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        //public void WriteCSVFile(string path, List<LivroModel> livros)
        //{
        //    using(StreamWriter streamWriter= new StreamWriter(path, false, new UTF8Encoding(true)))
        //    using(CsvWriter writer = new CsvWriter(streamWriter))
        //    {
        //        writer.WriteHeader<LivroModel>();
        //        writer.NextRecord();
        //        foreach(LivroModel livro in livros)
        //        {
        //            writer.WriteRecord<LivroModel>(livro);
        //            writer.NextRecord();
        //        }
        //    }
        //}
    }
}
