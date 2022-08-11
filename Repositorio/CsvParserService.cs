﻿using API_Livros.Mappers;
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
        private readonly IUserService _userService;
        public CsvParserService(ILivroRepositorio livroRepositorio/*, IUserService userService*/)
        {
            _livroRepositorio = livroRepositorio;
            //_userService = userService;
        }
        public void ReadCSV(string path)
        {
            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ",",
                    HasHeaderRecord = true,
                };

                using var reader = new StreamReader(path);
                using var csv = new CsvReader(reader, config);
                csv.Context.RegisterClassMap<LivroMap>();
                //csv.ReadHeader();
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

        public void WriteCSV(string path)
        {
            List<LivroModel> livros = _livroRepositorio.BuscarTodos();

            using (var writer = new StreamWriter(path))

            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteHeader<LivroModel>();
                csv.NextRecord();
                foreach (LivroModel livro in livros)
                {
                    csv.WriteRecord<LivroModel>(livro);
                    csv.NextRecord();
                }
            }
        }
    }
}
