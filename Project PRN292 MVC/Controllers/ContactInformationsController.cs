using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_PRN292_MVC.Models;

namespace Project_PRN292_MVC.Controllers
{
    public class ContactInformationsController : Controller
    {
        private readonly Family_MartContext _context;

        public ContactInformationsController(Family_MartContext context)
        {
            _context = context;
        }

        // GET: ContactInformations
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactInformations.ToListAsync());
        }

        // GET: ContactInformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactInformations = await _context.ContactInformations
                .SingleOrDefaultAsync(m => m.ContactInformationId == id);
            if (contactInformations == null)
            {
                return NotFound();
            }

            return View(contactInformations);
        }

        // GET: ContactInformations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactInformations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactInformationId,Name,Email,Subject,Message")] ContactInformations contactInformations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactInformations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactInformations);
        }

        // GET: ContactInformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactInformations = await _context.ContactInformations.SingleOrDefaultAsync(m => m.ContactInformationId == id);
            if (contactInformations == null)
            {
                return NotFound();
            }
            return View(contactInformations);
        }

        // POST: ContactInformations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactInformationId,Name,Email,Subject,Message")] ContactInformations contactInformations)
        {
            if (id != contactInformations.ContactInformationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactInformations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactInformationsExists(contactInformations.ContactInformationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contactInformations);
        }

        // GET: ContactInformations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactInformations = await _context.ContactInformations
                .SingleOrDefaultAsync(m => m.ContactInformationId == id);
            if (contactInformations == null)
            {
                return NotFound();
            }

            return View(contactInformations);
        }

        // POST: ContactInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactInformations = await _context.ContactInformations.SingleOrDefaultAsync(m => m.ContactInformationId == id);
            _context.ContactInformations.Remove(contactInformations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactInformationsExists(int id)
        {
            return _context.ContactInformations.Any(e => e.ContactInformationId == id);
        }
    }
}
