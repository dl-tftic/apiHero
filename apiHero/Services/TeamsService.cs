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
    /// <summary>
    /// Team Service
    /// </summary>
    public class TeamsService
    {
        private TeamRepository _repo;

        /// <summary>
        /// Constructor
        /// </summary>
        public TeamsService()
        {
            _repo = new TeamRepository();
        }

        /// <summary>
        /// The service use the repo to add a team in DB
        /// </summary>
        /// <param name="team">a Team object</param>
        /// <returns>Id of the insertion in DB</returns>
        public int Insert(DAO.Models.Team team)
        {
            return _repo.Insert(team.toDTO());
        }

        /// <summary>
        /// The service use the repo to add a Hero in a Team
        /// </summary>
        /// <param name="teamId">Id of the team</param>
        /// <param name="heroId">Id of the Hero</param>
        /// <returns>Id of the insertion in DB</returns>
        public int AddHero(int teamId, int heroId)
        {
            TeamHeroesService ths = new TeamHeroesService();
            return ths.AddHero(teamId, heroId);
        }

        /// <summary>
        /// To get TEams by user ID
        /// </summary>
        /// <param name="userId">ID of the user</param>
        /// <returns>All Team object retated to user ID</returns>
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

        /// <summary>
        /// To get all Teams
        /// </summary>
        /// <returns>All teams in DB</returns>
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

        /// <summary>
        /// To get a Team by it's ID
        /// </summary>
        /// <param name="id">Id of the Team</param>
        /// <returns>a Team object</returns>
        public DAO.Models.Team GetById(int id)
        {
            TeamHeroesService ths = new TeamHeroesService();
            DAO.Models.Team dao = _repo.GetById(id).toDAO();
            dao.Heroes = ths.GetByTeamId(dao.Id).ToArray();
            return dao;
        }
 
    }
}
