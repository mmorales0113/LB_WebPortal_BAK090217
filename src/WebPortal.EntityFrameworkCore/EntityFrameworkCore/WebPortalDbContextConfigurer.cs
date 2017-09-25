using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebPortal.EntityFrameworkCore
{
    public static class WebPortalDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<WebPortalDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }
    }
}