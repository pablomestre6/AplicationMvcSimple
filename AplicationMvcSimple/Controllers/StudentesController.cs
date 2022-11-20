using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AplicationMvcSimple.Data;
using AplicationMvcSimple.Models;

namespace AplicationMvcSimple.Controllers
{
    public class StudentesController : Controller
    {
        private readonly AplicationMvcSimpleContext _context;

        public StudentesController(AplicationMvcSimpleContext context)
        {
            _context = context;
        }

        // GET: Studentes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Studentes.ToListAsync());
        }

        // GET: Studentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Studentes == null)
            {
                return NotFound();
            }

            var studentes = await _context.Studentes
                .FirstOrDefaultAsync(m => m.id == id);
            if (studentes == null)
            {
                return NotFound();
            }

            return View(studentes);
        }

        // GET: Studentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Studentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Students,StudentName,Enrrolment,Grades,BirthDate,EnrrollmentDate")] Studentes studentes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentes);
        }

        // GET: Studentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Studentes == null)
            {
                return NotFound();
            }

            var studentes = await _context.Studentes.FindAsync(id);
            if (studentes == null)
            {
                return NotFound();
            }
            return View(studentes);
        }

        // POST: Studentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Students,StudentName,Enrrolment,Grades,BirthDate,EnrrollmentDate")] Studentes studentes)
        {
            if (id != studentes.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentesExists(studentes.id))
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
            return View(studentes);
        }

        // GET: Studentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Studentes == null)
            {
                return NotFound();
            }

            var studentes = await _context.Studentes
                .FirstOrDefaultAsync(m => m.id == id);
            if (studentes == null)
            {
                return NotFound();
            }

            return View(studentes);
        }

        // POST: Studentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Studentes == null)
            {
                return Problem("Entity set 'AplicationMvcSimpleContext.Studentes'  is null.");
            }
            var studentes = await _context.Studentes.FindAsync(id);
            if (studentes != null)
            {
                _context.Studentes.Remove(studentes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentesExists(int id)
        {
          return _context.Studentes.Any(e => e.id == id);
        }
    }
}
