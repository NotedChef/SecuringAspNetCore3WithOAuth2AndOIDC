// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using System.Collections.Generic;

namespace Marvin.IDP
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),  // ensures that the subjectid can be requested by the relying application
                new IdentityResources.Profile(),
                new IdentityResources.Address(),
                new IdentityResource("roles", "Your role(s)", new List<string>() { "role" }),
                new IdentityResource("country", "Country of residence", new List<string>() { "country" }),
                new IdentityResource("subscriptionlevel", "Level of subcription", new List<string>() { "subscriptionlevel" })
            };

        public static IEnumerable<ApiScope> ApiScopes =>
             new ApiScope[]
             {
                new ApiScope(
                    "imagegalleryapi",
                    "Image Gallery API scope")
             };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[] {
                new ApiResource(
                    "imagegalleryapi",
                    "Image Gallery API",
                    new[] { "role" })
                    {
                        Scopes = { "imagegalleryapi"},
                        ApiSecrets = { new Secret("apisecret".Sha256())}
                    }
                };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                //new Client
                //{
                //    ClientId = "imagegalleryapi",
                //    ClientSecrets = { new Secret("secret".Sha256())},
                //    AllowedGrantTypes = GrantTypes.ClientCredentials,
                //    AllowedScopes = {"imagegalleryapi"}
                //},
                new Client
                {
                    ClientName = "Image Gallery",
                    ClientId = "imagegalleryclient",
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string>()
                    {
                        "https://localhost:44389/signin-oidc"
                    },
                    RequireConsent = true,
                    RequirePkce = true,
                    PostLogoutRedirectUris = new List<string>() { "https://localhost:44389/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Address,
                        "roles",
                        "imagegalleryapi",
                        "country",
                        "subscriptionlevel"
                    },
                    ClientSecrets = { new Secret("secret".Sha256()) }
                }
            };
    }
}