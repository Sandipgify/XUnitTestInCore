using Microsoft.EntityFrameworkCore;
using Data;
using Service.Repository;
using Data.Repository;
using Service.Interface;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Register Service/Repository

builder.Services.AddScoped<IClientRepository, ClientRepository>();

builder.Services.AddScoped<IClientService, ClientService>();

#endregion

builder.Services.AddDbContext<ClientDBContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("ClientDbContext"),
    x=>x.MigrationsAssembly("UnitTestWithXUnit"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var dbContext = builder.Services.BuildServiceProvider().GetRequiredService<ClientDBContext>();
var seeder = new SeedData(dbContext);
seeder.Gender();

app.UseAuthorization();

app.MapControllers();

app.Run();
