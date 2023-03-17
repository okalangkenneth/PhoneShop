using Duende.IdentityServer;
using Duende.IdentityServer.Models;

// Define a static class named SD
namespace Phone.Services.Identity
{
	public static class SD
	{
		// Define two constants for user roles
		public const string Admin = "Admin";
		public const string Customer = "Customer";

		// Define a static property that returns a list of predefined identity resources
		public static IEnumerable<IdentityResource> IdentityResources =>
			new List<IdentityResource>
			{
                // Add OpenID resource
                new IdentityResources.OpenId(),
                // Add Email resource
                new IdentityResources.Email(),
                // Add Profile resource
                new IdentityResources.Profile()
			};

		// Define a static property that returns a list of predefined API scopes
		public static IEnumerable<ApiScope> ApiScopes =>
			new List<ApiScope>
			{
                // Add phone scope for Phone Server API
                new ApiScope("phone", "Phone Server"),
                // Add read scope for reading data
                new ApiScope(name:"read", displayName: "Read your data."),
                // Add write scope for writing data
                new ApiScope(name:"write", displayName: "Write your data."),
                // Add delete scope for deleting data
                new ApiScope(name:"delete", displayName: "Delete your data.")
			};

		// Define a static property that returns a list of clients that are allowed to access protected resources
		public static IEnumerable<Client> Clients =>
			new List<Client>
			{
                // Define a client credential client
                new Client()
				{
                    // Set the client ID
                    ClientId = "client",
                    // Set the client secret
                    ClientSecrets= {new Secret("secret".Sha256()) },
                    // Set the allowed grant types to client credentials
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // Set the allowed scopes to read, write, and profile
                    AllowedScopes={"read","write","profile"}
				},
                // Define a web application client
                new Client()
				{
                    // Set the client ID
                    ClientId = "phone",
                    // Set the client secret
                    ClientSecrets= {new Secret("secret".Sha256()) },
                    // Set the allowed grant types to authorization code
                    AllowedGrantTypes = GrantTypes.Code,
                    // Set the redirect URI for the authentication response
                    RedirectUris={ "https://localhost:44361/signin-oidc", },
                    // Set the URI to redirect to after logout
                    PostLogoutRedirectUris={"https://localhost:44361/signout-callback-oidc"},
                    // Set the allowed scopes to OpenID, email, profile, and phone
                    AllowedScopes= new List<string>
					{
						IdentityServerConstants.StandardScopes.OpenId,
						IdentityServerConstants.StandardScopes.Profile,
						IdentityServerConstants.StandardScopes.Email,
						"phone",
					},
                   
				}
			};
	}
}

