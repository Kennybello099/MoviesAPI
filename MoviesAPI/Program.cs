using Microsoft.EntityFrameworkCore;
using MoviesAPI.Interface;
using MoviesAPI.Migration;
using MoviesAPI.Repository;
using MoviesAPI.Service;
using MoviesAPI.Utility;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// For Entity Framework
var configuration = builder.Configuration;
builder.Services.AddDbContext<ApplicationData>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUploadPhoto, UploadPhoto>();
builder.Services.AddScoped<IUnitofWork, UnitofWork>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();


//string xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
//string xmlCommentFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);

//builder.Services.AddInfrastructure(builder.Configuration, xmlCommentFullPath);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
