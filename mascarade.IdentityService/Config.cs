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
            }
        };
}