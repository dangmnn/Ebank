using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBank.Domain.Extention
{
    public static class MigrationExtention
    {
        public static void ConfigMigration<TDbContext>(this IApplicationBuilder app) where TDbContext : DbContext
        {
            try
            {
                using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                    .CreateScope();
                serviceScope.ServiceProvider.GetService<TDbContext>().Database.Migrate();
            }
            catch (Exception ex)
            {
                //log ra file
                Console.WriteLine($"{DateTime.UtcNow.AddHours(7).ToString("yyyy-MM-dd HH:mm:ss.fff")}||fail: TradeMap.Data.Migrations.MigrationExtension[0]\n{ex.ToString()}");
            }
        }
    }
}
