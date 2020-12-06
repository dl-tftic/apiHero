using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.Models;
using Tools.Connection;

namespace DAO.Repository
{
    public class UserRepository : RepositoryBase
    {
        public User Get(int id)
        {
            Command cmd = new Command("SP_GetUserById", true);
            cmd.AddParameter("id", id);
            Connection conn = new Connection(this.connectionString);
            return conn.ExecuteReader<User>(cmd, (reader) => 
                                                new User 
                                                 { 
                                                    Id = (int)reader["Id"],
                                                    FirstName = (string)reader["FirstName"],
                                                    LastName = (string)reader["LastName"],
                                                    Pseudo = (string)reader["Pseudo"],
                                                    Password = (string)reader["Password"]
                                                }).Single();
        }

        public int Insert(User user)
        {
            /*
                    @FirstName NvarCHAR(20),
	                @LastName NvarCHAR(20),
	                @Pseudo Nvarchar(20),
	                @Password nvarchar(16) 
            */
            
            Command cmd = new Command("SP_AddUser", true);
            cmd.AddParameter("FirstName", user.FirstName);
            cmd.AddParameter("LastName", user.LastName);
            cmd.AddParameter("Pseudo", user.Pseudo);
            cmd.AddParameter("Password", user.Password);
            Connection conn = new Connection(this.connectionString);
            return (int)(conn.ExecuteScalar(cmd));
        }

        public int CheckPassword(string pseudo, string password)
        {
            Command cmd = new Command("SP_CheckPasswordUser", true);
            cmd.AddParameter("pd", pseudo);
            cmd.AddParameter("pwd", password);
            Connection conn = new Connection(this.connectionString);
            return (int)(conn.ExecuteScalar(cmd));
        }
    }
}
