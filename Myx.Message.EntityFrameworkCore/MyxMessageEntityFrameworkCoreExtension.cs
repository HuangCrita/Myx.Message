using Microsoft.Extensions.DependencyInjection;
using Myx.Message.Core.Entities;
using Myx.Message.Core.Repository;
using Myx.Message.EntityFrameworkCore.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Myx.Message.EntityFrameworkCore
{
    public static class MyxMessageEntityFrameworkCoreExtension
    {
        public static IServiceCollection AddMessageRepository(this IServiceCollection services)
        {
            services.AddTransient<IBaseRepository<SmsRecord, long>, BaseRepository<SmsRecord, long>>();
            return services;
        }
    }
}
