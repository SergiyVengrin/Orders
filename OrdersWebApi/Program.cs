using Application;
using Application.Common.Middlewares;
using Infrastructure;
using OrdersWebApi;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Host.UseSerilog((context, o) =>
{
    o.WriteTo.File(path: $@"{Directory.GetCurrentDirectory()}\Logs\log.txt");
    o.WriteTo.Console();
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();