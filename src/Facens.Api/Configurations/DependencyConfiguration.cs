using Facens.Api.Extensions;
using Facens.Business.Interfaces;
using Facens.Business.Notifications;
using Facens.Business.Services;
using Facens.Data.Contexts;
using Facens.Data.Repositories;
using Microsoft.Extensions.Options;
using static Facens.Api.Configurations.SwaggerConfiguration;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Facens.Api.Configurations
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();
            services.AddScoped<ISolicitacaoRepository, SolicitacaoRepository>();
            services.AddScoped<ICidadaoRepository, CidadaoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<INotificator, Notificator>();

            services.AddScoped<ISolicitacaoService, SolicitacaoService>();
            services.AddScoped<ICidadaoService, CidadaoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUsuario, AspNetUsuario>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
