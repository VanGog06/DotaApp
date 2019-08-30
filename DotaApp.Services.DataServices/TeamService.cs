using System;
using System.Collections.Generic;
using System.Linq;
using DotaApp.Data;
using DotaApp.Services.DataServices.Contracts;
using DotaApp.Services.Dtos.Teams;

namespace DotaApp.Services.DataServices
{
    public class TeamService : ITeamService
    {
        private readonly DotaAppContext context;

        public TeamService(DotaAppContext context)
        {
            this.context = context;
        }

        public ICollection<TeamDto> All()
        {
            var dbTeams = this.context.Teams
                .Where(t => !string.IsNullOrEmpty(t.Name) && !string.IsNullOrEmpty(t.LogoUrl))
                .OrderByDescending(t => t.Rating)
                .Take(100)
                .ToList();

            var teams = new List<TeamDto>();

            foreach (var dbTeam in dbTeams)
            {
                DateTime dbLastMatchTime = dbTeam.LastMatchTime;
                DateTime dbLastMatchTimeAsUTC = DateTime.SpecifyKind(dbLastMatchTime, DateTimeKind.Utc);
                DateTime lastMatchTimeLocal = dbLastMatchTimeAsUTC.ToLocalTime();

                var team = new TeamDto
                {
                    Id = dbTeam.Id,
                    LastMatchTime = lastMatchTimeLocal,
                    LogoUrl = dbTeam.LogoUrl,
                    Losses = dbTeam.Losses,
                    Name = dbTeam.Name,
                    Rating = dbTeam.Rating,
                    Wins = dbTeam.Wins
                };

                teams.Add(team);
            }

            return teams;
        }
    }
}
