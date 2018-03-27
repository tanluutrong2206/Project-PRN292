using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_PRN292_MVC.Models;

namespace Project_PRN292_MVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly Family_MartContext _context;

        public HomeController(Family_MartContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {
            AboutPage aboutPage = new AboutPage();
            aboutPage.Abouts = await _context.About.SingleOrDefaultAsync();
            aboutPage.Founders = await _context.Founders.ToListAsync();

            return View(aboutPage);
        }

        public async Task<IActionResult> Contact()
        {
            ContactPage contactPage = new ContactPage();
            contactPage.OpeningHours = await _context.OpeningHours.ToListAsync();
            contactPage.ShopInformation = await _context.ShopInformation.ToListAsync();
            contactPage.ContactInformation = new ContactInformations();
            return View(contactPage);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // POST: ContactInformations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("ContactInformationId,Name,Email,Subject,Message")] ContactInformations contactInformations)
        {
            if (ModelState.IsValid)
            {
                ViewData["Message"] = "Successfully";
                _context.Add(contactInformations);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Create", "ContactInformationsController", contactInformations);
            }
            return View(contactInformations);
        }
    }
}
