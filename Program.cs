using JworgApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. CONFIGURAÇÕES DE SERVIÇOS
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Configure o nome da política aqui
builder.Services.AddCors(options => {
    options.AddPolicy("AllowReact", policy => {
        policy.AllowAnyOrigin()   // Permite qualquer site (Vercel, Localhost, etc)
              .AllowAnyMethod()   // Permite POST, GET, PUT, DELETE
              .AllowAnyHeader();  // Permite Content-Type, Authorization, etc
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 2. CONFIGURAÇÕES DO PIPELINE

    app.UseSwagger();
    app.UseSwaggerUI();


// IMPORTANTE: Use o mesmo nome que definiu lá em cima ("AllowReact")
// E chame apenas UMA vez antes do Authorization
app.UseCors("AllowReact");

app.UseAuthorization();
app.MapControllers();

app.Run();