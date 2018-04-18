using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BocceBall.Models
{
    class Player
    {
        public int ID { get; set; }

        public int? TeamID { get; set; }
        public Team Team { get; set; }

        public string FullName { get; set; }
        public string Nickname { get; set; }
        public int Number { get; set; }
        public string ThrowingArm { get; set; }

        public override string ToString()
        {
            return $"{this.FullName} ({this.Nickname})";
        }
    }
}
