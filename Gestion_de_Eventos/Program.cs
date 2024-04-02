
using Gestion_de_Eventos.Data;
using Gestion_de_Eventos.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string conectionString= builder.Configuration.GetConnectionString("EventosConexion");
if(!string.IsNullOrEmpty(conectionString)){
    builder.Services.AddDbContext<EventosContext>(options =>{
        options.UseMySql(
            conectionString,
            new MySqlServerVersion(new Version (8,0,19))
        );
    });
}
//aqui abajo ponemos los servicios cuando los crees.

builder.Services.AddScoped<EventoServices>();
builder.Services.AddScoped<UsuarioServices>();
builder.Services.AddScoped<IngresarComprarBoletoServices>();
builder.Services.AddScoped<OrganizadorServices>();
builder.Services.AddScoped<ComentarioServices>();
builder.Services.AddScoped<SeguidoresServices>();
//aqui ingresas caundo tengas el token

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
