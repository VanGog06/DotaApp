using DotaApp.Common;
using DotaApp.Data;
using DotaApp.Data.Common;
using DotaApp.Data.DbModels;
using DotaApp.Services.DataServices.Contracts;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DotaApp.Services.DataServices.Tests
{
    public class HeroServiceTests
    {
        private IHeroService heroService;

        private List<Hero> GetDummyHeroes()
        {
            return new List<Hero>
            {
                new Hero { Id = 1, Name = "Pesho", AttackRange = 2, AttackRate = 3.14, AttackType = "Mele" },
                new Hero { Id = 2, Name = "Gosho", AttackRange = 1, AttackRate = 12.5, AttackType = "Range" },
                new Hero { Id = 3, Name = "Stamat", AttackRange = 3, AttackRate = 1.24, AttackType = "Caster" }
            };
        }

        private void SeedHeroes(DotaAppContext context)
        {
            context.Heroes.AddRange(this.GetDummyHeroes());
            context.SaveChanges();
        }

        [Fact]
        public void GetAll_WithDummyHeroes_ShouldReturnCorrectResults()
        {
            var context = DotaAppContextInitializer.InitializeContext();
            this.SeedHeroes(context);

            this.heroService = new HeroService(context);

            var expectedHeroes = context.Heroes.ToList();
            var actualHeroes = this.heroService.GetAll();

            Assert.Equal(expectedHeroes.Count, actualHeroes.Count);
        }

        [Fact]
        public void GetById_WithDummyHeroes_ShouldThrowExceptionWhenItemNotFound()
        {
            var context = DotaAppContextInitializer.InitializeContext();
            this.SeedHeroes(context);

            this.heroService = new HeroService(context);

            int heroId = 777;
            DotaException exception = Assert.Throws<DotaException>(() => this.heroService.GetById(heroId));

            Assert.Equal(Constants.InvalidOperation, exception.Message);
        }

        [Fact]
        public void GetById_WithDummyHeroes_ShouldReturnCorrectResults()
        {
            var context = DotaAppContextInitializer.InitializeContext();
            this.SeedHeroes(context);

            this.heroService = new HeroService(context);

            int heroId = 1;

            var expectedHero = context.Heroes
                .First(h => h.Id == heroId);

            var actualItem = this.heroService.GetById(heroId);

            Assert.Equal(expectedHero.Id, actualItem.Id);
            Assert.Equal(expectedHero.Name, actualItem.Name);
        }
    }
}
