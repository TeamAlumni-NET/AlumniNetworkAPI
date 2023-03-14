using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Services.Events;
using AlumniNetworkAPI.Services.EventUsers;
using AlumniNetworkAPI.Services.Groups;
using AlumniNetworkAPI.Services.Users;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AlumniNetworkDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Db")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IEventService, EventService>();
builder.Services.AddTransient<IEventUserService, EventUserService>();
builder.Services.AddTransient<IGroupService, GroupService>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
