namespace DAL.Migrations
{
    using Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.RateContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DAL.RateContext context)
        {
            var createdDate = DateTime.Now;
            context.Currency.AddOrUpdate(x => x.Id,


                new Currency {  Id = 1, CurrenyCode = "USD", CurrencyName = "Amerikan Dolarý", Unit = 1 }
                            );
        }
    }
}
