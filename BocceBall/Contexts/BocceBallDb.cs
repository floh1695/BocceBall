using BocceBall.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BocceBall.Contexts
{
    class BocceBallDb : DbContext
    {
        public BocceBallDb()
            : base("BocceBall")
        { }

        DbSet<Player> Players;
        DbSet<Team> Teams;
        DbSet<Game> Games;
    }
}
