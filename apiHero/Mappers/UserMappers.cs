using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiHero.Mappers
{
    public static class UserMappers
    {
        public static DAO.Models.User toDAO(this DTO.Models.User dto)
        {
            DAO.Models.User dao = new DAO.Models.User(dto);
            return dao;
        }

        public static DTO.Models.User toDTO(this DAO.Models.User dao)
        {
            DTO.Models.User dto = new DTO.Models.User();
            dto.Id = dao.Id;
            dto.LastName = dao.LastName;
            dto.FirstName = dao.FirstName;
            dto.Pseudo = dao.Pseudo;
            dto.Password = dao.Pwd;
            return dto;
        }
    }
}
