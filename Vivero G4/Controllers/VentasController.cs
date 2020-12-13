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
    public class VentasController : Controller
    {
        private readonly ViveroContext _context;

        public VentasController(ViveroContext context)
        {
            _context = context;
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            try
            {
                ViewData["Articulos"] = await _context.Articulos.ToListAsync();
                ViewData["Usuarios"] = await _context.Usuarios.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ModelState.AddModelError("", "No se pudo acceder a la base de datos.");
            }         
            return View(await _context.Ventas.ToListAsync());
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .FirstOrDefaultAsync(m => m.VentaId == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VentaId,NroTarjeta,FecVencimiento,CodSeguridad,Domicilio,TipoEntrega")] Venta venta)
        {
            try 
            {	        
                if (ModelState.IsValid)
                {
                    var ventaBuscada = (from u in _context.Ventas
                                    where u.VentaId.Equals(venta.VentaId)
                                    select u).FirstOrDefault<Venta>();
                    if (ventaBuscada == null)
                    {
                        venta.UsuarioId = Int16.Parse(TempData.Peek("usuarioId").ToString());
                        venta.ArticuloId = Int16.Parse(TempData.Peek("articuloVendidoId").ToString());
                        _context.Add(venta);
                        await _context.SaveChangesAsync();
                        ViewBag.message = "Su compra fue concretada con exito";
                        return View(venta);
                    } 
                    else
                    {
                        ViewBag.errorMessage = "La venta ya existe!";
                    }
                }
	        }
	        catch (DbUpdateException ex)
	        {   
                Console.WriteLine(ex.Message);
                ModelState.AddModelError("", "No se pudo acceder a la base de datos." +
                    " Intente de nuevo y si el problema persiste" +
                    " contacte con su administrador");
            }  
            return View(venta);
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VentaId,NroTarjeta,FecVencimiento,CodSeguridad,Domicilio,TipoEntrega")] Venta venta)
        {
            if (id != venta.VentaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaExists(venta.VentaId))
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
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                //.AsNoTracking
                .FirstOrDefaultAsync(m => m.VentaId == id);
            if (venta == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "No se pudo borrar la venta. Inténtalo nuevamente, y si el problema persiste" +
                    " contacte con su administrador";
            }

            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
	        {
                return RedirectToAction(nameof(Index));
	        }
            try 
	        {	        
		        _context.Ventas.Remove(venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
	        }
	        catch (DbUpdateException exception)
	        {
                Console.WriteLine(exception.Message);
                return RedirectToAction(nameof(Delete), new { id, saveChangesError = true });
	        }            
        }

        private bool VentaExists(int id)
        {
            return _context.Ventas.Any(e => e.VentaId == id);
        }
    }
}
