// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using IdentityModel;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using Duende.IdentityServer;
using Duende.IdentityServer.Test;

namespace IdentityServerHost.Quickstart.UI
{
    public class TestUsers
    {
        public static List<TestUser> Users
        {
            get
            {
                var address = new
                {
                    street_address = "One Hacker Way",
                    locality = "Heidelberg",
                    postal_code = 69118,
                    country = "Germany"
                };

                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "d860efca-22d9-47fd-8249-791ba61b07c7",
                        Username = "Frank",
                        Password = "password",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Frank Underwood"),
                            new Claim(JwtClaimTypes.GivenName, "Frank"),
                            new Claim(JwtClaimTypes.FamilyName, "Underwood"),
                            //new Claim(JwtClaimTypes.Email, "frank@whs.com"),
                            //new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            //new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json),
                            new Claim(JwtClaimTypes.Role, "FreeUser"),
                            new Claim("country", "au"),
                            new Claim("subscriptionlevel", "FreeUser")
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "b7539694-97e7-4dfe-84da-b4256e1ff5c7",
                        Username = "Claire",
                        Password = "password",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Claire Underwood"),
                            new Claim(JwtClaimTypes.GivenName, "Claire"),
                            new Claim(JwtClaimTypes.FamilyName, "Underwood"),
                            //new Claim(JwtClaimTypes.Email, "claire@whs.com"),
                            //new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            //new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json),
                            new Claim(JwtClaimTypes.Role, "PayingUser"),
                            new Claim("country", "be"),
                            new Claim("subscriptionlevel", "PayingUser")
                        }
                    }
                };
            }
        }
    }
}