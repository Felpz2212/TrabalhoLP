using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital_.Models;

namespace Hospital_.Controllers
{
    public class ConsultasController : Controller
    {
        private readonly Contexto _context;

        public ConsultasController(Contexto context)
        {
            _context = context;
        }

        // GET: Consultas
        public async Task<IActionResult> Index()
        {
            var contexto = _context.consultas.Include(c => c.medicamento).Include(c => c.medico).Include(c => c.paciente);
            return View(await contexto.ToListAsync());
        }

        // GET: Consultas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.consultas == null)
            {
                return NotFound();
            }

            var consulta = await _context.consultas
                .Include(c => c.medicamento)
                .Include(c => c.medico)
                .Include(c => c.paciente)
                .FirstOrDefaultAsync(m => m.id == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // GET: Consultas/Create
        public IActionResult Create()
        {
            ViewData["medicamentoid"] = new SelectList(_context.medicamentos, "id", "nome");
            ViewData["medicoid"] = new SelectList(_context.medicos, "id", "nome");
            ViewData["pacienteid"] = new SelectList(_context.pacientes, "id", "nome");
            return View();
        }

        // POST: Consultas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,data,pacienteid,medicoid,medicamentoid")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consulta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["medicamentoid"] = new SelectList(_context.medicamentos, "id", "nome", consulta.medicamentoid);
            ViewData["medicoid"] = new SelectList(_context.medicos, "id", "nome", consulta.medicoid);
            ViewData["pacienteid"] = new SelectList(_context.pacientes, "id", "nome", consulta.pacienteid);
            return View(consulta);
        }

        // GET: Consultas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.consultas == null)
            {
                return NotFound();
            }

            var consulta = await _context.consultas.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }
            ViewData["medicamentoid"] = new SelectList(_context.medicamentos, "id", "nome", consulta.medicamentoid);
            ViewData["medicoid"] = new SelectList(_context.medicos, "id", "nome", consulta.medicoid);
            ViewData["pacienteid"] = new SelectList(_context.pacientes, "id", "nome", consulta.pacienteid);
            return View(consulta);
        }

        // POST: Consultas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,data,pacienteid,medicoid,medicamentoid")] Consulta consulta)
        {
            if (id != consulta.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consulta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaExists(consulta.id))
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
            ViewData["medicamentoid"] = new SelectList(_context.medicamentos, "id", "nome", consulta.medicamentoid);
            ViewData["medicoid"] = new SelectList(_context.medicos, "id", "nome", consulta.medicoid);
            ViewData["pacienteid"] = new SelectList(_context.pacientes, "id", "nome", consulta.pacienteid);
            return View(consulta);
        }

        // GET: Consultas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.consultas == null)
            {
                return NotFound();
            }

            var consulta = await _context.consultas
                .Include(c => c.medicamento)
                .Include(c => c.medico)
                .Include(c => c.paciente)
                .FirstOrDefaultAsync(m => m.id == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.consultas == null)
            {
                return Problem("Entity set 'Contexto.consultas'  is null.");
            }
            var consulta = await _context.consultas.FindAsync(id);
            if (consulta != null)
            {
                _context.consultas.Remove(consulta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaExists(int id)
        {
          return _context.consultas.Any(e => e.id == id);
        }
    }
}
