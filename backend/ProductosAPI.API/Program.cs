using Microsoft.EntityFrameworkCore;

using ProductosAPI.Models;
using ProductosAPI.Repositories;
using ProductosAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.WebHost.UseSentry(o =>
{
    o.Dsn = "https://08c57dd153501c7d2d2ccc3dddc49930@o4509531306459136.ingest.us.sentry.io/4509531314913280";
    // Activar el seguimiento de rendimiento
    o.TracesSampleRate = 1.0;
    // Activar el modo de depuración en desarrollo
    o.Debug = builder.Environment.IsDevelopment();
});

builder.Services.AddControllers();

// Configurar CORS para permitir todas las solicitudes
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Configurar Entity Framework con SQLite
builder.Services.AddDbContext<ProductosDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar inyección de dependencias
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProductoService, ProductoService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Productos API",
        Version = "v1",
        Description = "API para gestión de productos con .NET 8 y SQLite"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Productos API V1");
        c.RoutePrefix = string.Empty; // Hacer que Swagger esté disponible en la raíz
    });
}

//app.UseHttpsRedirection();

// Habilitar CORS
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

// Crear la base de datos y aplicar migraciones
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ProductosDbContext>();
    context.Database.EnsureCreated();
}

app.Run();
