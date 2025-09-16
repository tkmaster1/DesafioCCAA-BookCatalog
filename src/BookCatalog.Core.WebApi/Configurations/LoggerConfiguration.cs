﻿using Microsoft.Extensions.FileProviders;
using BookCatalog.Common.Util.Configuration;

namespace BookCatalog.Core.WebApi.Configurations;

/// <summary>
/// Classe de extensão para configuração do sistema de logs da aplicação.
/// </summary>
public static class LoggerConfiguration
{
    /// <summary>
    /// Configura o sistema de logs da aplicação, separando logs gerais e de autenticação em subpastas.
    /// </summary>
    /// <param name="app">Aplicação web atual.</param>
    /// <param name="loggerFactory">Fábrica de loggers para gravação dos eventos.</param>
    /// <returns>Instância atualizada de IApplicationBuilder.</returns>
    public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        // Configura log geral da aplicação
        loggerFactory.UseLoggerFactory(
            Path.GetFullPath(Directory.GetCurrentDirectory() + "\\Log\\Core\\"),
            $"bookCatalog_core_{DateTime.Now:yyyyMMdd}.txt"
         );
        loggerFactory.CreateLogger("Auth-Core").LogError("init");

        // Configura log específico para autenticação JWT
        loggerFactory.UseLoggerFactory(
            Path.GetFullPath(Directory.GetCurrentDirectory() + "\\Log\\Auth\\"),
            $"AuthenticationJWT_{DateTime.Now:yyyyMMdd}.txt"
        );
        loggerFactory.CreateLogger("AuthenticationJWT").LogError("init");

        // Configura acesso via browser aos logs
        app.UseFileServer(new FileServerOptions()
        {
            FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), @"Log")),
            RequestPath = new PathString("/app-log"),
            EnableDirectoryBrowsing = true,
            EnableDefaultFiles = true
        });

        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "Log")),
            RequestPath = new PathString("/app-log"),
        });

        return app;
    }
}