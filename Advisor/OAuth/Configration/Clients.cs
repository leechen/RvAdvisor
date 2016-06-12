using System.Collections.Generic;
using IdentityServer3.Core;
using IdentityServer3.Core.Models;

namespace Advisor.OAuth.Configration
{
    public class Clients
    {
        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "Advisor",
                    ClientName = "Advisor",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    Flow = Flows.ResourceOwner,
                    AllowedScopes  = new List<string> { Constants.StandardScopes.OpenId },
                    Enabled = true
                },

                new Client
                {
                    ClientId = "Advisor_implicit",
                    ClientName = "Advisor",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    Flow = Flows.Implicit,
                    RedirectUris = new List<string>
                    {
                        "http://localhost:28037/private",
                        "http://localhost:28037",
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost:28037",
                    },
                    AllowedScopes  = new List<string> { Constants.StandardScopes.OpenId, Constants.StandardScopes.Profile },
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Jwt,
                    IdentityTokenLifetime = 3600,
                    AccessTokenLifetime = 3600
                }
            };
        }
    }
}