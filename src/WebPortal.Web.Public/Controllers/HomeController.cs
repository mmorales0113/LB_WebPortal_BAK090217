using Abp.Net.Mail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WebPortal.Web.Controllers;
using WebPortal.Web.Public.Models;

namespace WebPortal.Web.Public.Controllers
{
    public class HomeController : WebPortalControllerBase
    {
        private readonly IEmailSender _emailSender;

        public HomeController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Register(IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
               // _emailSender.SendAsync("mmoral21@gmail.com", L("EmailSecurityCodeSubject"), "Hello");

            }


            return RedirectToAction("Eonline", "Home");

        }
        public ActionResult Local()
        {
            return View();
        }
        public ActionResult Sites()
        {
            return View();
        }
        public ActionResult Employer()
        {
            return View();
        }
        public ActionResult Efaqs()
        {
            return View();
        }
        public ActionResult Eonline()
        {
            return View();
        }
        public ActionResult FormerParticipant()
        {
            return View();
        }
        public ActionResult Privacy()
        {
            return View();
        }
    }
}