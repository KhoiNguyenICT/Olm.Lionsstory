using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Olm.Model.Entities;
using Olm.Service.Interfaces;
using Olm.Web.Extensions;
using Olm.Web.Models;

namespace Olm.Web.Controllers
{
    public class ContactController : BaseController
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [AllowAnonymous]
        public IActionResult Index(string utmSource, string utmTeam,
            string utmAgent, string utmTerm,
            string utmCampaign, string utmMedium,
            string keyword, string utmAdset, string utmAds)
        {
            ViewBag.QueryString = Request.QueryString;
            ViewBag.utmSource = utmSource;
            ViewBag.utmTeam = utmTeam;
            ViewBag.utmAgent = utmAgent;
            ViewBag.utmTerm = utmTerm;
            ViewBag.utmCampaign = utmCampaign;
            ViewBag.utmMedium = utmMedium;
            ViewBag.keyword = keyword;
            ViewBag.utmAdset = utmAdset;
            ViewBag.utmAds = utmAds;
            return View();
        }

        [AllowAnonymous]
        public IActionResult Success()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CollectContact(ContactViewModel contactViewModel)
        {
            var entity = contactViewModel.To<Contact>();
            await _contactService.Add(entity);
            return RedirectToAction("Success", "Contact");
        }

        public async Task<IActionResult> Manager()
        {
            ViewBag.Contacts = await _contactService.GetAll();
            return View();
        }
    }
}