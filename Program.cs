using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Livros
{
    public class Program
    {
        public async void Main()
        {
            var url = Environment.GetEnvironmentVariable("https://lbdqrjcijbbyiremmdsw.supabase.co");
            var key = Environment.GetEnvironmentVariable("l4peV7FS4Qc/UUvx41SVb1nYmxryF/KruasS/ja/Ou3IqQHS/yrmeWzahuWangb1AizgoD4ZpHBGVH7CCTXEZQ==");

            await Supabase.Client.InitializeAsync(url, key);

            var instance = Supabase.Client.Instance;

            var storage = Supabase.Client.Instance.Storage;
            await storage.CreateBucket("testing");
        }

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
