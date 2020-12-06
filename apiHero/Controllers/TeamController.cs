using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiHero.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DAO.Repository;
using apiHero.Mappers;
using DAO.Models;

namespace apiHero.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private TeamsService _teamService;

        public TeamController()
        {
            _teamService = new TeamsService();
        }

        [HttpGet("{userId}")]
        public string GetByUserId(int userId)
        {   
            IEnumerable<DAO.Models.Team> dao = this._teamService.GetByUserId(userId);
            return JsonConvert.SerializeObject(dao);
        }

        [HttpGet("{id}")]
        public DAO.Models.Team GetById(int id)
        {
            // DAO.Models.Team
            return this._teamService.GetById(id);
            //return this._teamRepository.GetById(id).toDAO();
        }

        [HttpPost]
        public int Create([FromBody] Team team)
        {
            /*
             * How to post via postman 
             * https://www.c-sharpcorner.com/article/how-to-use-postman-with-asp-net-core-web-api-testing/
            */
            //return this._teamService.Insert(new Team { Name = name });
            return this._teamService.Insert(team);
        }

        [HttpPost]
        public int AddHero([FromBody] JObject body)
        {
            /*
             to use JObject
            https://stackoverflow.com/questions/55787018/net-core-3-preview-4-addnewtonsoftjson-is-not-defined
            */
            return this._teamService.AddHero(Convert.ToInt32(body["teamId"].ToString()), Convert.ToInt32(body["heroId"].ToString()));
        }

    }
}
