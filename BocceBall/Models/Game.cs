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

        public int HomeTeamID { get; set; }
        [NotMapped]
        public Team HomeTeam
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int AwayTeamID { get; set; }
        [NotMapped]
        public Team AwayTeam
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }

        [NotMapped]
        public Team Winner
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        [NotMapped]
        public bool Happened
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
