using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
                throw new NotImplementedException();
            }
        }

        [NotMapped]
        public int Losses
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
