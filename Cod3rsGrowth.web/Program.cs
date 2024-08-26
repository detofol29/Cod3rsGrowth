using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Web;
using ILoggerFactory = Microsoft.Extensions.Logging.ILoggerFactory;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddProblemDetails();

ModuloInjetorInfra.AdquirirServicos(builder.Services);
var serviceProvider = builder.Services.BuildServiceProvider();
ModuloInjetorInfra.UpdateDatabase(serviceProvider);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseFileServer(new FileServerOptions()
{
    EnableDirectoryBrowsing = true
});
app.UseStaticFiles(new StaticFileOptions()
{
    ServeUnknownFileTypes = true
});

var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();

app.UseProblemDetailsExceptionHandler(loggerFactory);
app.MapControllers();
app.Run();