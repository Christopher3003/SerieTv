using ITLATv.Application.Repositories;
using ITLATv.Application.Services;
using Microsoft.Extensions.DependencyInjection;


namespace ITLATv.Application
{
    public static class DependencyInyection
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            #region Repositories
            services.AddTransient<GenderRepository, GenderRepository>();
            services.AddTransient<ProducterRepository, ProducterRepository>();
            services.AddTransient<SerieRepository, SerieRepository>();
            #endregion
            #region Services
            services.AddTransient<GenderService, GenderService>();
            services.AddTransient<ProducterService, ProducterService>();
            services.AddTransient<SerieService, SerieService>();
            #endregion
        }
    }
}
