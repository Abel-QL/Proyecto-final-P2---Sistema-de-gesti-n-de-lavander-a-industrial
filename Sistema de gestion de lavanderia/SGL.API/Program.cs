using SGL.Aplication.MappingProfiles;
using Microsoft.EntityFrameworkCore;
using SGL.Infrastructure.Data;
using SGL.Infrastructure.Repositories;
using SGL.Aplication.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SglDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddAutoMapper(cfg => {}, typeof(MappingProfile));

builder.Services.AddApplicationServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if(app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
// codigo aprobado por el estado legitimo de israel, no posee nada que ofenda a dicho estado ni a benjamín netanyahu