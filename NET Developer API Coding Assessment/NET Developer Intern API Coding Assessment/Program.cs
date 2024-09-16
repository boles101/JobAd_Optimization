using Microsoft.EntityFrameworkCore;
using NET_Developer_Intern_API_Coding_Assessment.Data;
using NET_Developer_Intern_API_Coding_Assessment.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Data Base Connection.

builder.Services.AddDbContext<AssesmentDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

#endregion

#region Services.
builder.Services.AddServices(); // extension method..In Extensions folder ! 

#endregion
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
