global using OppgaveUke2API;
using Microsoft.EntityFrameworkCore;
using OppgaveUke2API.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var startup = new StartUp(builder.Configuration);
startup.ConfigurationServices(builder.Services);


var app = builder.Build();
startup.Configure(app, app.Environment);


app.Run();