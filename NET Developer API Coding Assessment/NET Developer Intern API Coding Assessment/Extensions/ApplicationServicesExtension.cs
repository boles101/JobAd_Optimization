using NET_Developer_Intern_API_Coding_Assessment.Interface;
using NET_Developer_Intern_API_Coding_Assessment.Interfaces;
using NET_Developer_Intern_API_Coding_Assessment.Services;

namespace NET_Developer_Intern_API_Coding_Assessment.Extensions
{
    static class ApplicationServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Added json enum converter to handle the enum default 0 based configuration..
            services.AddControllers()
                  .AddJsonOptions(o =>
                    {
                        o.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
                   });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Service registery in the dependency injecttion Container...
            services.AddScoped<IAdOtimizer, AdOptimizer>(); 
            services.AddScoped<IPlatformServices,PlatformServices>();

            return services;
        }


    }
}
