using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Services.Events;
using AlumniNetworkAPI.Services.EventUsers;
using AlumniNetworkAPI.Services.Groups;
using AlumniNetworkAPI.Services.Posts;
using AlumniNetworkAPI.Services.Topics;
using AlumniNetworkAPI.Services.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());

string myCorsPolicy = "_myAllowSpecificOrigins";

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: myCorsPolicy,
        policy =>
        {
            policy.WithOrigins("https://alumni-network-client-tau.vercel.app").AllowAnyHeader().AllowAnyMethod();
        });
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AlumniNetworkDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Db")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "AlumniNetworkAPI",
        Description = "API to get and manipulate Alumni Network Portal data.",
        Contact = new OpenApiContact
        {
            Name = "Marco Angeli, Jesperi Kuula, Kirsi Tainio & Heidi Joensuu",
            Url = new Uri("https://github.com/TeamAlumni-NET/AlumniNetworkAPI.git"),
        },
        License = new OpenApiLicense
        {
            Name = "MIT 2022",
            Url = new Uri("https://opensource.org/license/mit/")
        }
    });
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddTransient<IEventService, EventService>();
builder.Services.AddTransient<IEventUserService, EventUserService>();
builder.Services.AddTransient<IGroupService, GroupService>();
builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITopicService, TopicService>();

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = builder.Configuration["VaultUri:IssuerURI"],
        ValidAudience = "account",

        IssuerSigningKeyResolver = (token, securityToken, kid, parameters) =>
        {
            var client = new HttpClient();
            string keyuri = builder.Configuration["VaultUri:KeyURI"];
            //Retrieves the keys from keycloak instance to verify token
            var response = client.GetAsync(keyuri).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;
            var keys = new JsonWebKeySet(responseString);

            return keys.Keys;
        }
    });



var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseCors(myCorsPolicy);
app.UseAuthorization();

app.MapControllers();

app.Run();