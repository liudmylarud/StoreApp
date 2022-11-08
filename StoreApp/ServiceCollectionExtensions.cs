using StoreApp.Services;

namespace StoreApp
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ProductsService>();
        }
    }
}
