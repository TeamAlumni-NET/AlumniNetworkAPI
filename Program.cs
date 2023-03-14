using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Services.Events;
using AlumniNetworkAPI.Services.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

string myCorsPolicy = "_myAllowSpecificOrigins";

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: myCorsPolicy,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
        });
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AlumniNetworkDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Db")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IEventService, EventService>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = builder.Configuration["TokenSecrets:IssuerURI"],
        ValidAudience = "account",

        IssuerSigningKeyResolver = (token, securityToken, kid, parameters) =>
        {
            var client = new HttpClient();
            string keyuri = builder.Configuration["TokenSecrets:KeyURI"];
            //Retrieves the keys from keycloak instance to verify token
            var response = client.GetAsync(keyuri).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(responseString);
            var keys = new JsonWebKeySet(responseString);

            return keys.Keys;
        }
    });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseCors(myCorsPolicy);
app.UseAuthorization();

app.MapControllers();

app.Run();