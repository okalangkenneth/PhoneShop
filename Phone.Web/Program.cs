
using Microsoft.AspNetCore.Authentication;
using Phone.Web;
using Phone.Web.Services;
using Phone.Web.Services.IServices;

// Create a new instance of WebApplicationBuilder and pass in command-line arguments
var builder = WebApplication.CreateBuilder(args);

// Add services to the container

// Register the HTTP client service for accessing the ProductAPI service
builder.Services.AddHttpClient<IProductService, ProductService>();
// Register the HTTP client service for accessing the ShoppingCartAPI service
builder.Services.AddHttpClient<ICartService, CartService>();

// Set the base URL for accessing the ProductAPI service
SD.ProductAPIBase = builder.Configuration["ServiceUrls:ProductAPI"];
SD.ShoppingCartAPIBase = builder.Configuration["ServiceUrls:ShoppingCartAPI"];

// Register the ProductService in the dependency injection container
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();

// Register the MVC framework's controller and views services in the container
builder.Services.AddControllersWithViews();

// Add authentication middleware to the pipeline

builder.Services.AddAuthentication(options =>
{
	// Specify the default authentication scheme and challenge scheme
	options.DefaultScheme = "Cookies";
	options.DefaultChallengeScheme = "oidc";
})
	// Add the cookie authentication scheme
	.AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
	// Add the OpenID Connect authentication scheme
	.AddOpenIdConnect("oidc", options =>
	{
		// Set the authority URL for the IdentityAPI service
		options.Authority = builder.Configuration["ServiceUrls:IdentityAPI"];
		// Retrieve user claims from the UserInfo endpoint
		options.GetClaimsFromUserInfoEndpoint = true;
		// Set the client ID and client secret for the OpenID Connect authentication flow
		options.ClientId = "phone";
		options.ClientSecret = "secret";
		options.ResponseType = "code";
        options.ClaimActions.MapJsonKey("role", "role", "role");
        options.ClaimActions.MapJsonKey("sub", "sub", "sub");
        // Map user claims to the correct names
        options.TokenValidationParameters.NameClaimType = "name";
		options.TokenValidationParameters.RoleClaimType = "role";
		// Add the "phone" scope to the access token request
		options.Scope.Add("phone");
		options.SaveTokens = true;
	});

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline

// If the environment is not development, configure error handling and HTTP Strict Transport Security (HSTS)
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

// Redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

// Serve static files like CSS, JavaScript, and images
app.UseStaticFiles();

// Add routing middleware to the pipeline
app.UseRouting();

// Add authentication middleware to the pipeline
app.UseAuthentication();

// Add authorization middleware to the pipeline
app.UseAuthorization();

// Map endpoints to controllers and actions
app.UseEndpoints(endpoints =>

{
    


    // Map the "product" endpoint to the ProductController1 controller's ProductIndex action
    endpoints.MapControllerRoute(
		name: "product",
		pattern: "Product/{action=ProductIndex}/{id?}",
		defaults: new { controller = "ProductController1" });

	// Map the default endpoint to the HomeController controller's Index action
	endpoints.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");
});

// Run the application
app.Run();






