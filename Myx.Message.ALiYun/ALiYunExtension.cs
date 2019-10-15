using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Myx.Message.ALiYun
{
    public static class ALiYunExtension
    {
        public static IServiceCollection AddALiYunClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ALiYunConfig>(options => {
                configuration.Bind("ALiYunConfig", options);
            });
            services.AddSingleton<IALiYunClient, ALiYunClient>();
            return services;
        }
    }
}
