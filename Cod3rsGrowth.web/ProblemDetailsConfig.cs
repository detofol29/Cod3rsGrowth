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
            var excecaoDetalhada = RetornarTipoDeExcessaoDetalhada(exception);
            problemDetails.Title = excecaoDetalhada.Title;
            problemDetails.Status = excecaoDetalhada.Status;
            problemDetails.Type = "https://tools.ietf.org/html/rfc7807#section-6.6.1";
            problemDetails.Detail = exception.Message + exception.StackTrace;
        }

        private static void LogException(ILogger logger, Exception exception)
        {
            logger.LogError($"Erro: {exception}");
        }

        public static ProblemDetails RetornarTipoDeExcessaoDetalhada(Exception ex)
        {
            var tipoDeExecao = ex.GetType().Name;
            var problemasDetalhes = new ProblemDetails();
            switch (tipoDeExecao)
            {
                case "ValidationException":
                    problemasDetalhes.Title = "Erro de Validação: " + ex.Message;
                    problemasDetalhes.Status = StatusCodes.Status500InternalServerError;
                    break;
                case "BadHttpRequestException":
                    problemasDetalhes.Title = "Erro de requisicao inválida: " + ex.Message;
                    problemasDetalhes.Status = StatusCodes.Status400BadRequest;
                    break;
                case "SqlException":
                    problemasDetalhes.Title = "Erro de banco de dados: " + ex.Message;
                    problemasDetalhes.Status = StatusCodes.Status500InternalServerError;
                    break;
                case "NullReferenceException":
                    problemasDetalhes.Title = "Erro de referência nula: " + ex.Message;
                    problemasDetalhes.Status = StatusCodes.Status500InternalServerError;
                    break;
                default:
                    problemasDetalhes.Title = "Erro inesperado: " + ex.Message;
                    problemasDetalhes.Status = StatusCodes.Status500InternalServerError;
                    break;
            }

            return problemasDetalhes;
        }
    }
}