using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using pasaj.DataAccess.Data;
using pasaj.DataAccess.Repositories;
using pasaj.Service;
using pasaj.Service.MappingProfile;

namespace pasaj.Extensions
{
    public static class IoCExtensions
    {

        public static IServiceCollection AddNecessaryIoC(this IServiceCollection services, string connectionString)
        {

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, EFProductRepository>();
            services.AddScoped<ICategoryRepository, EFCategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(typeof(MapProfile));
            services.AddDbContext<PasajDataContext>(options => options.UseSqlServer(connectionString));

            return services;

        }
    }
}
