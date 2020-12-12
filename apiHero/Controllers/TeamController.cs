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

        /// <summary>
        /// GetByUserId allow to retrieve all Teams by an user id
        /// </summary>
        /// <param name="userId">Id of an user</param>
        /// <returns>Ienumerable of Team</returns>
        [HttpGet("{userId}")]
        public IEnumerable<DAO.Models.Team> GetByUserId(int userId)
        {   
            return this._teamService.GetByUserId(userId);
        }

        /// <summary>
        /// GetById allow to retrieve a team by it's Id
        /// </summary>
        /// <param name="id">Id of Team</param>
        /// <returns>A Team object</returns>
        [HttpGet("{id}")]
        public DAO.Models.Team GetById(int id)
        {
            return this._teamService.GetById(id);
        }

        /// <summary>
        /// GetAll function allow to retrieve all Teams independently of the id or user id
        /// </summary>
        /// <returns>Ienumerable of Team</returns>
        [HttpGet()]
        public IEnumerable<DAO.Models.Team> GetAll()
        {
            return this._teamService.GetAll();
        }

        /// <summary>
        /// Allow to add a Team ind DB
        /// </summary>
        /// <param name="team">A Team object</param>
        /// <returns>Id of the insertion in DB</returns>
        [HttpPost]
        public int Create([FromBody] Team team)
        {
            /*
             * How to post via postman 
             * https://www.c-sharpcorner.com/article/how-to-use-postman-with-asp-net-core-web-api-testing/
            */
            return this._teamService.Insert(team);
        }

        /// <summary>
        /// Allow to add a Hero to a Team
        /// </summary>
        /// <param name="body">
        ///     a JSON structured like the following : 
        ///     {
        ///     "teamId":  "1",
        ///     "heroId": "715"
        ///     }
        /// </param>
        /// <returns>Id of the insertion in DB</returns>
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
