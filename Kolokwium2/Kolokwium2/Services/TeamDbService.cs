using Kolokwium2.Models;
using Kolokwium2.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Services
{
    public class TeamDbService : ITeamDbService
    {
        private readonly MainDbContext _context;

        public TeamDbService(MainDbContext context)
        {
            _context = context;
        }


        public async Task<TeamDTO> GetTeam(int teamId)
        {
           var team = await _context.Teams.FirstOrDefaultAsync(e=>e.TeamID==teamId);
            if(team == null)
                return null;

            var getTeam = await _context.Teams.
                Where(e => e.TeamID == teamId)
                .Select(e => new TeamDTO
                {
                    TeamName = e.TeamName,
                    TeamDescription = e.TeamDescription,
                    OrganizationName = e.Organization.OrganizationName,

                    Members = e.Memberships
                    .Select(t => new MemberDTO
                    {
                        MemberName = t.Member.MemberName,
                        MemberSurname = t.Member.MemberSurname,
                        MemberNickName = t.Member.MemberNickName,
                        MembershipDate = t.MemberShipDate
                    }).OrderBy(t=>t.MembershipDate).ToList()
                }).FirstOrDefaultAsync();

            return getTeam;
        }



        public async Task<bool> TeamExists(int teamId)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(e => e.TeamID == teamId);
            if(team==null)
                return false;

            return true;
        }
    }
}
