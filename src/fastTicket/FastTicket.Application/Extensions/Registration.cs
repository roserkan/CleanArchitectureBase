using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.CrossCuttingConcerns.Logging.Serilog.Logger;
using Core.ElasticSearch;
using Core.Mailing;
using Core.Mailing.MailKitImplementations;
using FastTicket.Application.Features.Auths.Rules;
using FastTicket.Application.Features.Categories.Rules;
using FastTicket.Application.Features.Cities.Rules;
using FastTicket.Application.Features.EventGroups.Rules;
using FastTicket.Application.Features.Events.Rules;
using FastTicket.Application.Features.OperationClaims.Rules;
using FastTicket.Application.Features.Performances.Rules;
using FastTicket.Application.Features.SubCategories.Rules;
using FastTicket.Application.Features.TicketCategories.Rules;
using FastTicket.Application.Features.Tickets.Rules;
using FastTicket.Application.Features.UserOperationClaims.Rules;
using FastTicket.Application.Features.Users.Rules;
using FastTicket.Application.Features.Venues.Rules;
using FastTicket.Application.Services.AuthService;
using FastTicket.Application.Services.CategoryService;
using FastTicket.Application.Services.CityService;
using FastTicket.Application.Services.EventGroupService;
using FastTicket.Application.Services.EventService;
using FastTicket.Application.Services.TicketService;
using FastTicket.Application.Services.UserService;
using FastTicket.Application.Services.VenueService;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FastTicket.Application.Extensions;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddScoped<CategoryBusinessRules>();
        services.AddScoped<SubCategoryBusinessRules>();
        services.AddScoped<AuthBusinessRules>();
        services.AddScoped<UserBusinessRules>();
        services.AddScoped<OperationClaimBusinessRules>();
        services.AddScoped<UserOperationClaimBusinessRules>();
        services.AddScoped<VenueBusinessRules>();
        services.AddScoped<EventBusinessRules>();
        services.AddScoped<EventGroupBusinessRules>();
        services.AddScoped<PerformanceBusinessRules>();
        services.AddScoped<TicketBusinessRules>();
        services.AddScoped<TicketCategoryBusinessRules>();
        services.AddScoped<CityBusinessRules>();


        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));


        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICityService, CityService>();
        services.AddScoped<IVenueService, VenueService>();
        services.AddScoped<IEventGroupService, EventGroupService>();
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<ITicketService, TicketService>();


        services.AddSingleton<IMailService, MailKitMailService>();
        services.AddSingleton<LoggerServiceBase, FileLogger>();
        services.AddSingleton<IElasticSearch, ElasticSearchService>();

        return services;
    }
}
