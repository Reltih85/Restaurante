using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 🧩 Agregar controladores con vistas
builder.Services.AddControllersWithViews();

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