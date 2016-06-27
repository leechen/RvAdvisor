using Advisor.Api.Autofac.Modules;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Owin;
using Advisor.Api.Filters;

[assembly: OwinStartup(typeof(Advisor.Api.App_Start.StartUp))]
namespace Advisor.Api.App_Start
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            // http://stackoverflow.com/questions/28473320/ninject-causes-notimplementedexception-at-httpcontextbase-get-response
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Filters.Add(new LogActionAttribute());

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule<AdvisorModule>();

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "http://localhost:4959"
            });

            app.UseWebApi(config);

            config.EnsureInitialized();
            GlobalConfiguration.Configuration.EnsureInitialized();
        }
    }
}