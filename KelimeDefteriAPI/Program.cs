using KelimeDefteriAPI.Context;
using KelimeDefteriAPI.Middlewares;
using KelimeDefteriAPI.Services.Logger;
using KelimeDefteriAPI.Services.Logger.Implementations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<KelifeDefteriAPIContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration["ConnectionStrings:KelimeDefteriAPIDB"]);
});
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<ILoggerService, ConsoleLogger>();
var app = builder.Build();
app.UseHTTPInfo();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors(opt =>
{
    opt.AllowAnyHeader();
    opt.AllowAnyOrigin();
    opt.AllowAnyMethod();
    opt.WithExposedHeaders("Location");
});

app.MapControllers();

app.Run();
