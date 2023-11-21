using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NotesAPI.Data;
using NotesAPI.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection")
 ));
builder.Services.AddScoped<IDbServices, DbRepository>();
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

ApplyMigration();
app.Run();
void ApplyMigration()
{
    var scope = app.Services.CreateScope();
    var _db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if (_db.Database.GetPendingMigrations().Count() > 0)
    {
        _db.Database.Migrate();
    }
}
