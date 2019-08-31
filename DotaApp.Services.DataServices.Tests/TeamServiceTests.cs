using DotaApp.Data;
using DotaApp.Data.DbModels;
using DotaApp.Services.DataServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DotaApp.Services.DataServices.Tests
{
    public class TeamServiceTests
    {
        private ITeamService teamsService;

        private List<Team> GetDummyTeams()
        {
            return new List<Team>
            {
                new Team { Name = "First team", Rating = 1200, Wins = 300, Losses = 15, LogoUrl = "Some url", LastMatchTime = DateTime.UtcNow.ToLocalTime() },
                new Team { Name = "Second team", Rating = 1500, Wins = 200, Losses = 150, LogoUrl = "Another url", LastMatchTime = DateTime.UtcNow.ToLocalTime() },
                new Team { Name = "Third team", Rating = 800, Wins = 10, Losses = 50, LogoUrl = "Third url", LastMatchTime = DateTime.UtcNow.ToLocalTime() }
            };
        }

        private List<Team> GetDummyTeamsWithEmptyNameAndLogoUrl()
        {
            return new List<Team>
            {
                new Team { Name = "First team", Rating = 1200, Wins = 300, Losses = 15, LogoUrl = "Some url", LastMatchTime = DateTime.UtcNow.ToLocalTime() },
                new Team { Name = "Second team", Rating = 1500, Wins = 200, Losses = 150, LogoUrl = "Another url", LastMatchTime = DateTime.UtcNow.ToLocalTime() },
                new Team { Name = "Third team", Rating = 800, Wins = 10, Losses = 50, LogoUrl = "Third url", LastMatchTime = DateTime.UtcNow.ToLocalTime() },
                new Team { Name = "Fourth team", Rating = 100, Wins = 411, Losses = 68, LogoUrl = "", LastMatchTime = DateTime.UtcNow.ToLocalTime() },
                new Team { Name = "", Rating = 1234, Wins = 710, Losses = 500, LogoUrl = "Fifth url", LastMatchTime = DateTime.UtcNow.ToLocalTime() }
            };
        }

        private void SeedTeams(DotaAppContext context, List<Team> teams)
        {
            context.Teams.AddRange(teams);
            context.SaveChanges();
        }

        [Fact]
        public void All_WithDummyTeams_ShoudlReturnCorrectResults()
        {
            var context = DotaAppContextInitializer.InitializeContext();
            this.SeedTeams(context, this.GetDummyTeams());

            this.teamsService = new TeamService(context);

            var expectedTeams = context.Teams.ToList();
            var actualTeams = this.teamsService.All();

            Assert.Equal(expectedTeams.Count, actualTeams.Count);
        }

        [Fact]
        public void All_WithDummyTeamsWithEmptyNameAndLogoUrl_ShouldReturnCorrectResults()
        {
            var context = DotaAppContextInitializer.InitializeContext();
            this.SeedTeams(context, this.GetDummyTeamsWithEmptyNameAndLogoUrl());

            this.teamsService = new TeamService(context);

            var expectedTeams = context.Teams
                .Where(t => !string.IsNullOrEmpty(t.Name) && !string.IsNullOrEmpty(t.LogoUrl))
                .ToList();


            var actualTeams = this.teamsService.All();

            Assert.Equal(expectedTeams.Count, actualTeams.Count);
        }

        [Fact]
        public void All_WithDummyData_ShouldBeOrderedByRatingCorrectly()
        {
            var context = DotaAppContextInitializer.InitializeContext();
            this.SeedTeams(context, this.GetDummyTeams());

            this.teamsService = new TeamService(context);

            var expectedTeams = context.Teams
                .OrderByDescending(t => t.Rating)
                .ToList();

            var actualTeams = this.teamsService.All();

            Assert.Equal(expectedTeams.First().Name, actualTeams.First().Name);
        }
    }
}
