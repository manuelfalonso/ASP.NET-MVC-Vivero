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
    public class AdministradorController : Controller
    {
        private readonly ViveroContext _context;

        public AdministradorController(ViveroContext context)
        {
            _context = context;
        }

        // GET: Administrador
        public async Task<IActionResult> Index()
        {
            return View(await _context.Administradores.ToListAsync());
        }

        // GET: Administrador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administradores
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (administrador == null)
            {
                return NotFound();
            }

            return View(administrador);
        }

        // GET: Administrador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administrador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,Nombre,Apellido,CorreoElectronico,Telefono,Contraseña,EsAdmin")] Administrador administrador)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = (from u in _context.Usuario
                                   where u.CorreoElectronico.Equals(administrador.CorreoElectronico)
                                   select u).FirstOrDefault<Usuario>();
                    if (usuario == null)
                    {
                        _context.Add(administrador);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {                        
                        ViewBag.errorMessage = "algo malió sal!";
                    }
                }
            }
            catch (DbUpdateException ex)
            {                
                Console.WriteLine(ex.Message);
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            return View(administrador);
        }

        // GET: Administrador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administradores.FindAsync(id);
            if (administrador == null)
            {
                return NotFound();
            }
            return View(administrador);
        }

        // POST: Administrador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioId,Nombre,Apellido,CorreoElectronico,Telefono,Contraseña,EsAdmin")] Administrador administrador)
        {

            if (id != administrador.UsuarioId)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administrador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministradorExists(administrador.UsuarioId))
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
            return View(administrador);
        }

        // GET: Administrador/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administradores
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (administrador == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "No se pudo borrar el Usuario. Inténtalo nuevamente, y si el problema persiste " +
                    "contacte con su administrador.";
            }

            return View(administrador);
        }

        // POST: Administrador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
          
            var administrador = await _context.Administradores.FindAsync(id);
            if(administrador == null)
            {
               return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Administradores.Remove(administrador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException exception)
            {
                Console.WriteLine(exception.Message);
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }


         }

        private bool AdministradorExists(int id)
        {
            return _context.Administradores.Any(e => e.UsuarioId == id);
        }
    }
}
