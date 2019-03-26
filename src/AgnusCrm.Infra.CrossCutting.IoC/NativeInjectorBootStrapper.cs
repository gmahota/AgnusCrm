using AgnusCrm.Application.Interfaces;
using AgnusCrm.Application.Services;
using AgnusCrm.Domain.CommandHandlers;
using AgnusCrm.Domain.Commands;
using AgnusCrm.Domain.Core.Bus;
using AgnusCrm.Domain.Core.Events;
using AgnusCrm.Domain.Core.Notifications;
using AgnusCrm.Domain.EventHandlers;
using AgnusCrm.Domain.Events;
using AgnusCrm.Domain.Interfaces;
using AgnusCrm.Infra.CrossCutting.Bus;
using AgnusCrm.Infra.CrossCutting.Identity.Authorization;
using AgnusCrm.Infra.CrossCutting.Identity.Models;
using AgnusCrm.Infra.CrossCutting.Identity.Services;
using AgnusCrm.Infra.Data.Context;
using AgnusCrm.Infra.Data.EventSourcing;
using AgnusCrm.Infra.Data.Repository;
using AgnusCrm.Infra.Data.Repository.EventSourcing;
using AgnusCrm.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AgnusCrm.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewCustomerCommand, bool>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCustomerCommand, bool>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCustomerCommand, bool>, CustomerCommandHandler>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<AgnusCrmContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}