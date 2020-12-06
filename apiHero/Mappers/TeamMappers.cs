using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAO.Repository;

namespace apiHero.Mappers
{
    public static class TeamMappers
    {
        public static DAO.Models.Team toDAO(this DTO.Models.Team dto)
        {
            DAO.Models.Team dao = new DAO.Models.Team();
            dao.Id = dto.Id;
            dao.Name = dto.Name;
            dao.UserId = dto.UserId;
            return dao;
        }

        public static DTO.Models.Team toDTO(this DAO.Models.Team dao)
        {
            DTO.Models.Team dto = new DTO.Models.Team();
            dto.Id = dao.Id;
            dto.Name = dao.Name;
            dto.UserId = dao.UserId;
            return dto;
        }

        private static DAO.Models.Team FillHeroes(this DAO.Models.Team dao)
        {
            TeamHeroesRepository _thRepo = new TeamHeroesRepository();
            dao.Heroes = _thRepo.GetByTeamId(dao.Id).toDAO().ToArray();
            return dao;
        }
    }
}
