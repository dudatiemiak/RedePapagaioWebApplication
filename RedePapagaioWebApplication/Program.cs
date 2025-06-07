using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RedePapagaioWebApplication.Connection;
using RedePapagaioWebApplication.Repository;
using RedePapagaioWebApplication.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API REST de Controle de Desastres Naturais (Ocorrências), Usuários, Ajudas.",
        Description = "Uma aplicação destinada ao controle de ocorrências, usuários e ajudas fornecidas por esses usuários através de rotas de api e integração com o banco de dados"
    });
});

builder.Services.AddScoped<AjudaRealizadaService>();
builder.Services.AddScoped<RegiaoService>();
builder.Services.AddScoped<NivelUrgenciaService>();
builder.Services.AddScoped<OcorrenciaService>();
builder.Services.AddScoped<StatusOcorrenciaService>();
builder.Services.AddScoped<TelefoneService>();
builder.Services.AddScoped<TipoAjudaService>();
builder.Services.AddScoped<TipoOcorrenciaService>();
builder.Services.AddScoped<UsuarioService>();

builder.Services.AddScoped<AjudaRealizadaRepository>();
builder.Services.AddScoped<RegiaoRepository>();
builder.Services.AddScoped<NivelUrgenciaRepository>();
builder.Services.AddScoped<OcorrenciaRepository>();
builder.Services.AddScoped<StatusOcorrenciaRepository>();
builder.Services.AddScoped<TelefoneRepository>();
builder.Services.AddScoped<TipoAjudaRepository>();
builder.Services.AddScoped<TipoOcorrenciaRepository>();
builder.Services.AddScoped<UsuarioRepository>();

// Configura o DbContext com Oracle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

// Configuração do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = string.Empty;  // Configura o Swagger UI para ser acessado diretamente na raiz (http://localhost:5169/)
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();