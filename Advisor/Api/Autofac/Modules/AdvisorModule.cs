using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Advisor.DataAccess;
using Advisor.Sdk;
using Autofac;

namespace Advisor.Api.Autofac.Modules
{
    public class AdvisorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(
                x => new Func<IDbConnection>(
                () => new SqlConnection(ConfigurationManager.ConnectionStrings["Advisor"].ConnectionString)));

            builder.RegisterType<AdvisorDbContext>().As<IAdvisorDataContext>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        }
    }
}