using Microsoft.EntityFrameworkCore;
using NukeSafety.Models;
using NukeSafety.ORM.Context;
using NukeSafety.ORM.Factory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<NukeSafetyContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

//builder.Services.AddSingleton(typeof(AirExplosionFactory));
//builder.Services.AddSingleton(typeof(CosmicExplosionFactory));
//builder.Services.AddSingleton(typeof(HeightExplosionFactory));
//builder.Services.AddSingleton(typeof(GroundExplosionFactory));
//builder.Services.AddSingleton(typeof(UndergroundExplosionFactory));
//builder.Services.AddSingleton(typeof(WaterExplosionFactory));
//builder.Services.AddSingleton(typeof(UnderwaterExplosionFactory));

builder.Services.AddSingleton(typeof(ExplosionCreator));

var app = builder.Build();

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
