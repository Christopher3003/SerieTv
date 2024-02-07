using ITLATv.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ITLATv.Database
{
    public static class DependencyInyection
    {
        public static void AddDatabaseLayer(this IServiceCollection services, IConfiguration configuration)
        {
            #region ApplicationContext
            services.AddDbContext<ApplicationContext>(op => 
            op.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), m=>
            m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            #endregion
        }
    }
}
