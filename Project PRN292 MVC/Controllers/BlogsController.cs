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
    public class BlogsController : Controller
    {
        private readonly Family_MartContext _context;

        public BlogsController(Family_MartContext context)
        {
            _context = context;
        }

        // GET: Blogs
        public async Task<IActionResult> Index()
        {
            var family_MartContext = _context.Blogs.Include(b => b.Author);
            return View(await family_MartContext.ToListAsync());
        }

        // GET: Blogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogs = await _context.Blogs
                .Include(b => b.Author)
                .SingleOrDefaultAsync(m => m.BlogId == id);
            if (blogs == null)
            {
                return NotFound();
            }

            return View(blogs);
        }

        // GET: Blogs/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BlogId,Name,Content,DateCreated,AuthorId,ImageName")] Blogs blogs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blogs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", blogs.AuthorId);
            return View(blogs);
        }

        // GET: Blogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogs = await _context.Blogs.SingleOrDefaultAsync(m => m.BlogId == id);
            if (blogs == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", blogs.AuthorId);
            return View(blogs);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BlogId,Name,Content,DateCreated,AuthorId,ImageName")] Blogs blogs)
        {
            if (id != blogs.BlogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogsExists(blogs.BlogId))
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
            ViewData["AuthorId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", blogs.AuthorId);
            return View(blogs);
        }

        // GET: Blogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogs = await _context.Blogs
                .Include(b => b.Author)
                .SingleOrDefaultAsync(m => m.BlogId == id);
            if (blogs == null)
            {
                return NotFound();
            }

            return View(blogs);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogs = await _context.Blogs.SingleOrDefaultAsync(m => m.BlogId == id);
            _context.Blogs.Remove(blogs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogsExists(int id)
        {
            return _context.Blogs.Any(e => e.BlogId == id);
        }
    }
}
