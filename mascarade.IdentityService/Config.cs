using Duende.IdentityServer.Models;

namespace mascarade.IdentityService;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("mascaradeApp", "test_scope"),
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
            {
                ClientId = "postman",
                ClientName = "PostmanApp",
                AllowedScopes = { "openid", "profile", "mascaradeApp" },
                RedirectUris = { "http://getpostman.com/oauth2/callback" },
                ClientSecrets = { new Secret("NotASecret".Sha256()) },
                AllowedGrantTypes = { GrantType.ResourceOwnerPassword }
            },
            new Client
            {
                ClientId = "nextApp",
                ClientName = "nextApp",
                ClientSecrets = {new Secret("secret".Sha256())},
                AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                RequirePkce = false,
                RedirectUris = {"http://localhost:3000/api/auth/callback/id-server"},
                AllowedScopes = {"openid","profile","mascaradeApp"},
                AccessTokenLifetime = 3600*24*30
            }
        };
}