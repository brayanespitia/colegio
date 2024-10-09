using Colegio.DataContext;
using Colegio.Service;
using Colegio.Service.AlumnoServiceImpl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // Permitir la URL de Angular
                  .AllowAnyMethod()                    // Permitir cualquier método (GET, POST, PUT, etc.)
                  .AllowAnyHeader();                   // Permitir cualquier encabezado
        });
});

builder.Services.AddDbContext<ColegioContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 

builder.Services.AddScoped<AlumnoService, AlumnoServiceImpl>();
builder.Services.AddScoped<ProfesorService, ProfesorServiceImpl>();




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
app.UseCors("AllowAngularApp");
app.UseAuthorization();

app.MapControllers();

app.Run();
