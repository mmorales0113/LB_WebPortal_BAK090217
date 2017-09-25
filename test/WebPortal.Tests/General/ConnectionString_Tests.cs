using System.Data.SqlClient;
using Shouldly;
using Xunit;

namespace WebPortal.Tests.General
{
    public class ConnectionString_Tests
    {
        [Fact]
        public void SqlConnectionStringBuilder_Test()
        {
            var csb = new SqlConnectionStringBuilder("Server=localhost; Database=WebPortal; Trusted_Connection=True;");
            csb["Database"].ShouldBe("WebPortal");
        }
    }
}
