using DotaApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using DotaApp.Data.ApiModels;

namespace Sandbox
{
    class StartUp
    {
        public static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider(true);

            using (var serviceScope = serviceProvider.CreateScope())
            {
                serviceProvider = serviceScope.ServiceProvider;
                var context = serviceProvider.GetService<DotaAppContext>();

                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync("https://api.opendota.com/api/heroStats");
                    var content = await response.Content.ReadAsStringAsync();

                    var heroes = JsonConvert.DeserializeObject<List<Hero>>(content);
                    Console.WriteLine();
                }
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            services.AddDbContext<DotaAppContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
