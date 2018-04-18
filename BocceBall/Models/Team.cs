using BocceBall.Contexts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BocceBall.Models
{
    class Team
    {
        public int ID { get; set; }

        public string Mascot { get; set; }
        public string Color { get; set; }

        [NotMapped]
        public int Wins
        {
            get
            {
                return new BocceBallDb()
                    .Games
                    .Include(g => g.HomeTeam)
                    .Include(g => g.AwayTeam)
                    .ToList(/* Force eval */)
                    .Count(g => g.Winner.ID == this.ID);
            }
        }

        [NotMapped]
        public int Losses
        {
            get
            {
                return new BocceBallDb()
                    .Games
                    .Include(g => g.HomeTeam)
                    .Include(g => g.AwayTeam)
                    .ToList(/* Force eval */)
                    .Count(g => g.Loser.ID == this.ID);
            }
        }

        public override string ToString()
        {
            return $"{this.Color} {this.Mascot}";
        }
    }
}
