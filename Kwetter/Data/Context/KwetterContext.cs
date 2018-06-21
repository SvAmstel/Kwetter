using Kwetter.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Kwetter.Data.Context
{
    public class KwetterContext : DbContext
    {
        public KwetterContext() : base()
        {

        }
        public DbSet<Gebruiker> gebruikers { get; set; }
        public DbSet<Tweet> tweets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gebruiker>().HasMany(a => a.followers).WithMany().Map(t => t.MapLeftKey("GebruikerId").MapRightKey("FollowerId").ToTable("Followers"));
        }
    }
}
