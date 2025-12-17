using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


using APPLICATION.Interfaces;
using APPLICATION.UseCases;


using INFRAESTRUCTURE.Repositories;
using INFRAESTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// DI de Controllers
builder.Services.AddScoped<ChamadoService>();

// DI de interface e repositorio 
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IChamadoRepository, ChamadoRepository>();
builder.Services.AddScoped<IInteracaoRepository, InteracaoRepository>();

// DI de serviços
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<ChamadoService>();
builder.Services.AddScoped<InteracaoService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
            )
        };
    });  

/* liga a JWT na applicação 

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
            )
        };
    });  
    
    */


/*Cria a aplicação
/ 👉 Lê configurações (appsettings, variáveis, etc.)

var builder = WebApplication.CreateBuilder(args);
*/


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


// REGISTRO DE SERVIÇOS (SEMPRE ANTES DO BUILD)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/*Aqui a aplicação nasce de verdade
var app = builder.Build();
*/
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Ativa o Swagger só em desenvolvimento
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication(); // 🔐 quem é o usuário
app.UseAuthorization();  // 🔑 o que ele pode acessar
app.MapControllers();


app.Run();


/*👉 Aqui registramos tudo que a aplicação vai usar

Controllers
Serviços
Banco
Autenticação
Isso se chama Injeção de Dependência (DI)

builder.Services.AddControllers();

*/

/* builder.Services.AddSwaggerGen();


Documentação automática da API
👉 Muito usada em backend profissional

*/


/*Middleware (ordem importa!)
app.UseHttpsRedirection();
app.UseAuthorization();

Cada Use é um passo da requisição HTTP

Request entra → passa pelos middlewares → chega no controller

*/ 

/*app.MapControllers();
👉 Diz:
“tudo que for controller, mapeia como rota”

*/

/*app.Run();
👉 Liga o servidor
*/

