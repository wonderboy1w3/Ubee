using Ubee.Service.Services;
using Ubee.Data.Repositories;
using Ubee.Service.Interfaces;
using Ubee.Data.IRepositories;

namespace Ubee.Web.Extensions
{
	public static class ServiceExtension
	{
		public static void AddCustomService(this IServiceCollection services)
		{
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IWalletService, WalletService>();
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
			services.AddScoped<ICategoryDetailService, CategoryDetailService>();
		}
	}
}
