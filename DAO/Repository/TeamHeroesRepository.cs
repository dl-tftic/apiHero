using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.Models;
using Tools.Connection;

namespace DAO.Repository
{
    public class TeamHeroesRepository : RepositoryBase
    {
        public IEnumerable<Team_Hero> Get(int id)
        {
            Command cmd = new Command("SP_GetTeamById", true);
            cmd.AddParameter("id", id);
            Connection conn = new Connection(this.connectionString);
            return conn.ExecuteReader<Team_Hero>(cmd, (reader) =>
                                                new Team_Hero
                                                {
                                                    Id = (int)reader["Id"],
                                                    HeroId = (int)reader["HeroId"],
                                                    TeamId = (int)reader["TeamId"]
                                                });
        }

        public IEnumerable<int> GetByTeamId(int teamId)
        {
            Command cmd = new Command("SP_GetHeroesByTeamId", true);
            cmd.AddParameter("teamId", teamId);
            Connection conn = new Connection(this.connectionString);
            return conn.ExecuteReader<int>(cmd, (reader) =>(int)reader["HeroId"]);
        }

        public int Insert(Team_Hero teamHero)
        {
            Command cmd = new Command("SP_AddHeroInTeam", true);
            cmd.AddParameter("HeroId", teamHero.HeroId);
            cmd.AddParameter("TeamId", teamHero.TeamId);
            Connection conn = new Connection(this.connectionString);
            return (int)(decimal)(conn.ExecuteScalar(cmd));
        }
    }
}
