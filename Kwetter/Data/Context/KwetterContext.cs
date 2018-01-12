using Kwetter.Data.Models;
using System;
using System.Collections.Generic;
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
            base.OnModelCreating(modelBuilder);
        }
    }
}
