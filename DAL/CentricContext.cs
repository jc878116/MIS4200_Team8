using MIS4200_Team8.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MIS4200_Team8.DAL
{
    public class CentricContext : DbContext
    {
        public CentricContext() : base("name=DefaultConnection")
        {     
            
        }

        public DbSet<Employees> employees { get; set; }

        public DbSet<Profile> profile { get; set; }

        public DbSet<Recognition> recognition { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();  // note: this is all one line!
        }

    }
}