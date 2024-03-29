﻿using DotaApp.Data;
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
        public static string HERO_STATS_URL = "https://api.opendota.com/api/heroStats";
        public static string TEAMS_URL = "https://api.opendota.com/api/teams";

        public static async Task Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HeroDto, Hero>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.Roles, opt => opt.Ignore());

                cfg.CreateMap<AbilityDto, Ability>()
                    .ForMember(dest => dest.Behavior, opt => opt.Ignore())
                    .ForMember(dest => dest.ManaCost, opt => opt.Ignore())
                    .ForMember(dest => dest.Cooldown, opt => opt.Ignore())
                    .ForMember(dest => dest.AbilityAttributes, opt => opt.Ignore());

                cfg.CreateMap<ItemDto, Item>()
                    .ForMember(dest => dest.ItemAttributes, opt => opt.Ignore());

                cfg.CreateMap<TeamDto, Team>()
                    .ForMember(dest => dest.LogoUrl, opt => opt.MapFrom(t => string.IsNullOrEmpty(t.LogoUrl) ? string.Empty : t.LogoUrl))
                    .ForMember(dest => dest.LastMatchTime, opt => opt.MapFrom(t => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(t.LastMatchTime)));
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
                    //await PopulateHeroesAndRoles(mapper, context, client);
                    //await PopulateTeams(mapper, context, client);
                    //PopulateHeroAbilities(mapper, context);
                    //PopulateItems(mapper, context);
                }
            }
        }

        private static async Task PopulateHeroesAndRoles(IMapper mapper, DotaAppContext context, HttpClient client)
        {
            var response = await client.GetAsync(HERO_STATS_URL);
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

        private static async Task PopulateTeams(IMapper mapper, DotaAppContext context, HttpClient client)
        {
            var response = await client.GetAsync(TEAMS_URL);
            var content = await response.Content.ReadAsStringAsync();

            var teamDtos = JsonConvert.DeserializeObject<List<TeamDto>>(content);
            var teams = new List<Team>();

            foreach (var teamDto in teamDtos)
            {
                var team = mapper.Map<Team>(teamDto);

                teams.Add(team);
            }

            context.Teams.AddRange(teams);
            context.SaveChanges();
        }

        private static void PopulateHeroAbilities(IMapper mapper, DotaAppContext context)
        {
            string lines = File.ReadAllText(@"C:\Users\vango\source\repos\DotaApp\Sandbox\abilities.json");
            var parsedAbilities = JsonConvert.DeserializeObject<Dictionary<string, AbilityDto>>(lines);

            var abilities = new List<Ability>();

            var filteredAbilities = parsedAbilities.Where(a => !string.IsNullOrEmpty(a.Value.AbilityName));

            foreach (KeyValuePair<string, AbilityDto> entry in filteredAbilities)
            {
                var heroName = entry.Key.Split("_")?[0];

                var hero = context.Heroes.FirstOrDefault(h => h.Name.ToLower().Replace("-", "").StartsWith(heroName.ToLower()));

                if (hero != null)
                {
                    var ability = mapper.Map<Ability>(entry.Value);

                    ability.HeroId = hero.Id;
                    ability.Hero = hero;

                    var behaviourType = entry.Value.Behavior != null ? entry.Value.Behavior.GetType().ToString() : typeof(string).ToString();
                    var manaCostType = entry.Value.ManaCost != null ? entry.Value.ManaCost.GetType().ToString() : typeof(string).ToString();
                    var cooldownType = entry.Value.Cooldown != null ? entry.Value.Cooldown.GetType().ToString() : typeof(string).ToString();

                    if (behaviourType == typeof(string).FullName)
                    {
                        ability.Behavior = entry.Value.Behavior;
                    }
                    else
                    {
                        ability.Behavior = string.Join(";", entry.Value.Behavior);
                    }

                    if (manaCostType == typeof(string).FullName)
                    {
                        ability.ManaCost = entry.Value.ManaCost;
                    }
                    else
                    {
                        ability.ManaCost = string.Join(";", entry.Value.ManaCost);
                    }

                    if (cooldownType == typeof(string).FullName)
                    {
                        ability.Cooldown = entry.Value.Cooldown;
                    }
                    else
                    {
                        ability.Cooldown = string.Join(";", entry.Value.Cooldown);
                    }

                    if (cooldownType == typeof(string).FullName)
                    {
                        ability.Cooldown = entry.Value.Cooldown;
                    }
                    else
                    {
                        ability.Cooldown = string.Join(";", entry.Value.Cooldown);
                    }

                    var abilityAttributes = new List<AbilityAttribute>();

                    foreach (var attribute in entry.Value.AbilityAttributes)
                    {
                        var attributeDto = new AbilityAttribute
                        {
                            Key = attribute.Key,
                            Generated = attribute.Generated,
                            Header = attribute.Header
                        };

                        var valueType = attribute.Value != null ? attribute.Value.GetType().ToString() : typeof(string).ToString();

                        if (valueType == typeof(string).FullName)
                        {
                            attributeDto.Value = attribute.Value;
                        }
                        else
                        {
                            attributeDto.Value = string.Join(";", attribute.Value);
                        }

                        abilityAttributes.Add(attributeDto);
                    }
                    ability.AbilityAttributes = abilityAttributes;
                    abilities.Add(ability);
                }
            }

            context.Abilities.AddRange(abilities);
            context.SaveChanges();
        }

        private static void PopulateItems(IMapper mapper, DotaAppContext context)
        {
            string lines = File.ReadAllText(@"C:\Users\vango\source\repos\DotaApp\Sandbox\items.json");
            var parsedItems = JsonConvert.DeserializeObject<Dictionary<string, ItemDto>>(lines);

            var items = new List<Item>();

            foreach (KeyValuePair<string, ItemDto> entry in parsedItems)
            {
                var item = mapper.Map<Item>(entry.Value);

                var itemAttributes = new List<ItemAttribute>();

                foreach (var attribute in entry.Value.ItemAttributes)
                {
                    var itemAttribute = new ItemAttribute
                    {
                        Footer = attribute.Footer,
                        Header = attribute.Header,
                        Key = attribute.Key
                    };

                    var valueType = attribute.Value != null ? attribute.Value.GetType().ToString() : typeof(string).ToString();

                    if (valueType == typeof(string).FullName)
                    {
                        itemAttribute.Value = attribute.Value;
                    }
                    else
                    {
                        itemAttribute.Value = string.Join(";", attribute.Value);
                    }

                    itemAttributes.Add(itemAttribute);
                }

                item.ItemAttributes = itemAttributes;
                items.Add(item);
            }

            context.Items.AddRange(items);
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
