using System;
using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer3.Core.Services.InMemory;
using IdentityServer3.Core;

namespace Advisor.OAuth.Configration
{
    public class Users
    {
        public static List<InMemoryUser> GetUsers()
        {
            return new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Subject = "leeh.chen@gmail.com",
                    Username = "leeh.chen@gmail.com",
                    Password = "password",
                    Claims = new []
                    {
                        new Claim(Constants.ClaimTypes.Name, "Lee Chen")
                    }
                }
            };
        }
    }
}