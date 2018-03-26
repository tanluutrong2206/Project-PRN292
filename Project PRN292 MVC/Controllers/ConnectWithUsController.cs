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
    public class ConnectWithUsController : Controller
    {
        private readonly Family_MartContext _context;

        public ConnectWithUsController(Family_MartContext context)
        {
            _context = context;
        }

        // GET: ConnectWithUs
        public async Task<IActionResult> Index()
        {
            return View(await _context.ConnectWithUs.ToListAsync());
        }

        // GET: ConnectWithUs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var connectWithUs = await _context.ConnectWithUs
                .SingleOrDefaultAsync(m => m.Id == id);
            if (connectWithUs == null)
            {
                return NotFound();
            }

            return View(connectWithUs);
        }

        // GET: ConnectWithUs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConnectWithUs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Host,Link,Id")] ConnectWithUs connectWithUs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(connectWithUs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(connectWithUs);
        }

        // GET: ConnectWithUs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var connectWithUs = await _context.ConnectWithUs.SingleOrDefaultAsync(m => m.Id == id);
            if (connectWithUs == null)
            {
                return NotFound();
            }
            return View(connectWithUs);
        }

        // POST: ConnectWithUs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Host,Link,Id")] ConnectWithUs connectWithUs)
        {
            if (id != connectWithUs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(connectWithUs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConnectWithUsExists(connectWithUs.Id))
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
            return View(connectWithUs);
        }

        // GET: ConnectWithUs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var connectWithUs = await _context.ConnectWithUs
                .SingleOrDefaultAsync(m => m.Id == id);
            if (connectWithUs == null)
            {
                return NotFound();
            }

            return View(connectWithUs);
        }

        // POST: ConnectWithUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var connectWithUs = await _context.ConnectWithUs.SingleOrDefaultAsync(m => m.Id == id);
            _context.ConnectWithUs.Remove(connectWithUs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConnectWithUsExists(int id)
        {
            return _context.ConnectWithUs.Any(e => e.Id == id);
        }
    }
}
