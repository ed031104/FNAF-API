using Api_FNAF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContextFactory<FNAFContext>(options =>
    options.UseSqlServer("Server=.;Database=FNAF;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;")
);
 
builder.Services.AddScoped<Api_FNAF.Repository.FNAFRepositoryI, Api_FNAF.Repository.Implementation.FNAFRepository>();
builder.Services.AddScoped<Api_FNAF.Services.FNFAFServices>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
