using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PNT1_CartaResto.Models;

namespace PNT1_CartaResto.Controllers
{
    public class ReservaController : Controller
    {
        private readonly RestoContext _context;

        public ReservaController(RestoContext context)
        {
            _context = context;
        }

        // GET: Reserva
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reservas.ToListAsync());
        }

        // GET: Reserva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reserva/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reserva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mail,Comensales,Fecha,Tipo")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                reserva.Usuario = await _context.Usuarios.FirstOrDefaultAsync(m => m.Mail == reserva.Mail);



                var duplicada = _context.Reservas.Where(m => m.Mail == reserva.Mail && m.Fecha == reserva.Fecha).ToList().Count();
                if (duplicada > 0 )
                {
                    @ViewBag.error = "Usted ya tiene una reserva para la fecha " + reserva.Fecha.ToString("dd-MM-yyyy") + ".";
                }
                else
                {
                    var resto = await _context.Restaurants.FirstOrDefaultAsync();
                    var comensales = _context.Reservas
                        .Where(r => r.Fecha == reserva.Fecha)
                        .Sum(r => r.Comensales);

                    if (resto.CapacidadMax >= (comensales + reserva.Comensales))
                    {
                        _context.Add(reserva);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        @ViewBag.error = "La reserva excede la capacidad máxima del restaurant.";

                    }
                }
            }
            return View(reserva);
        }

        // GET: Reserva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }

        // POST: Reserva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Mail,Comensales,Fecha,Tipo")] Reserva reserva)
        {
            if (id != reserva.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    reserva.Usuario = await _context.Usuarios.FirstOrDefaultAsync(m => m.Mail == reserva.Mail);
                    var resto = await _context.Restaurants.FirstOrDefaultAsync();
                    var comensales = _context.Reservas
                        .Where(r => r.Fecha == reserva.Fecha && r.Id != reserva.Id)
                        .Sum(r => r.Comensales);
                    if (resto.CapacidadMax >= (comensales + reserva.Comensales))
                    {

                        _context.Update(reserva);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        @ViewBag.error = "La reserva excede la capacidad máxima del restaurant.";
                        return View(reserva);
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.Id))
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
            return View(reserva);
        }

        // GET: Reserva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.Id == id);
        }
    }
}
