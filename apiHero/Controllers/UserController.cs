using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using apiHero.Services;
using Newtonsoft.Json;


namespace apiHero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;

        public UserController()
        {
            
            _userService = new UserService();
        }

        /// <summary>
        /// Allow to add a user in DB 
        /// </summary>
        /// <param name="value">A user object</param>
        /// <returns>Id of the insertion in DB</returns>
        [HttpPost]
        public int Register([FromBody] DAO.Models.User value)
        {
            return _userService.Insert(value);
        }
        
        /// <summary>
        /// Allow to get details of a user
        /// </summary>
        /// <param name="id">Id of the user</param>
        /// <returns>A user object</returns>
        [HttpGet("{id}")]
        public DAO.Models.User Details(int id)
        {
            
             return this._userService.Get(id);
        }

        [HttpGet]
        public string Get()
        {
            return "Welcome";
        }

    }
}
