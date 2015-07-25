using System.Data.Entity.Migrations;

namespace LandPropertiesApp.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<LandPropertiesApp.EntityFramework.LandPropertiesAppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "LandPropertiesApp";
        }

        protected override void Seed(LandPropertiesApp.EntityFramework.LandPropertiesAppDbContext context)
        {
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
        }
    }
}
