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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                //.HasOptional<Team>(g => g.HomeTeams)
                .WithMany()
                .WillCascadeOnDelete(false);
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}
