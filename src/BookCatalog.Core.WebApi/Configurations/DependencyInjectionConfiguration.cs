using BookCatalog.Common.Util.Services;
using BookCatalog.Core.Data.Context;
using BookCatalog.Core.Data.Repositories;
using BookCatalog.Core.Domain.Interfaces.Repositories;
using BookCatalog.Core.Domain.Interfaces.Services;
using BookCatalog.Core.Service.Application;
using BookCatalog.Core.Service.Facades;
using BookCatalog.Core.Service.Facades.Interfaces;

namespace BookCatalog.Core.WebApi.Configurations;

public static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        // Lifestyle.Transient => Uma instância para cada solicitação
        // Lifestyle.Singleton => Uma instância única para a classe (para servidor)
        // Lifestyle.Scoped => Uma instância única para o request

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<INotificationHandler<Notification>, NotificationHandler>();

        #region Application - Facade

        services.AddTransient<IUserFacade, UserFacade>();
        services.AddTransient<IAuthFacade, AuthFacade>();
        services.AddScoped<IBookFacade, BookFacade>();

        services.AddTransient<IGenreFacade, GenreFacade>();
        services.AddTransient<IPublisherFacade, PublisherFacade>();

        #endregion

        #region Domain

        services.AddTransient<IActivationAppService, ActivationAppService>();
        services.AddTransient<IEmailAppService, EmailAppService>();

        services.AddTransient<IUserAppService, UserAppService>();
        services.AddTransient<IUserClaimsAppService, UserClaimsAppService>();
        services.AddScoped<IBookAppService, BookAppService>();

        services.AddTransient<IGenreAppService, GenreAppService>();
        services.AddTransient<IPublisherAppService, PublisherAppService>();

        #endregion

        #region InfraData

        services.AddScoped<BookCatalogContext>();

        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUserClaimsRepository, UserClaimsRepository>();
        services.AddScoped<IBookRepository, BookRepository>();

        services.AddTransient<IGenreRepository, GenreRepository>();
        services.AddTransient<IPublisherRepository, PublisherRepository>();

        #endregion
    }
}