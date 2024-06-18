using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Controllers
{
    public class YouthsController : Controller
    {
        private readonly SchoolContext _context;

        public YouthsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Youths
        public async Task<IActionResult> Index()
        {
              return _context.Youth != null ? 
                          View(await _context.Youth.ToListAsync()) :
                          Problem("Entity set 'SchoolContext.Youth'  is null.");
        }

        // GET: Youths/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Youth == null)
            {
                return NotFound();
            }

            var youth = await _context.Youth
                .FirstOrDefaultAsync(m => m.YouthId == id);
            if (youth == null)
            {
                return NotFound();
            }

            return View(youth);
        }

        // GET: Youths/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Youths/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YouthId,YouthName")] Youth youth)
        {
            if (ModelState.IsValid)
            {
                _context.Add(youth);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(youth);
        }

        // GET: Youths/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Youth == null)
            {
                return NotFound();
            }

            var youth = await _context.Youth.FindAsync(id);
            if (youth == null)
            {
                return NotFound();
            }
            return View(youth);
        }

        // POST: Youths/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("YouthId,YouthName")] Youth youth)
        {
            if (id != youth.YouthId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(youth);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YouthExists(youth.YouthId))
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
            return View(youth);
        }

        // GET: Youths/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Youth == null)
            {
                return NotFound();
            }

            var youth = await _context.Youth
                .FirstOrDefaultAsync(m => m.YouthId == id);
            if (youth == null)
            {
                return NotFound();
            }

            return View(youth);
        }

        // POST: Youths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Youth == null)
            {
                return Problem("Entity set 'SchoolContext.Youth'  is null.");
            }
            var youth = await _context.Youth.FindAsync(id);
            if (youth != null)
            {
                _context.Youth.Remove(youth);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YouthExists(int id)
        {
          return (_context.Youth?.Any(e => e.YouthId == id)).GetValueOrDefault();
        }
    }
}
