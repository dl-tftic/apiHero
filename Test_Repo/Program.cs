using System;
using DAO.Repository;
using DTO.Models;
using System.Collections.Generic;

namespace Test_Repo
{
    class Program
    {
        static void Main(string[] args)
        {

            #region User
            // ***********************************************************************************************
            Console.WriteLine("User section **********");

            UserRepository ur = new UserRepository();

            Console.WriteLine("Do you want to add a user ? Y/N");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                User user = new User();

                Console.WriteLine("Firstname : ");
                user.FirstName = Console.ReadLine();
                Console.WriteLine("LastName : ");
                user.LastName = Console.ReadLine();
                Console.WriteLine("Pseudo : ");
                user.Pseudo = Console.ReadLine();
                Console.WriteLine("Password : ");
                user.Password = Console.ReadLine();

                try
                {
                    Console.WriteLine("Insertion successul, ID : {0}", ur.Insert(user));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            Console.WriteLine();

            Console.WriteLine("Get all users : ");
            foreach (var item in ur.GetAll())
            {
                Console.WriteLine("User {0} : {1} {2} {3}", item.Id, item.Pseudo, item.FirstName, item.LastName);
            }

            Console.WriteLine("Get user by id, enter an id (only number) : ");
            int idUser = -1;

            if (Int32.TryParse(Console.ReadLine(), out idUser))
            {
                try
                {
                    var item2 = ur.Get(idUser);
                    Console.WriteLine("User {0} : {1} {2} {3}", item2.Id, item2.Pseudo, item2.FirstName, item2.LastName);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("a number was excpected!");
            }
            #endregion

            #region Team
            // ***********************************************************************************************
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Team section **********");

            TeamRepository tr = new TeamRepository();

            Console.WriteLine("Do you want to add a team ? Y/N");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                Team team = new Team();

                Console.WriteLine("Name : ");
                team.Name = Console.ReadLine();
                Console.WriteLine("Userid (only numbers) : ");
                bool validNumber = Int32.TryParse(Console.ReadLine(), out team.UserId);

                if (validNumber)
                {
                    try
                    {
                        Console.WriteLine("Insertion successul, ID : {0}", tr.Insert(team));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    Console.WriteLine("userId is not a number !");
                }

            }

            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine("Get all teams : ");
            foreach (var item in tr.GetAll())
            {
                Console.WriteLine("User {0} : {1} {2} {3}", item.Id, item.Name, item.UserId, item.LeaderId);
            }

            Console.WriteLine("Get team by id, enter an id (only number) : ");
            int idTeamById = -1;

            if (Int32.TryParse(Console.ReadLine(), out idTeamById))
            {
                try
                {
                    Team tById = tr.GetById(idTeamById);
                    Console.WriteLine("User {0} : {1} {2} {3}", tById.Id, tById.Name, tById.UserId, tById.LeaderId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("a number was excpected!");
            }

            Console.WriteLine("Get team by userId, enter an userId (only number) : ");
            int idTeamByUserId = -1;

            if (Int32.TryParse(Console.ReadLine(), out idTeamByUserId))
            {
                try
                {
                    IEnumerable<Team> tByUserId = tr.GetByUserId(idTeamByUserId);
                    foreach (var item in tByUserId)
                    {
                        Console.WriteLine("User {0} : {1} {2} {3}", item.Id, item.Name, item.UserId, item.LeaderId);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("a number was excpected!");
            } 
            #endregion
        }
    }
}
