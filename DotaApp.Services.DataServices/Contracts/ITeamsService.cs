using DotaApp.Services.Dtos.Teams;
using System.Collections.Generic;

namespace DotaApp.Services.DataServices.Contracts
{
    public interface ITeamsService
    {
        ICollection<TeamDto> All();
    }
}
