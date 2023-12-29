using Microsoft.EntityFrameworkCore;
using PlayerAgentManagement.BL;
using PlayerAgentManagement.DAL;
using PlayerAgentManagement.DAL.EF;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PlayerAgentDbContext>(optionsBuilder =>
    optionsBuilder.UseSqlite("Data Source=PlayerAgentManagement.sqlite"));
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IManager, Manager>();

var app = builder.Build();
    
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PlayerAgentDbContext>();
    if (context.CreateDatabase(true))
    {
        DataSeeder.Seed(context);
    }
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