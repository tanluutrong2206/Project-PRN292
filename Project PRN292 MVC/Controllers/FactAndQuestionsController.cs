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
    public class FactAndQuestionsController : Controller
    {
        private readonly Family_MartContext _context;

        public FactAndQuestionsController(Family_MartContext context)
        {
            _context = context;
        }

        // GET: FactAndQuestions
        public async Task<IActionResult> Index()
        {
            return View(await _context.FactAndQuestions.ToListAsync());
        }

        // GET: FactAndQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factAndQuestions = await _context.FactAndQuestions
                .SingleOrDefaultAsync(m => m.FaQid == id);
            if (factAndQuestions == null)
            {
                return NotFound();
            }

            return View(factAndQuestions);
        }

        // GET: FactAndQuestions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FactAndQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Content,FaQid")] FactAndQuestions factAndQuestions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factAndQuestions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(factAndQuestions);
        }

        // GET: FactAndQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factAndQuestions = await _context.FactAndQuestions.SingleOrDefaultAsync(m => m.FaQid == id);
            if (factAndQuestions == null)
            {
                return NotFound();
            }
            return View(factAndQuestions);
        }

        // POST: FactAndQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Content,FaQid")] FactAndQuestions factAndQuestions)
        {
            if (id != factAndQuestions.FaQid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factAndQuestions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactAndQuestionsExists(factAndQuestions.FaQid))
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
            return View(factAndQuestions);
        }

        // GET: FactAndQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factAndQuestions = await _context.FactAndQuestions
                .SingleOrDefaultAsync(m => m.FaQid == id);
            if (factAndQuestions == null)
            {
                return NotFound();
            }

            return View(factAndQuestions);
        }

        // POST: FactAndQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var factAndQuestions = await _context.FactAndQuestions.SingleOrDefaultAsync(m => m.FaQid == id);
            _context.FactAndQuestions.Remove(factAndQuestions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactAndQuestionsExists(int id)
        {
            return _context.FactAndQuestions.Any(e => e.FaQid == id);
        }
    }
}
