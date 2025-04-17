using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Restaurante.Models;
using Restaurante.Interfaces; // 👈 Nuevo using para IUnitOfWork
using Restaurante.Repositories; // 👈 Nuevo using para UnitOfWork
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// 💾 Conexión a la base de datos
var connectionString = "server=localhost;port=3306;user=root;database=restaurante;";
builder.Services.AddDbContext<RestauranteContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// 🔄 Configuración del UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); // 👈 Aquí va la línea

// 🧩 Agregar controladores con vistas
builder.Services.AddControllersWithViews();

// 🔁 Configurar manejo de ciclos de referencia
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });

// 🧪 Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Restaurante API", Version = "v1" });
});

var app = builder.Build();

// 🧯 Manejo de errores y seguridad
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// 🌐 HTTPS, archivos estáticos y rutas
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 🧪 Swagger Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurante API v1");
    });
}

// 🔁 Rutas MVC por defecto
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();