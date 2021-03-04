using MIS4200_Team8.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

    }
}