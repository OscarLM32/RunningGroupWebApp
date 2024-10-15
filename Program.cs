using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RunningGroupWebApp.Data;
using RunningGroupWebApp.Helpers;
using RunningGroupWebApp.Interfaces;
using RunningGroupWebApp.Repositories;
using RunningGroupWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseSqlServer(connString);
});

builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));

builder.Services.AddScoped<IClubRepository, ClubRepository>();
builder.Services.AddScoped<IPhotoService, CloudinaryPhotoService>();
builder.Services.AddScoped<IRaceRepository, RaceRepository>();

var app = builder.Build();

if(args.Length == 1 && args[0]== "seeddata")
{
	Seed.SeedData(app);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
