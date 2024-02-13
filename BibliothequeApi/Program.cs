using BibliothequeApi;
using BibliothequeApi.Interfaces;
using BibliothequeApi.Repositories;
using BibliothequeApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<BibliothequeContext>(options =>
        options.UseSqlServer(connectionString));
builder.Services.AddDbContext<UserContext>(options =>
        options.UseSqlServer(connectionString));
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // https://tools.ietf.org/html/rfc7519
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Tokens:Key"]!)),
            ValidAudience = builder.Configuration["Tokens:Issuer"]!,
            ValidIssuer = builder.Configuration["Tokens:Issuer"]!,
            ValidateIssuerSigningKey = true,
            //valider l'expiration et le nbf (not before)
            ValidateLifetime = true,
            RequireExpirationTime = true,
            ClockSkew = TimeSpan.FromMinutes(0)
        };
    });


builder.Services.AddScoped<IService<Domaine>, DomaineService>();
builder.Services.AddScoped<IService<Adresse>, AdresseService>();
builder.Services.AddScoped<IService<Auteur>, AuteurService>();
builder.Services.AddScoped<IService<Emprunt>, EmpruntService>();
builder.Services.AddScoped<IService<Lecteur>, LecteurService>();
builder.Services.AddScoped<IService<Livre>, LivreService>();

builder.Services.AddScoped<IRepository<Domaine>, DomaineRepository>();
builder.Services.AddScoped<IRepository<Adresse>, AdresseRepository>();
builder.Services.AddScoped<IRepository<Auteur>, AuteurRepository>();
builder.Services.AddScoped<IRepository<Emprunt>, EmpruntRepository>();
builder.Services.AddScoped<IRepository<Lecteur>, LecteurRepository>();
builder.Services.AddScoped<IRepository<Livre>, LivreRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.WithOrigins("http://localhost:4200")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
