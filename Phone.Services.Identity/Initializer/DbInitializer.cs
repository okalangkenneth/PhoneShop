using IdentityModel; 
using Microsoft.AspNetCore.Identity; 
using Phone.Services.Identity.DbContexts;
using Phone.Services.Identity.Models; 
using System.Security.Claims; 

namespace Phone.Services.Identity.Initializer
{
	public class DbInitializer : IDbInitializer
	{
		private readonly ApplicationDbContext _db;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public DbInitializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_db = db;
			_userManager = userManager;
			_roleManager = roleManager;
		}

		public void Initialize()
		{
			// Create the 'Admin' and 'Customer' roles if they don't already exist
			if (_roleManager.FindByNameAsync(SD.Admin).Result == null)
			{
				_roleManager.CreateAsync(new IdentityRole(SD.Admin)).GetAwaiter().GetResult();
				_roleManager.CreateAsync(new IdentityRole(SD.Customer)).GetAwaiter().GetResult();
			}
			else
			{
				return; // if the roles already exist, exit the method
			}

			// Create an admin user and add them to the 'Admin' role
			ApplicationUser adminUser = new ApplicationUser()
			{
				UserName = "admin1@gmail.com",
				Email = "admin1@gmail.com",
				EmailConfirmed = true,
				PhoneNumber = "676767676",
				FirstName = "Kenneth",
				LastName = "Admin"
			};

			_userManager.CreateAsync(adminUser, "Admin123*").GetAwaiter().GetResult();
			_userManager.AddToRoleAsync(adminUser, SD.Admin).GetAwaiter().GetResult();

			// Add claims to the admin user's security token
			var temp1 = _userManager.AddClaimsAsync(adminUser, new Claim[] {
				new Claim(JwtClaimTypes.Name,adminUser.FirstName+" "+ adminUser.LastName),
				new Claim(JwtClaimTypes.GivenName,adminUser.FirstName),
				new Claim(JwtClaimTypes.FamilyName,adminUser.LastName),
				new Claim(JwtClaimTypes.Role,SD.Admin),
			}).Result;

			// Create a customer user and add them to the 'Customer' role
			ApplicationUser customerUser = new ApplicationUser()
			{
				UserName = "customer1@gmail.com",
				Email = "customer1@gmail.com",
				EmailConfirmed = true,
				PhoneNumber = "23456789",
				FirstName = "Kenneth",
				LastName = "Customer"
			};

			_userManager.CreateAsync(customerUser, "Admin123*").GetAwaiter().GetResult();
			_userManager.AddToRoleAsync(customerUser, SD.Customer).GetAwaiter().GetResult();

			// Add claims to the customer user's security token
			var temp2 = _userManager.AddClaimsAsync(customerUser, new Claim[] {
				new Claim(JwtClaimTypes.Name,customerUser.FirstName+" "+ customerUser.LastName),
				new Claim(JwtClaimTypes.GivenName,customerUser.FirstName),
				new Claim(JwtClaimTypes.FamilyName,customerUser.LastName),
				new Claim(JwtClaimTypes.Role,SD.Customer),
			}).Result;
		}
	}
}

