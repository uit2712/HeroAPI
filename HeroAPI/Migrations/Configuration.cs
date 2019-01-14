namespace HeroAPI.Migrations
{
    using HeroAPI.DbContextClass;
    using HeroAPI.Enums;
    using HeroAPI.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HeroAPI.DbContextClass.HeroDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HeroDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //SeedDataPowers(context);
            //SeedDataHeroes(context);
            //SeedDataPowerDetails(context);
        }

        private void SeedDataPowers(HeroDbContext context)
        {
            string[] powerNames = Enum.GetNames(typeof(EPower));
            if (powerNames != null && powerNames.Length > 0)
            {
                Power[] powers = new Power[powerNames.Length];
                for(int i = 0; i < powers.Length; i++)
                    powers[i] = new Power(powerNames[i]);

                context.Powers.AddOrUpdate(powers);
            }
        }

        private void SeedDataHeroes(HeroDbContext context)
        {
            string[] heroNames = { "Thor", "Batman", "Hulk", "Doctor Strange", "Superman", "Venom", "Flash", "Spiderman", "Supergirl", "Deadpool" };
            if (heroNames != null && heroNames.Length > 0)
            {
                Hero[] heroes = new Hero[heroNames.Length];
                for (int i = 0; i < heroes.Length; i++)
                    heroes[i] = new Hero(heroNames[i]);

                context.Heroes.AddOrUpdate(heroes);
            }
        }

        private void SeedDataPowerDetails(HeroDbContext context)
        {
            PowerDetail[] powerDetails = new PowerDetail[16];
            powerDetails[0] = new PowerDetail(1, (int)EPower.Thunder);
            powerDetails[1] = new PowerDetail(1, (int)EPower.Strength);
            powerDetails[2] = new PowerDetail(2, (int)EPower.Rich);
            powerDetails[3] = new PowerDetail(2, (int)EPower.Strength);
            powerDetails[4] = new PowerDetail(3, (int)EPower.Strength);
            powerDetails[5] = new PowerDetail(4, (int)EPower.Magic);
            powerDetails[6] = new PowerDetail(5, (int)EPower.Strength);
            powerDetails[7] = new PowerDetail(5, (int)EPower.Speed);
            powerDetails[8] = new PowerDetail(5, (int)EPower.LaserEyes);
            powerDetails[9] = new PowerDetail(6, (int)EPower.Strength);
            powerDetails[10] = new PowerDetail(6, (int)EPower.Speed);
            powerDetails[11] = new PowerDetail(7, (int)EPower.Speed);
            powerDetails[12] = new PowerDetail(8, (int)EPower.Strength);
            powerDetails[13] = new PowerDetail(9, (int)EPower.Strength);
            powerDetails[14] = new PowerDetail(9, (int)EPower.LaserEyes);
            powerDetails[15] = new PowerDetail(10, (int)EPower.Strength);

            context.PowerDetails.AddOrUpdate(powerDetails);
        }
    }
}
