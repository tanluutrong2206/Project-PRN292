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
    public class ShopInformationsController : Controller
    {
        private readonly Family_MartContext _context;

        public ShopInformationsController(Family_MartContext context)
        {
            _context = context;
        }

        // GET: ShopInformations
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShopInformation.ToListAsync());
        }

        // GET: ShopInformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopInformation = await _context.ShopInformation
                .SingleOrDefaultAsync(m => m.Id == id);
            if (shopInformation == null)
            {
                return NotFound();
            }

            return View(shopInformation);
        }

        // GET: ShopInformations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShopInformations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Address,Email,Phone,Fax,Id")] ShopInformation shopInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shopInformation);
        }

        // GET: ShopInformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopInformation = await _context.ShopInformation.SingleOrDefaultAsync(m => m.Id == id);
            if (shopInformation == null)
            {
                return NotFound();
            }
            return View(shopInformation);
        }

        // POST: ShopInformations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Address,Email,Phone,Fax,Id")] ShopInformation shopInformation)
        {
            if (id != shopInformation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopInformationExists(shopInformation.Id))
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
            return View(shopInformation);
        }

        // GET: ShopInformations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopInformation = await _context.ShopInformation
                .SingleOrDefaultAsync(m => m.Id == id);
            if (shopInformation == null)
            {
                return NotFound();
            }

            return View(shopInformation);
        }

        // POST: ShopInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shopInformation = await _context.ShopInformation.SingleOrDefaultAsync(m => m.Id == id);
            _context.ShopInformation.Remove(shopInformation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopInformationExists(int id)
        {
            return _context.ShopInformation.Any(e => e.Id == id);
        }
    }
}
