using Microsoft.AspNetCore.Cors.Infrastructure;
using Ubee.Data.IRepositories;
using Ubee.Data.Repositories;

namespace Ubee.Api.Extensions;
public static class ServiceExtension
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

    }
}
