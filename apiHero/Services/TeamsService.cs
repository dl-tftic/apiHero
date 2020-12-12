using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAO.Repository;
using DAOM = DAO.Models;
using DTO.Models;
using apiHero.Mappers;

namespace apiHero.Services
{
    public class TeamsService
    {
        private TeamRepository _repo;

        public TeamsService()
        {
            _repo = new TeamRepository();
        }

        public int Insert(DAO.Models.Team team)
        {
            return _repo.Insert(team.toDTO());
        }

        public int AddHero(int teamId, int heroId)
        {
            TeamHeroesService ths = new TeamHeroesService();
            return ths.AddHero(teamId, heroId);
        }

        public IEnumerable<DAO.Models.Team> GetByUserId(int userId)
        {
            //List<DAO.Models.Team> daos = new List<DAO.Models.Team>();
            TeamHeroesService ths = new TeamHeroesService();

            IEnumerable<DTO.Models.Team> dtos = _repo.GetByUserId(userId);
            foreach(DTO.Models.Team dto in dtos)
            {
                DAO.Models.Team t = dto.toDAO();
                t.Heroes = ths.GetByTeamId(t.Id).ToArray();
                yield return t;
                //daos.Add(dto.toDAO());
            }

            //return daos;
        }

        public IEnumerable<DAO.Models.Team> GetAll()
        {
            TeamHeroesService ths = new TeamHeroesService();

            IEnumerable<DTO.Models.Team> dtos = _repo.GetAll();
            foreach (DTO.Models.Team dto in dtos)
            {
                DAO.Models.Team t = dto.toDAO();
                t.Heroes = ths.GetByTeamId(t.Id).ToArray();
                yield return t;
            }
        }

        public DAO.Models.Team GetById(int id)
        {
            TeamHeroesService ths = new TeamHeroesService();
            DAO.Models.Team dao = _repo.GetById(id).toDAO();
            dao.Heroes = ths.GetByTeamId(dao.Id).ToArray();
            return dao;
        }
 
    }
}
