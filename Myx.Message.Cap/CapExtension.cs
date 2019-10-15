using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Myx.Message.Cap
{
    public static class CapExtension
    {
        public static IServiceCollection AddMyxCap(this IServiceCollection services, IConfiguration configuration)
        {
            var config = new CapConfig();
            configuration.Bind("CapConfig", config);

            if (config is null)
                throw new ArgumentNullException("CapConfig can not be null");

            services.AddCap(options => {
                options.UseInMemoryStorage();
                options.UseKafka(config.MqConnectionString);
                options.UseDashboard();
            });
            return services;
        }
    }
}
