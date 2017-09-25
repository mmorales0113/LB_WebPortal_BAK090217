using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using WebPortal.Configuration;
using WebPortal.Web;

namespace WebPortal.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class WebPortalDbContextFactory : IDbContextFactory<WebPortalDbContext>
    {
        public WebPortalDbContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<WebPortalDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            WebPortalDbContextConfigurer.Configure(builder, configuration.GetConnectionString(WebPortalConsts.ConnectionStringName));
            
            return new WebPortalDbContext(builder.Options);
        }
    }
}