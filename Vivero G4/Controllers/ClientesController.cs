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
    public class ClientesController : Controller
    {
        private readonly ViveroContext _context;

        public ClientesController(ViveroContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,Nombre,Apellido,CorreoElectronico,Telefono,Contraseña,EsAdmin")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var ClienteBuscado = (from u in _context.Clientes
                                      where u.CorreoElectronico.Equals(cliente.CorreoElectronico)
                                      select u).FirstOrDefault<Cliente>();
                if (ClienteBuscado == null)
                {
                    _context.Add(cliente);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.errorMessage = "Usuario ya existente!";
                }
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioId,Nombre,Apellido,CorreoElectronico,Telefono,Contraseña,EsAdmin")] Cliente cliente)
        {
            if (id != cliente.UsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.UsuarioId))
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
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Clientes/IniciarSesion
        public IActionResult IniciarSesion()
        {
            return View();
        }

        // POST: Clientes/IniciarSesion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IniciarSesion([Bind("UsuarioId,Nombre,Apellido,CorreoElectronico,Telefono,Contraseña,EsAdmin")] Cliente cliente)
        {
            var clienteBuscado = (from u in _context.Clientes
                                  where u.CorreoElectronico.Equals(cliente.CorreoElectronico)
                                  select u).FirstOrDefault<Cliente>();
            if (clienteBuscado == null)
            {
                ViewBag.errorMessage = "Usuario no existente!";
            }
            else if (!clienteBuscado.Contraseña.Equals(cliente.Contraseña))
            {
                ViewBag.errorMessage = "Contraseña errónea!";
            }
            else
            {
                ViewBag.errorMessage = "Contraseña correcta!";
                return RedirectToAction(nameof(Index), "Home");
            }
            return View(cliente);
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.UsuarioId == id);
        }
    }
}
