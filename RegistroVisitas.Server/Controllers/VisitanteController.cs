using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RegistroVisitas.Server.Models;

namespace RegistroVisitas.Server.Controllers
{
    public class VisitanteController : Controller
    {
        private readonly RegistroVisitasContext _context;

        public VisitanteController(RegistroVisitasContext context)
        {
            _context = context;
        }

        // GET: Visitante
        public async Task<IActionResult> Index()
        {
              return _context.Visitantes != null ? 
                          View(await _context.Visitantes.ToListAsync()) :
                          Problem("Entity set 'RegistroVisitasContext.Visitantes'  is null.");
        }

        // GET: Visitante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Visitantes == null)
            {
                return NotFound();
            }

            var visitante = await _context.Visitantes
                .FirstOrDefaultAsync(m => m.Idvisita == id);
            if (visitante == null)
            {
                return NotFound();
            }

            return View(visitante);
        }

        // GET: Visitante/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Visitante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idvisita,Fechaingreso,Hora,Nombre,Cedula,Motivo,Departamento,Estado,Novedad")] Visitante visitante)
        {
            if (ModelState.IsValid)
            {
                // cambio para probar merge y cherry pick
                _context.Add(visitante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(visitante);
        }

        // GET: Visitante/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Visitantes == null)
            {
                return NotFound();
            }

            var visitante = await _context.Visitantes.FindAsync(id);
            if (visitante == null)
            {
                return NotFound();
            }
            return View(visitante);
        }

        // POST: Visitante/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idvisita,Fechaingreso,Hora,Nombre,Cedula,Motivo,Departamento,Estado,Novedad")] Visitante visitante)
        {
            if (id != visitante.Idvisita)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitanteExists(visitante.Idvisita))
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
            return View(visitante);
        }

        // GET: Visitante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Visitantes == null)
            {
                return NotFound();
            }

            var visitante = await _context.Visitantes
                .FirstOrDefaultAsync(m => m.Idvisita == id);
            if (visitante == null)
            {
                return NotFound();
            }

            return View(visitante);
        }

        // POST: Visitante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Visitantes == null)
            {
                return Problem("Entity set 'RegistroVisitasContext.Visitantes'  is null.");
            }
            var visitante = await _context.Visitantes.FindAsync(id);
            if (visitante != null)
            {
                _context.Visitantes.Remove(visitante);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitanteExists(int id)
        {
          return (_context.Visitantes?.Any(e => e.Idvisita == id)).GetValueOrDefault();
        }
    }
}
