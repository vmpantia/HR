using HR.Api.Helpers;
using HR.BAL.Mapper;
using HR.BAL.Services;
using HR.DAL.Contractors;
using HR.DAL.DataAccess;
using HR.DAL.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Database Configurations
builder.Services.AddDbContext<HRDbContext>(opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("QA")));

//Services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddSingleton<UrlHelper>();

//AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
