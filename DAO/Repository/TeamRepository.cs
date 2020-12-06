using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.Models;
using Tools.Connection;

namespace DAO.Repository
{
    public class TeamRepository : RepositoryBase
    {
        public IEnumerable<Team> GetByUserId(int userId)
        {
            Command cmd = new Command("SP_GetTeamByUserId", true);
            cmd.AddParameter("userId", userId);
            Connection conn = new Connection(this.connectionString);
            IEnumerable<Team> teams = conn.ExecuteReader<Team>(cmd, (reader) =>
                                                new Team
                                                {
                                                    Id = (int)reader["Id"],
                                                    Name = (string)reader["Nom"],
                                                    UserId = (int)reader["userId"]
                                                });
            return teams;
        }

        public Team GetById(int id)
        {
            Command cmd = new Command("SP_GetTeamById", true);
            cmd.AddParameter("id", id);
            Connection conn = new Connection(this.connectionString);
            Team team = conn.ExecuteReader<Team>(cmd, (reader) =>
                                                new Team
                                                {
                                                    Id = (int)reader["Id"],
                                                    Name = (string)reader["Nom"],
                                                    UserId = (int)reader["userId"]
                                                }).Single();
            return team;
        }

        public int Insert(Team team)
        {
            /*
	            @name nvarchar(16),
	            @userId int
            */
            /*
                return for a stored procedure must be different than ouput
                https://stackoverflow.com/questions/18529956/command-executescalar-always-return-null-while-stored-procedure-in-management-st
                https://stackoverflow.com/questions/14246744/executescalar-vs-executenonquery-when-returning-an-identity-value
             */

            Command cmd = new Command("SP_AddTeam", true);
            cmd.AddParameter("name", team.Name);
            cmd.AddParameter("userId", team.UserId);
            Connection conn = new Connection(this.connectionString);
            return (int)(decimal)(conn.ExecuteScalar(cmd));
        }

    }
}
