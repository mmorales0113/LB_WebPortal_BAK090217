using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebPortal.Url;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Abp.Authorization;
using WebPortal.Web.Controllers;
using Microsoft.AspNetCore.Http.Extensions;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebPortal.Web.Public.Controllers
{
    [AbpAuthorize]
    public class DocsController : WebPortalControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public virtual string RawUrl { get; }
        public DocsController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Pension()
        {
            var FullLink = Request.GetDisplayUrl();

            string[] link = FullLink.Split('/');
            string webRootPath = _hostingEnvironment.WebRootPath;
            string contentRootPath = _hostingEnvironment.ContentRootPath;

            return PhysicalFile(Path.Combine(contentRootPath, "www", link[4] +"\\" + link[5]), "application/pdf");
        }
        public IActionResult HealthPlan()
        {
            var FullLink = Request.GetDisplayUrl();

            string[] link = FullLink.Split('/');
            string webRootPath = _hostingEnvironment.WebRootPath;
            string contentRootPath = _hostingEnvironment.ContentRootPath;

            return PhysicalFile(Path.Combine(contentRootPath, "www", link[4] + "\\" + link[5]), "application/pdf");
        }
        public IActionResult Disability()
        {
            var FullLink = Request.GetDisplayUrl();

            string[] link = FullLink.Split('/');
            string webRootPath = _hostingEnvironment.WebRootPath;
            string contentRootPath = _hostingEnvironment.ContentRootPath;

            return PhysicalFile(Path.Combine(contentRootPath, "www", link[4] + "\\" + link[5]), "application/pdf");
        }
        public IActionResult Vacation()
        {
            var FullLink = Request.GetDisplayUrl();

            string[] link = FullLink.Split('/');
            string webRootPath = _hostingEnvironment.WebRootPath;
            string contentRootPath = _hostingEnvironment.ContentRootPath;

            return PhysicalFile(Path.Combine(contentRootPath, "www", link[4] + "\\" + link[5]), "application/pdf");
        }
        public IActionResult Notices()
        {
            var FullLink = Request.GetDisplayUrl();

            string[] link = FullLink.Split('/');
            string webRootPath = _hostingEnvironment.WebRootPath;
            string contentRootPath = _hostingEnvironment.ContentRootPath;

            return PhysicalFile(Path.Combine(contentRootPath, "www", link[4] + "\\" + link[5]), "application/pdf");
        }

    }
}
