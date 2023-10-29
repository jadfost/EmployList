using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practica.Models;

namespace Practica.Controllers
{
    public class ExperienciaLaboralsController : Controller
    {
        private readonly PruebaContext _context;

        public ExperienciaLaboralsController(PruebaContext context)
        {
            _context = context;
        }

        // GET: ExperienciaLaborals
        public async Task<IActionResult> Index()
        {
            var pruebaContext = _context.ExperienciaLaborals.Include(e => e.Empleado);
            return View(await pruebaContext.ToListAsync());
        }

        // GET: ExperienciaLaborals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExperienciaLaborals == null)
            {
                return NotFound();
            }

            var experienciaLaboral = await _context.ExperienciaLaborals
                .Include(e => e.Empleado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experienciaLaboral == null)
            {
                return NotFound();
            }

            return View(experienciaLaboral);
        }

        // GET: ExperienciaLaborals/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Id");
            return View();
        }

        // POST: ExperienciaLaborals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmpleadoId,Empresa,Cargo")] ExperienciaLaboral experienciaLaboral)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experienciaLaboral);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Id", experienciaLaboral.EmpleadoId);
            return View(experienciaLaboral);
        }

        // GET: ExperienciaLaborals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExperienciaLaborals == null)
            {
                return NotFound();
            }

            var experienciaLaboral = await _context.ExperienciaLaborals.FindAsync(id);
            if (experienciaLaboral == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Id", experienciaLaboral.EmpleadoId);
            return View(experienciaLaboral);
        }

        // POST: ExperienciaLaborals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmpleadoId,Empresa,Cargo")] ExperienciaLaboral experienciaLaboral)
        {
            if (id != experienciaLaboral.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experienciaLaboral);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperienciaLaboralExists(experienciaLaboral.Id))
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Id", experienciaLaboral.EmpleadoId);
            return View(experienciaLaboral);
        }

        // GET: ExperienciaLaborals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExperienciaLaborals == null)
            {
                return NotFound();
            }

            var experienciaLaboral = await _context.ExperienciaLaborals
                .Include(e => e.Empleado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experienciaLaboral == null)
            {
                return NotFound();
            }

            return View(experienciaLaboral);
        }

        // POST: ExperienciaLaborals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExperienciaLaborals == null)
            {
                return Problem("Entity set 'PruebaContext.ExperienciaLaborals'  is null.");
            }
            var experienciaLaboral = await _context.ExperienciaLaborals.FindAsync(id);
            if (experienciaLaboral != null)
            {
                _context.ExperienciaLaborals.Remove(experienciaLaboral);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExperienciaLaboralExists(int id)
        {
          return (_context.ExperienciaLaborals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
