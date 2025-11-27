using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NanoCuidado.Data;
using NanoCuidado.Models;

namespace NanoCuidado.Controllers
{
    public class ConsultasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsultasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Consultas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Consultas.Include(c => c.Exame).Include(c => c.Paciente).Include(c => c.Tratamento);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Consultas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas
                .Include(c => c.Exame)
                .Include(c => c.Paciente)
                .Include(c => c.Tratamento)
                .FirstOrDefaultAsync(m => m.ConsultaId == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // GET: Consultas/Create
        public IActionResult Create()
        {
            ViewData["ExameId"] = new SelectList(_context.Exames, "ExameId", "ExameId");
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "PacienteId");
            ViewData["TratamentoId"] = new SelectList(_context.Tratamentos, "TratamentoId", "TratamentoId");
            return View();
        }

        // POST: Consultas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConsultaId,PacienteId,DataHora,TratamentoId,ExameId,Observacoes")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consulta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExameId"] = new SelectList(_context.Exames, "ExameId", "ExameId", consulta.ExameId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "PacienteId", consulta.PacienteId);
            ViewData["TratamentoId"] = new SelectList(_context.Tratamentos, "TratamentoId", "TratamentoId", consulta.TratamentoId);
            return View(consulta);
        }

        // GET: Consultas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }
            ViewData["ExameId"] = new SelectList(_context.Exames, "ExameId", "ExameId", consulta.ExameId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "PacienteId", consulta.PacienteId);
            ViewData["TratamentoId"] = new SelectList(_context.Tratamentos, "TratamentoId", "TratamentoId", consulta.TratamentoId);
            return View(consulta);
        }

        // POST: Consultas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConsultaId,PacienteId,DataHora,TratamentoId,ExameId,Observacoes")] Consulta consulta)
        {
            if (id != consulta.ConsultaId)
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
                    if (!ConsultaExists(consulta.ConsultaId))
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
            ViewData["ExameId"] = new SelectList(_context.Exames, "ExameId", "ExameId", consulta.ExameId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "PacienteId", consulta.PacienteId);
            ViewData["TratamentoId"] = new SelectList(_context.Tratamentos, "TratamentoId", "TratamentoId", consulta.TratamentoId);
            return View(consulta);
        }

        // GET: Consultas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas
                .Include(c => c.Exame)
                .Include(c => c.Paciente)
                .Include(c => c.Tratamento)
                .FirstOrDefaultAsync(m => m.ConsultaId == id);
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
            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta != null)
            {
                _context.Consultas.Remove(consulta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaExists(int id)
        {
            return _context.Consultas.Any(e => e.ConsultaId == id);
        }
    }
}
