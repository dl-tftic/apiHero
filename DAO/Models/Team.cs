﻿namespace DAO.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public Hero[]? Heroes { get; set; }
    }
}