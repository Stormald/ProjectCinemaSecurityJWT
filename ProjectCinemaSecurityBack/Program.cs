using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectCinemaSecurityBack.Context;
using ProjectCinemaSecurityBack.Repositories;
using ProjectCinemaSecurityBack.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost:7153",
            ValidAudience = "https://localhost:7153",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ma clÅEsuper secrËte"))
        };
    });

builder.Services.AddEntityFrameworkMySql().AddDbContext<CinemaContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("admin"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.6.5-mariadb"),
        mySqlOptionsAction: mySqlOptions =>
        {
            mySqlOptions.EnableRetryOnFailure();
        });
});

//repositories
builder.Services.AddTransient<FilmRepository, FilmRepository>();
builder.Services.AddTransient<LoginRepository, LoginRepository>();

//services
builder.Services.AddTransient<FilmService, FilmService>();
builder.Services.AddTransient<LoginService, LoginService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("EnableCORS");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
