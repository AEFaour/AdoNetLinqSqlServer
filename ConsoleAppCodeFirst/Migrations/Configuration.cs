namespace ConsoleAppCodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ConsoleAppCodeFirst.Model.EFVideotheque>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ConsoleAppCodeFirst.Model.EFVideotheque";
        }

        protected override void Seed(ConsoleAppCodeFirst.Model.EFVideotheque context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
