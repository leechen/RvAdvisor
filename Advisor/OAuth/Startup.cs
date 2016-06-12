﻿using System;
using System.Security.Cryptography.X509Certificates;
using IdentityServer3.Core.Configuration;
using Microsoft.Owin;
using Owin;
using System.Configuration;
using Advisor.OAuth.Configration;

[assembly: OwinStartup(typeof(Advisor.OAuth.Startup))]

namespace Advisor.OAuth
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            var certificate = Convert.FromBase64String(ConfigurationManager.AppSettings["SigningCertificate"]);
            var factory = new IdentityServerServiceFactory()
                .UseInMemoryUsers(Users.GetUsers())
                .UseInMemoryScopes(Scopes.GetScopes())
                .UseInMemoryClients(Clients.GetClients());

            var options = new IdentityServerOptions
            {
                SigningCertificate = new X509Certificate2(certificate, ConfigurationManager.AppSettings["SigningCertificatePassword"]),
                RequireSsl = false,   // TEST ONLY
                Factory = factory,
            };

            app.UseIdentityServer(options);
        }
    }
}
