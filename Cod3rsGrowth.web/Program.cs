using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Web;
using Microsoft.Extensions.Logging;
using Microsoft.Owin.Logging;
using ILoggerFactory = Microsoft.Extensions.Logging.ILoggerFactory;
using LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddProblemDetails();
builder.Services.AddSwaggerGen();

ModuloInjetorInfra.AdquirirServicos(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();

app.UseProblemDetailsExceptionHandler(loggerFactory);

app.MapControllers();

app.Run();