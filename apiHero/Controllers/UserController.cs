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

        [HttpPost]
        public int Register([FromBody] DAO.Models.User value)
        {
            return _userService.Insert(value);
        }
        
        [HttpGet("{id}")]
        public string Details(int id)
        {
            
            DAO.Models.User dao = this._userService.Get(id);
            return JsonConvert.SerializeObject(dao);
        }

        [HttpGet]
        public string Get()
        {
            return "Welcome";
        }

    }
}
