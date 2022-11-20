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
    public class SchoolModelsController : Controller
    {
        private readonly AplicationMvcSimpleContext _context;

        public SchoolModelsController(AplicationMvcSimpleContext context)
        {
            _context = context;
        }

        // GET: SchoolModels
        public async Task<IActionResult> Index()
        {
              return View(await _context.SchoolModel.ToListAsync());
        }

        // GET: SchoolModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SchoolModel == null)
            {
                return NotFound();
            }

            var schoolModel = await _context.SchoolModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schoolModel == null)
            {
                return NotFound();
            }

            return View(schoolModel);
        }

        // GET: SchoolModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SchoolModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Enrrolment,Teacher,Management,EnrrollmentDate")] SchoolModel schoolModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schoolModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schoolModel);
        }

        // GET: SchoolModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SchoolModel == null)
            {
                return NotFound();
            }

            var schoolModel = await _context.SchoolModel.FindAsync(id);
            if (schoolModel == null)
            {
                return NotFound();
            }
            return View(schoolModel);
        }

        // POST: SchoolModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Enrrolment,Teacher,Management,EnrrollmentDate")] SchoolModel schoolModel)
        {
            if (id != schoolModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schoolModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolModelExists(schoolModel.Id))
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
            return View(schoolModel);
        }

        // GET: SchoolModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SchoolModel == null)
            {
                return NotFound();
            }

            var schoolModel = await _context.SchoolModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schoolModel == null)
            {
                return NotFound();
            }

            return View(schoolModel);
        }

        // POST: SchoolModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SchoolModel == null)
            {
                return Problem("Entity set 'AplicationMvcSimpleContext.SchoolModel'  is null.");
            }
            var schoolModel = await _context.SchoolModel.FindAsync(id);
            if (schoolModel != null)
            {
                _context.SchoolModel.Remove(schoolModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolModelExists(int id)
        {
          return _context.SchoolModel.Any(e => e.Id == id);
        }
    }
}
