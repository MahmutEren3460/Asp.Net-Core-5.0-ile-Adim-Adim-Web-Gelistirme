using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<WriteUsers,WriteRole>().AddEntityFrameworkStores<Context>();
builder.Services.AddControllersWithViews();

builder.Services.AddMvc(config =>
{
	var policy=new AuthorizationPolicyBuilder()
	.RequireAuthenticatedUser()
	.Build();
	config.Filters.Add(new AuthorizeFilter(policy));
});



//builder.Services.AddMvc();
//builder.Services.AddAuthentication(
//	CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x => { x.LoginPath = "/AdminLogin/Index/"; });

builder.Services.ConfigureApplicationCookie(options =>
{
	options.Cookie.HttpOnly = true;
	options.ExpireTimeSpan = TimeSpan.FromHours(8);
	options.AccessDeniedPath = "/ErrorPage/Index/";
	options.LoginPath= "/Writer/Login/Index/";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404/");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
	  name: "areas",
	  pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}"
	);
});

app.Run();
