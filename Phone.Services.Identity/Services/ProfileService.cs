

using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Phone.Services.Identity.Models;
using System.Security.Claims;

// This code defines a class called ProfileService which implements the IProfileService interface from the Duende.IdentityServer.Services namespace. 
// The ProfileService is responsible for providing user profile information for authentication and authorization purposes.

namespace Phone.Services.Identity.Services

{
    public class ProfileService : IProfileService
    {
        // Private fields for User Claims Principal Factory, User Manager, and Role Manager
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
        private readonly UserManager<ApplicationUser> _userMgr;
        private readonly RoleManager<IdentityRole> _roleMgr;

        // Constructor for ProfileService which takes UserManager, RoleManager and IUserClaimsPrincipalFactory as arguments
        public ProfileService(
            UserManager<ApplicationUser> userMgr,
            RoleManager<IdentityRole> roleMgr,
            IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory)
        {
            _userMgr = userMgr;
            _roleMgr = roleMgr;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        }

        // Implementation of IProfileService's GetProfileDataAsync method
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            // Get the subject ID from the context
            string sub = context.Subject.GetSubjectId();
            // Find the user by the subject ID
            ApplicationUser user = await _userMgr.FindByIdAsync(sub);
            // Create a ClaimsPrincipal for the user
            ClaimsPrincipal userClaims = await _userClaimsPrincipalFactory.CreateAsync(user);

            // Create a list of claims from the userClaims
            List<Claim> claims = userClaims.Claims.ToList();
            // Filter the list of claims to only include the requested claim types
            claims = claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();
            // Add the user's first and last name as claims
            claims.Add(new Claim(JwtClaimTypes.FamilyName, user.LastName));
            claims.Add(new Claim(JwtClaimTypes.GivenName, user.FirstName));

            // If the UserManager supports user roles, add the user's roles as claims
            if (_userMgr.SupportsUserRole)
            {
                // Get the roles for the user
                IList<string> roles = await _userMgr.GetRolesAsync(user);
                foreach (var rolename in roles)
                {
                    // Add each role as a claim
                    claims.Add(new Claim(JwtClaimTypes.Role, rolename));
                    // If the RoleManager supports role claims, add the claims associated with each role as claims
                    if (_roleMgr.SupportsRoleClaims)
                    {
                        IdentityRole role = await _roleMgr.FindByNameAsync(rolename);
                        if (role != null)
                        {
                            claims.AddRange(await _roleMgr.GetClaimsAsync(role));
                        }
                    }
                }
            }

            // Set the issued claims to the list of claims
            context.IssuedClaims = claims;
        }

        // Implementation of IProfileService's IsActiveAsync method
        public async Task IsActiveAsync(IsActiveContext context)
        {
            // Get the subject ID from the context
            string sub = context.Subject.GetSubjectId();
            // Find the user by the subject ID
            ApplicationUser user = await _userMgr.FindByIdAsync(sub);
            // Set the IsActive flag based on whether the user was found
            context.IsActive = user != null;
        }
    }
}
