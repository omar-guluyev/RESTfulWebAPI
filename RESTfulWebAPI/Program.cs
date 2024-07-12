using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RESTfulWebAPI.Abstractions.Repositories;
using RESTfulWebAPI.Abstractions.Services;
using RESTfulWebAPI.Abstractions.UnitOfWork;
using RESTfulWebAPI.Context;
using RESTfulWebAPI.Entities.Identity;
using RESTfulWebAPI.Implementations.Repositories;
using RESTfulWebAPI.Implementations.Services;
using RESTfulWebAPI.Implementations.UnitOfWork;
using RESTfulWebAPI.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adding Db Context
builder.Services.AddDbContext<AppDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EducationDB")));

// Adding Identity
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{

}).AddEntityFrameworkStores<AppDBContext>().AddDefaultTokenProviders(); 

// mapper
builder.Services.AddAutoMapper(typeof(MapperProfile));

//services
builder.Services.AddScoped<ISchoolService, SchoolService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//repositories
builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

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
