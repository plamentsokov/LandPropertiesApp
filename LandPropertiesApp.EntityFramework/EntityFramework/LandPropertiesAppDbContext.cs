using Abp.EntityFramework;
using LandPropertiesApp.Entities;
using System.Data.Entity;

namespace LandPropertiesApp.EntityFramework
{
    public class LandPropertiesAppDbContext : AbpDbContext
    {
        //TODO: Define an IDbSet for each Entity...

        //Example:
        //public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<Owner> Owners { get; set; }

        public virtual IDbSet<LandProperty> LandProperties { get; set; }

        public virtual IDbSet<Mortgage> Mortgages { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public LandPropertiesAppDbContext()
            : base("LandPropertiesSystemConnection")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in LandPropertiesAppDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of LandPropertiesAppDbContext since ABP automatically handles it.
         */
        public LandPropertiesAppDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LandProperty>()
                        .HasOptional(a => a.Mortgage)
                        .WithRequired(x => x.LandProperty);

            modelBuilder.Entity<Mortgage>()
                        .HasRequired(b => b.LandProperty)
                        .WithOptional(a => a.Mortgage);
        }
    }
}
