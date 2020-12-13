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
    /// <summary>
    /// User controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;

        /// <summary>
        /// Constructor
        /// </summary>
        public UserController()
        {
            
            _userService = new UserService();
        }

        /// <summary>
        /// Allow to add a user in DB 
        /// </summary>
        /// <param name="user">A user object</param>
        /// <returns>Id of the insertion in DB</returns>
        [HttpPost]
        public int Register([FromBody] DAO.Models.User user)
        {
            return _userService.Insert(user);
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

        /// <summary>
        /// Welcome message entry (for testing)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Get()
        {
            return "Welcome";
        }

    }
}
