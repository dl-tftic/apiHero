using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAO.Repository;
using DAOM = DAO.Models;
using DTOM = DTO.Models;
using apiHero.Mappers;

namespace apiHero.Services
{
    public class TeamHeroesService
    {

        TeamHeroesRepository _thRepo;

        public TeamHeroesService()
        {
            _thRepo = new TeamHeroesRepository();
        }

        public IEnumerable<DAOM.Hero> GetByTeamId(int teamdId)
        {
            return _thRepo.GetByTeamId(teamdId).toDAO();
        }

        public int AddHero(int teamId, int heroId)
        {
            return _thRepo.Insert(new DTOM.Team_Hero { TeamId = teamId, HeroId = heroId });
        }
    }
}
