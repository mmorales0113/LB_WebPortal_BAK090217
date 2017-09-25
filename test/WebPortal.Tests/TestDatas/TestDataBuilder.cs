using WebPortal.EntityFrameworkCore;

namespace WebPortal.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly WebPortalDbContext _context;
        private readonly int _tenantId;

        public TestDataBuilder(WebPortalDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            new TestOrganizationUnitsBuilder(_context, _tenantId).Create();
            new TestSubscriptionPaymentBuilder(_context, _tenantId).Create();

            _context.SaveChanges();
        }
    }
}
