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
    public class FoundersController : Controller
    {
        private readonly Family_MartContext _context;

        public FoundersController(Family_MartContext context)
        {
            _context = context;
        }

        // GET: Founders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Founders.ToListAsync());
        }

        // GET: Founders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var founders = await _context.Founders
                .SingleOrDefaultAsync(m => m.FounderId == id);
            if (founders == null)
            {
                return NotFound();
            }

            return View(founders);
        }

        // GET: Founders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Founders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Quote,ImageName,ContactLink,FounderId")] Founders founders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(founders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(founders);
        }

        // GET: Founders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var founders = await _context.Founders.SingleOrDefaultAsync(m => m.FounderId == id);
            if (founders == null)
            {
                return NotFound();
            }
            return View(founders);
        }

        // POST: Founders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Quote,ImageName,ContactLink,FounderId")] Founders founders)
        {
            if (id != founders.FounderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(founders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoundersExists(founders.FounderId))
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
            return View(founders);
        }

        // GET: Founders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var founders = await _context.Founders
                .SingleOrDefaultAsync(m => m.FounderId == id);
            if (founders == null)
            {
                return NotFound();
            }

            return View(founders);
        }

        // POST: Founders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var founders = await _context.Founders.SingleOrDefaultAsync(m => m.FounderId == id);
            _context.Founders.Remove(founders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoundersExists(int id)
        {
            return _context.Founders.Any(e => e.FounderId == id);
        }
    }
}
