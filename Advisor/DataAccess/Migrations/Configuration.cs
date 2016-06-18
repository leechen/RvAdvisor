namespace Advisor.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using ObjectModel;

    internal sealed class Configuration : DbMigrationsConfiguration<AdvisorDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Advisor.DataAccess.AdvisorDbContext";
        }

        protected override void Seed(AdvisorDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.RvParks.AddOrUpdate(
              ObjectModelHelper.NewRvPark(
                  "Trailer Inns RV Park of Bellevue/Seattle",
                  "Trailer Inns of Bellevue, WA 98006"),
              ObjectModelHelper.NewRvPark(
                  "Issaquah Village RV Par",
                  "If you are looking for first-class service, you have come to the right place! "
                                + "We put our customers first.Come visit to see what we are all about and have a relaxing stay. "
                                + "We are here to serve you and answer any questions you may have")
                                );

        }
    }
}
