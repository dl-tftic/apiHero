using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAO.Repository;
using DAO.Models;
using DTO.Models;
using apiHero.Mappers;

namespace apiHero.Services
{
    public class UserService
    {
        private UserRepository _repo = new UserRepository();

        public int Insert(DAO.Models.User user)
        {
            return _repo.Insert(user.toDTO());
            //return _repo.Insert(new DTO.Models.User()
            //    {
            //        Id = user.Id,
            //        FirstName = user.FirstName,
            //        LastName = user.LastName,
            //        Pseudo = user.Pseudo,
            //        Password = user.Pwd
            //    }
            //);
            
        }

        public DAO.Models.User Get(int id)
        {
            DTO.Models.User dto = _repo.Get(id);
            DAO.Models.User dao = new DAO.Models.User(dto);
            return dao;
        }
    }
}
