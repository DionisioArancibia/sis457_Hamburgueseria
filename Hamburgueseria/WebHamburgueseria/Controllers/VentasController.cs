﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebHamburgueseria.Models;
using System.Linq;
using System.Threading.Tasks;

namespace WebHamburgueseria.Controllers
{
    public class VentasController : Controller
    {
        private readonly LabHamburgueseriaContext _context;

        public VentasController(LabHamburgueseriaContext context)
        {
            _context = context;
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            var ventas = _context.Venta.Where(x => x.Estado != -1).Include(v => v.IdUsuarioNavigation);
            return View(await ventas.ToListAsync());
        }

        // GET: Ventas/NuevaVenta
        public IActionResult NuevaVenta()
        {
            ViewData["Productos"] = _context.Productos
                .Where(p => p.Estado == 1 && p.Stock > 0)
                .Select(p => new
                {
                    p.IdProducto,
                    p.Nombre,
                    p.PrecioVenta,
                    p.Stock
                }).ToList();

            return View();
        }

        // Buscar cliente por documento
        [Route("Ventas/BuscarCliente")]
        [HttpGet]
        public JsonResult BuscarCliente(string documento)
        {
            var cliente = _context.Clientes
                .Where(c => c.Documento == documento)
                .Select(c => new
                {
                    c.NombreCompleto
                })
                .FirstOrDefault();

            if (cliente == null)
            {
                return Json(new { success = false, message = "Cliente no encontrado" });
            }

            return Json(new { success = true, cliente });
        }

        // Buscar producto por código
[HttpGet]
public JsonResult BuscarProducto(string codigo = null, int? idProducto = null)
{
    if (string.IsNullOrWhiteSpace(codigo) && idProducto == null)
    {
        return Json(new { success = false, message = "Debe proporcionar un código o un ID de producto." });
    }

    var producto = _context.Productos
        .Where(p => p.Estado == 1 && 
                    (p.Codigo == codigo || p.IdProducto == idProducto)) // Filtra por código o ID
        .Select(p => new
        {
            p.IdProducto, // Asegúrate de incluir el IdProducto para usarlo al registrar la venta
            p.Nombre,
            p.Descripcion,
            p.PrecioVenta,
            p.Stock
        })
        .FirstOrDefault();

    if (producto == null)
    {
        return Json(new { success = false, message = "Producto no encontrado." });
    }

    return Json(new { success = true, producto });
}





        // POST: Ventas/RegistrarVenta
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarVenta([FromBody] Ventum nuevaVenta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = "Los datos enviados no son válidos." });
            }

            if (nuevaVenta.VentaDetalles == null || !nuevaVenta.VentaDetalles.Any())
            {
                return BadRequest(new { success = false, message = "Debe incluir al menos un producto en la venta." });
            }

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Registrar la venta
                    nuevaVenta.FechaRegistro = DateTime.Now;
                    nuevaVenta.UsuarioRegistro = User.Identity.Name;
                    nuevaVenta.Estado = 1;
                    _context.Venta.Add(nuevaVenta);
                    await _context.SaveChangesAsync();

                    // Procesar los detalles de la venta
                    foreach (var detalle in nuevaVenta.VentaDetalles)
                    {
                        // Convertir Código a IdProducto si es necesario
                        var producto = await _context.Productos
                            .FirstOrDefaultAsync(p => p.Codigo == detalle.IdProducto.ToString());

                        if (producto == null)
                        {
                            return BadRequest(new { success = false, message = $"Producto con código {detalle.IdProducto} no encontrado." });
                        }

                        detalle.IdProducto = producto.IdProducto; // Asignar el ID real
                        detalle.IdVenta = nuevaVenta.IdVenta;
                        detalle.FechaRegistro = DateTime.Now;
                        detalle.UsuarioRegistro = nuevaVenta.UsuarioRegistro;
                        detalle.Estado = 1;

                        _context.VentaDetalles.Add(detalle);
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return Ok(new { success = true, message = "Venta registrada exitosamente." });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return BadRequest(new { success = false, message = "Error al registrar la venta.", error = ex.Message });
                }
            }
        }


        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventum = await _context.Venta
                .Include(v => v.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdVenta == id);
            if (ventum == null)
            {
                return NotFound();
            }

            return View(ventum);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVenta,IdUsuario,TipoDocumento,DocumentoCliente,NombreCliente,MontoPago,MontoCambio,MontoTotal,UsuarioRegistro,FechaRegistro,Estado")] Ventum ventum)
        {
            if (!string.IsNullOrEmpty(ventum.TipoDocumento) && !string.IsNullOrEmpty(ventum.DocumentoCliente))
            {
                ventum.UsuarioRegistro = User.Identity.Name;
                ventum.FechaRegistro = DateTime.Now;
                ventum.Estado = 1;
                _context.Add(ventum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", ventum.IdUsuario);
            return View(ventum);
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventum = await _context.Venta.FindAsync(id);
            if (ventum == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", ventum.IdUsuario);
            return View(ventum);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVenta,IdUsuario,TipoDocumento,DocumentoCliente,NombreCliente,MontoPago,MontoCambio,MontoTotal,UsuarioRegistro,FechaRegistro,Estado")] Ventum ventum)
        {
            if (id != ventum.IdVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentumExists(ventum.IdVenta))
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
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", ventum.IdUsuario);
            return View(ventum);
        }

        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventum = await _context.Venta
                .Include(v => v.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdVenta == id);
            if (ventum == null)
            {
                return NotFound();
            }

            return View(ventum);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventum = await _context.Venta.FindAsync(id);
            if (ventum != null)
            {
                ventum.UsuarioRegistro = User.Identity.Name; ;
                ventum.Estado = -1;
                //_context.Venta.Remove(ventum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentumExists(int id)
        {
            return _context.Venta.Any(e => e.IdVenta == id);
        }
    }



}

