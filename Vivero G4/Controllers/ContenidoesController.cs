using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vivero_G4.Context;
using Vivero_G4.Models;

namespace Vivero_G4.Controllers
{
    public class ContenidoesController : Controller
    {
        private readonly ViveroContext _context;

        public ContenidoesController(ViveroContext context)
        {
            _context = context;
        }

        // GET: Contenidoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contenidos.ToListAsync());
        }

        // GET: Contenidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contenido = await _context.Contenidos
                .FirstOrDefaultAsync(m => m.ContenidoId == id);
            if (contenido == null)
            {
                return NotFound();
            }

            return View(contenido);
        }

        // GET: Contenidoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contenidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContenidoId,Titulo,Fecha,Texto")] Contenido contenido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contenido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contenido);
        }

        // GET: Contenidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contenido = await _context.Contenidos.FindAsync(id);
            if (contenido == null)
            {
                return NotFound();
            }
            return View(contenido);
        }

        // POST: Contenidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContenidoId,Titulo,Fecha,Texto")] Contenido contenido)
        {
            if (id != contenido.ContenidoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contenido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContenidoExists(contenido.ContenidoId))
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
            return View(contenido);
        }

        // GET: Contenidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contenido = await _context.Contenidos
                .FirstOrDefaultAsync(m => m.ContenidoId == id);
            if (contenido == null)
            {
                return NotFound();
            }

            return View(contenido);
        }

        // POST: Contenidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contenido = await _context.Contenidos.FindAsync(id);
            _context.Contenidos.Remove(contenido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContenidoExists(int id)
        {
            return _context.Contenidos.Any(e => e.ContenidoId == id);
        }
    }
}
