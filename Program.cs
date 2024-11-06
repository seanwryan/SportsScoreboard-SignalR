using Microsoft.AspNetCore.SignalR;
using SportsScoreboard.Hubs;
using SportsScoreboard.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();  // Add SignalR
builder.Services.AddScoped<ScoreService>();  // Register the ScoreService as a scoped dependency

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Map SignalR hubs
app.MapHub<ScoreHub>("/scoreHub");

app.Run();