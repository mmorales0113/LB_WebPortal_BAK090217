using WebPortal.Sessions.Dto;

namespace WebPortal.Web.Areas.App.Models.Layout
{
    public class FooterViewModel
    {
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }

        public string GetProductNameWithEdition()
        {
            const string productName = "Web Portal";

            if (LoginInformations.Tenant == null)
            {
                return productName;
            }

            if (LoginInformations.Tenant.Edition == null)
            {
                return productName;
            }

            if (LoginInformations.Tenant.Edition.DisplayName == null)
            {
                return productName;
            }

            return productName + " " + LoginInformations.Tenant.Edition.DisplayName;
        }
    }
}