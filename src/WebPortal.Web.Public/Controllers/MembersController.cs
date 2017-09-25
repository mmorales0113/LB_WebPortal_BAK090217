using Microsoft.AspNetCore.Mvc;
using WebPortal.Web.Controllers;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Authorization;
using System.Threading.Tasks;
using Abp.MultiTenancy;
using WebPortal.Authorization;

namespace WebPortal.Web.Public.Controllers
{

    
    public class MembersController : WebPortalControllerBase
    {
        //Health Plan Information Start
        [AbpAuthorize]
        public ActionResult HealthPlan()
        {
            return View();
        }
        public ActionResult EligibilityProvisions()
        {
            return View();
        }
        public ActionResult DeathBenefit()
        {
            return View();
        }
        public ActionResult Cobra()
        {
            return View();
        }
        public ActionResult DisabilityExtension()
        {
            return View();
        }
        public ActionResult ClaremontEAP()
        {
            return View();
        }
        public ActionResult SelfPay()
        {
            return View();
        }
        public ActionResult HealthReference()
        {
            return View();
        }
        public ActionResult HealthForms()
        {
            return View();
        }
        public ActionResult ParticipantPortal()
        {
            return View();
        }

        //Health Plan End
        //Pension Start
        public ActionResult Pension()
        {
            return View();
        }
        public ActionResult PensionReference()
        {
            return View();
        }
        public ActionResult PensionFaqs()
        {
            return View();
        }
        public ActionResult PensionForms()
        {
            return View();
        }
        //Pension End
        public ActionResult Notices()
        {
            return View();
        }

    }
}