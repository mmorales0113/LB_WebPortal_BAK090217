using System.Threading.Tasks;
using WebPortal.Security.Recaptcha;

namespace WebPortal.Tests.Web
{
    public class FakeRecaptchaValidator : IRecaptchaValidator
    {
        public async Task ValidateAsync(string captchaResponse)
        {
            
        }
    }
}
