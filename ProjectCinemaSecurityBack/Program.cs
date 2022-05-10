using Microsoft.EntityFrameworkCore;
using ProjectCinemaSecurityBack.Context;
using ProjectCinemaSecurityBack.Repositories;
using ProjectCinemaSecurityBack.Services;

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
