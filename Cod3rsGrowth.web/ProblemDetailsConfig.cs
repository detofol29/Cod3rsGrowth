using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;

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
                        var problemDetails = RetornarExcecaoDetalhada(contexto, exception);
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
        private static void LogException(ILogger logger, Exception exception)
        {
            logger.LogError($"Erro: {exception}");
        }

        public static ProblemDetails RetornarExcecaoDetalhada(HttpContext contexto, Exception ex)
        {
            var tipoDeExcecao = ex.GetType().Name;
            var problemasDetalhes = new ProblemDetails();
            switch (tipoDeExcecao)
            {
                case nameof(ValidationException):
                    problemasDetalhes.Title = "Erro de Validação: " + ex.Message;
                    problemasDetalhes.Status = StatusCodes.Status400BadRequest;
                    problemasDetalhes.Type = "https://tools.ietf.org/html/rfc7807#section-6.5.1";
                    break;
                case nameof(BadHttpRequestException):
                    problemasDetalhes.Title = "Erro de requisição inválida: " + ex.Message;
                    problemasDetalhes.Status = StatusCodes.Status400BadRequest;
                    problemasDetalhes.Type = "https://tools.ietf.org/html/rfc7807#section-6.5.1";
                    break;
                case nameof(SqlException):
                    problemasDetalhes.Title = "Erro de banco de dados: " + ex.Message;
                    problemasDetalhes.Status = StatusCodes.Status500InternalServerError;
                    problemasDetalhes.Type = "https://tools.ietf.org/html/rfc7807#section-6.6.1";
                    break;
                case nameof(NullReferenceException):
                    problemasDetalhes.Title = "Erro de referência nula: " + ex.Message;
                    problemasDetalhes.Status = StatusCodes.Status500InternalServerError;
                    problemasDetalhes.Type = "https://tools.ietf.org/html/rfc7807#section-6.6.1";
                    break;
                default:
                    problemasDetalhes.Title = "Erro inesperado: " + ex.Message;
                    problemasDetalhes.Status = StatusCodes.Status500InternalServerError;
                    problemasDetalhes.Type = "https://tools.ietf.org/html/rfc7807#section-6.6.1";
                    break;
            }
            problemasDetalhes.Detail = ex.Message
                + ex.StackTrace;
            problemasDetalhes.Instance = contexto.Request.Path;
            return problemasDetalhes;
        }
    }
}