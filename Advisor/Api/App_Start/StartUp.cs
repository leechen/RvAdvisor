using Advisor.Api.Autofac.Modules;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using IdentityServer3.AccessTokenValidation;
using Owin;

namespace Advisor.Api.App_Start
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            var config = GlobalConfiguration.Configuration;

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
        }
    }
}