using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Models
{
    public class User
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Pseudo { get; set; }
        public string Pwd { get; set; }
        public bool Connecte { get; set; }
        public List<Team> Teams { get; set; }

        public User()
        {

        }

        public User(DTO.Models.User user)
        {
            if (user is null) { }
            else
            {
                this.Id = user.Id;
                this.LastName = user.LastName;
                this.FirstName = user.FirstName;
                this.Pseudo = user.Pseudo;
                this.Pwd = user.Password;
                this.Teams = new List<Team>();
            }
        }
    }
}
