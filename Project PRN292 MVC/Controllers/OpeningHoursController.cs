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
    public class OpeningHoursController : Controller
    {
        private readonly Family_MartContext _context;

        public OpeningHoursController(Family_MartContext context)
        {
            _context = context;
        }

        // GET: OpeningHours
        public async Task<IActionResult> Index()
        {
            return View(await _context.OpeningHours.ToListAsync());
        }

        // GET: OpeningHours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var openingHours = await _context.OpeningHours
                .SingleOrDefaultAsync(m => m.Id == id);
            if (openingHours == null)
            {
                return NotFound();
            }

            return View(openingHours);
        }

        // GET: OpeningHours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OpeningHours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WeekDays,Saturday,Sunday,Id")] OpeningHours openingHours)
        {
            if (ModelState.IsValid)
            {
                _context.Add(openingHours);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(openingHours);
        }

        // GET: OpeningHours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var openingHours = await _context.OpeningHours.SingleOrDefaultAsync(m => m.Id == id);
            if (openingHours == null)
            {
                return NotFound();
            }
            return View(openingHours);
        }

        // POST: OpeningHours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WeekDays,Saturday,Sunday,Id")] OpeningHours openingHours)
        {
            if (id != openingHours.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(openingHours);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpeningHoursExists(openingHours.Id))
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
            return View(openingHours);
        }

        // GET: OpeningHours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var openingHours = await _context.OpeningHours
                .SingleOrDefaultAsync(m => m.Id == id);
            if (openingHours == null)
            {
                return NotFound();
            }

            return View(openingHours);
        }

        // POST: OpeningHours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var openingHours = await _context.OpeningHours.SingleOrDefaultAsync(m => m.Id == id);
            _context.OpeningHours.Remove(openingHours);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpeningHoursExists(int id)
        {
            return _context.OpeningHours.Any(e => e.Id == id);
        }
    }
}
