using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using SharpYaml.Serialization;

namespace Cod3rsGrowth.Web
{
    public static class ProblemDetailsConfig
    {
        public static void UseProblemDetailsExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(construtor =>
            {
                construtor.Run(async contexto =>
                {
                    var exceptionHandlerFeature = contexto.Features.Get<IExceptionHandlerFeature>();

                    if (exceptionHandlerFeature != null)
                    {
                        var exception = exceptionHandlerFeature.Error;
                        var problemDetails = CreateProblemDetails(contexto, exception);
                        var logger = loggerFactory.CreateLogger("GlobalExceptionHandler");

                        LogException(logger, exception);

                        contexto.Response.ContentType = "application/problem+json";
                        contexto.Response.StatusCode = problemDetails.Status.GetValueOrDefault(StatusCodes.Status500InternalServerError);

                        var json = JsonConvert.SerializeObject(problemDetails, new JsonSerializerSettings());
                        await contexto.Response.WriteAsync(json);
                    }
                });
            });
        }

        private static ProblemDetails CreateProblemDetails(HttpContext contexto, Exception exception)
        {
            var detalhesDeErro = new ProblemDetails
            {
                Instance = contexto.Request.Path,
                Title = "Erro",
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://tools.ietf.org/html/rfc7807",
                Detail = exception.Message + exception.StackTrace
            };

            ConfigurarDetalhesDeErros(detalhesDeErro, exception);
            return detalhesDeErro;
        }

        private static void ConfigurarDetalhesDeErros(ProblemDetails problemDetails, Exception exception)
        {
            problemDetails.Title = RetornarTipoDeExcessaoDetalhada(exception);
            problemDetails.Status = StatusCodes.Status500InternalServerError;
            problemDetails.Type = "https://tools.ietf.org/html/rfc7807#section-6.6.1";
            problemDetails.Detail = exception.Message + exception.StackTrace;
        }

        private static void LogException(ILogger logger, Exception exception)
        {
            logger.LogError($"Erro: {exception}");
        }

        public static string? RetornarTipoDeExcessaoDetalhada(Exception ex)
        {
            var tipoDeExecao = ex.GetType().Name;

            switch (tipoDeExecao)
            {
                case "ValidationException":
                    return "Erro de Validação: " + ex.Message;

                case "BadHttpRequestException":
                    return "Erro de requisicao inválida: " + ex.Message;

                case "SqlException":
                    return "Erro de banco de dados: " + ex.Message;

                case "NullReferenceException":
                    return "Erro de referência nula: " + ex.Message;

                default:
                    return "Erro inesperado: " + ex.Message;
            }
        }
    }
}