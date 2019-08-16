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
using AutoMapper;
using DotaApp.Data.DbModels;
using System.Linq;

namespace Sandbox
{
    class StartUp
    {
        public static async Task Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HeroDto, Hero>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.Roles, opt => opt.Ignore());
            });
            var mapper = config.CreateMapper();

            IServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider(true);

            using (var serviceScope = serviceProvider.CreateScope())
            {
                serviceProvider = serviceScope.ServiceProvider;
                var context = serviceProvider.GetService<DotaAppContext>();

                using (var client = new HttpClient())
                {
                    await PopulateHeroesAndRoles(mapper, context, client);
                }
            }
        }

        private static async Task PopulateHeroesAndRoles(IMapper mapper, DotaAppContext context, HttpClient client)
        {
            var response = await client.GetAsync("https://api.opendota.com/api/heroStats");
            var content = await response.Content.ReadAsStringAsync();

            var heroDtos = JsonConvert.DeserializeObject<List<HeroDto>>(content);
            var heroes = new List<Hero>();

            foreach (var heroDto in heroDtos)
            {
                var hero = mapper.Map<Hero>(heroDto);

                foreach (var roleDefinition in heroDto.Roles)
                {
                    var role = context.Roles.FirstOrDefault(r => r.Name == roleDefinition);

                    if (role == null)
                    {
                        context.Roles.Add(new Role { Name = roleDefinition });
                        context.SaveChanges();

                        role = context.Roles.FirstOrDefault(r => r.Name == roleDefinition);
                    }

                    hero.Roles.Add(new HeroRole { Role = role });
                    heroes.Add(hero);
                }
            }

            context.AddRange(heroes);
            context.SaveChanges();
        }

        private static void ConfigureServices(IServiceCollection services)
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
