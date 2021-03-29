namespace DotnetAPI.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DotnetAPI.Data.DotnetAPIDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "DotnetAPI.Data.DotnetAPIDbContext";
        }

        protected override void Seed(DotnetAPI.Data.DotnetAPIDbContext context)
        {
            
        }
    }
}
