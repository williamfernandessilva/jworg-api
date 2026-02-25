using JworgApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// 1. CONFIGURAÇÕES DE SERVIÇOS (Tudo que o app precisa "saber")

// Pega a string de conexão do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configura o Contexto do Banco com MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Configura o CORS para o React
builder.Services.AddCors(options => {
    options.AddPolicy("AllowReact", policy => {
        policy.WithOrigins("http://localhost:5173") // Porta do seu Vite/React
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ---------------------------------------------------------

var app = builder.Build();
app.UseCors("AllowReact");

// 2. CONFIGURAÇÕES DO PIPELINE (Como as requisições fluem)

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ATENÇÃO: Use o CORS antes do Authorization e MapControllers
app.UseCors("ReactPolicy");

// app.UseHttpsRedirection(); // estou usando local 
app.UseAuthorization();
app.MapControllers();

app.Run();