using BocceBall.Contexts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BocceBall.Models
{
    class Game
    {
        public int ID { get; set; }

        public int? HomeTeamID { get; set; }
        //[ForeignKey("HomeTeamID")]
        public IQueryable<Team> HomeTeams { get; set; }

        public int? AwayTeamID { get; set; }
        //[ForeignKey("AwayTeamID")]
        public IQueryable<Team> AwayTeams { get; set; }

        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }

        [NotMapped]
        public Team Winner
        {
            get
            {
                return this.HomeScore >= this.AwayScore 
                    ? this.HomeTeams.First(t => t.ID == this.HomeTeamID) 
                    : this.AwayTeams.First(t => t.ID == this.HomeTeamID);
            }
        }

        [NotMapped]
        public Team Loser
        {
            get
            {
                return this.Winner.ID == this.HomeTeamID 
                    ? this.AwayTeams.First(t => t.ID == this.AwayTeamID)
                    : this.HomeTeams.First(t => t.ID == this.HomeTeamID);
            }
        }

        [NotMapped]
        public bool Happened
        {
            get
            {
                // I say [happening] is closer to [happened] than it would be to [hasn't happened yet]
                return this.Date <= DateTime.Today;
            }
        }

        public override string ToString()
        {
            return $"Game: H:{this.HomeTeams} vs A:{this.AwayTeams} -- Score: H:{this.HomeScore} - A:{this.AwayScore} -- Date:{this.Date}";
        }
    }
}
