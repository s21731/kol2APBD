using Kolokwium2.Models.DTOs;
using System.Threading.Tasks;

namespace Kolokwium2.Services
{
    public interface ITeamDbService
    {
        Task<TeamDTO> GetTeam(int teamId);
    }
}
