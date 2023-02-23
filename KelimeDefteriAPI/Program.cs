using Application;
using KelimeDefteriAPI.Context;
using KelimeDefteriAPI.MediatoR;
using KelimeDefteriAPI.Middlewares;
using KelimeDefteriAPI.Services.Logger;
using KelimeDefteriAPI.Services.Logger.Implementations;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors( opt =>
{
    opt.AddPolicy("angular", policy => policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowCredentials().AllowAnyHeader());
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddMediatRService();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices();
builder.Services.AddDbContext<KelifeDefteriAPIContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration["ConnectionStrings:KelimeDefteriAPIDB"]);
});
//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<ILoggerService, ConsoleLogger>();
builder.Services.AddRateLimiter(opt =>
{
    opt.AddFixedWindowLimiter("Basic", opt =>
    {
        opt.Window = TimeSpan.FromSeconds(12);
        opt.PermitLimit = 12;
        opt.QueueLimit = 1;
        opt.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
    });
});
var app = builder.Build();
app.UseRateLimiter();
app.UseHTTPInfo();
app.UseErrorHandling();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors("angular");

app.MapControllers();

app.Run();
