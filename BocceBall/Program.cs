using BocceBall.Contexts;
using BocceBall.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BocceBall
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Bocce Ball Database Manager!");

            //InsertTestData(); // NOTE: Uncomment if you want to add additional junk data, I only ran it once for my testing

            var db = new BocceBallDb();

            Console.WriteLine("Win/Lose record");
            foreach (var team in db.Teams)
            {
                Console.WriteLine($"{team} -- {team.Wins}/{team.Losses}");
            }

            Console.WriteLine("Player list");
            foreach (var player in db.Players.Include(p => p.Team))
            {
                Console.WriteLine($"{player} of the {player.Team}");
            }

            Console.WriteLine("Upcoming games");
            foreach 
                (var upcomingGame 
                in db.Games
                    .ToList(/* Force eval */)
                    .Where(g => !g.Happened))
            {
                Console.WriteLine(upcomingGame);
            }

            Console.WriteLine("Past games");
            foreach 
                (var pastGame 
                in db.Games
                    .ToList(/* Force eval */)
                    .Where(g => g.Happened))
            {
                Console.WriteLine(pastGame);
            }

            //ReadLineIfDebug(); // NOTE: I have to run the program from the command line to see the output after running my database migration
        }

        static void InsertTestData()
        {
            var db = new BocceBallDb();
            var numberOfTeams = 4;

            void clearTable(DbSet table)
            {
                // TODO: How do you clear a table with EF
            }
            foreach (var table in new DbSet[] { db.Games, db.Players, db.Teams }) { clearTable(table); }

            var rnd = new Random();
            T randomElement<T>(IEnumerable<T> bag)
            {
                return bag.OrderBy(e => rnd.Next()).First();
            }

            var mascots = new[]
            {
                "Bats",
                "Farts",
                "Ghosts",
                "Apples",
                "Algebra",
                "Brushes",
                "Rainbows",
                "Sleepers",
            };
            var colors = new[]
            {
                "Black",
                "Blue",
                "Green",
                "Yellow",
                "Orange",
                "Red",
                "Purple",
                "White",
            };
            Team randomTeam() // TODO: @permutation Switch to a combinations type approach
            {
                return new Team
                {
                    Mascot = randomElement(mascots),
                    Color = randomElement(colors),
                };
            }
            db.Teams.AddRange(Enumerable.Range(0, numberOfTeams).Select(i => randomTeam())); // TODO: @initializelist Is there a better way to initial a list like this?
            db.SaveChanges();

            var chars = Enumerable.Range('A', 26).Select(i => (char)i);
            Player randomPlayer() // TODO: @permutation
            {
                return new Player
                {
                    TeamID =  randomElement(db.Teams.Select(t => t.ID)), //rnd.Next(db.Teams.Count())
                    FullName = String.Join("", Enumerable.Range(0, rnd.Next(5, 15)).Select(i => randomElement(chars))),
                    Nickname = String.Join("", Enumerable.Range(0, rnd.Next(3, 6)).Select(i => randomElement(chars))),
                    Number = rnd.Next(0, 100),
                    ThrowingArm = randomElement(new[] { "left", "right" }),
                };
            }
            db.Players.AddRange(Enumerable.Range(0, numberOfTeams * 6).Select(i => randomPlayer())); // TODO:  @initializelist
            db.SaveChanges();

            Game randomGame()
            {
                Stack<int> teamIDs = new Stack<int>(db.Teams.Select(t => t.ID).ToList(/* Force eval */).OrderBy(id => rnd.Next()));
                return new Game
                {
                    HomeTeamID = teamIDs.Pop(),
                    AwayTeamID = teamIDs.Pop(),
                    HomeScore = rnd.Next(0, 100),
                    AwayScore = rnd.Next(0, 100),
                    Date = DateTime.Today.AddDays(rnd.Next(-7, 7)),
                };
            }
            db.Games.AddRange(Enumerable.Range(0, numberOfTeams * 6).Select(i => randomGame())); // TODO:  @initializelist
            db.SaveChanges();
        }

        [Conditional("DEBUG")]
        static void ReadLineIfDebug()
        {
            Console.ReadLine();
        }
    }
}
