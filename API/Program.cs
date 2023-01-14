using BLL.Domains;
using DAL.Models;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<EmployeeManagementDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(EmployeeManagementDbContext))));

builder.Services.AddScoped<EmployeeDomain>();
builder.Services.AddScoped<AttendanceDomain>();
builder.Services.AddScoped<ShiftDomain>();

builder.Services.AddScoped<EmployeeRepository>();
builder.Services.AddScoped<AttendanceRepository>();
builder.Services.AddScoped<ShiftRepository>();

builder.Services.AddControllers()
    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


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
