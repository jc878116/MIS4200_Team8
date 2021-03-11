namespace MIS4200_Team8.Migrations.CentricContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MIS4200_Team8.DAL.CentricContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations\CentricContext";
            ContextKey = "MIS4200_Team8.DAL.CentricContext";
        }

        protected override void Seed(MIS4200_Team8.DAL.CentricContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
