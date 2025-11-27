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
    public class TratamentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TratamentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tratamentos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Tratamentos.Include(t => t.Exame).Include(t => t.Paciente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Tratamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tratamento = await _context.Tratamentos
                .Include(t => t.Exame)
                .Include(t => t.Paciente)
                .FirstOrDefaultAsync(m => m.TratamentoId == id);
            if (tratamento == null)
            {
                return NotFound();
            }

            return View(tratamento);
        }

        // GET: Tratamentos/Create
        public IActionResult Create()
        {
            ViewData["ExameId"] = new SelectList(_context.Exames, "ExameId", "ExameId");
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "PacienteId");
            return View();
        }

        // POST: Tratamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TratamentoId,Descricao,Preco,ExameId,PacienteId")] Tratamento tratamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tratamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExameId"] = new SelectList(_context.Exames, "ExameId", "ExameId", tratamento.ExameId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "PacienteId", tratamento.PacienteId);
            return View(tratamento);
        }

        // GET: Tratamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tratamento = await _context.Tratamentos.FindAsync(id);
            if (tratamento == null)
            {
                return NotFound();
            }
            ViewData["ExameId"] = new SelectList(_context.Exames, "ExameId", "ExameId", tratamento.ExameId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "PacienteId", tratamento.PacienteId);
            return View(tratamento);
        }

        // POST: Tratamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TratamentoId,Descricao,Preco,ExameId,PacienteId")] Tratamento tratamento)
        {
            if (id != tratamento.TratamentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tratamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TratamentoExists(tratamento.TratamentoId))
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
            ViewData["ExameId"] = new SelectList(_context.Exames, "ExameId", "ExameId", tratamento.ExameId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "PacienteId", tratamento.PacienteId);
            return View(tratamento);
        }

        // GET: Tratamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tratamento = await _context.Tratamentos
                .Include(t => t.Exame)
                .Include(t => t.Paciente)
                .FirstOrDefaultAsync(m => m.TratamentoId == id);
            if (tratamento == null)
            {
                return NotFound();
            }

            return View(tratamento);
        }

        // POST: Tratamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tratamento = await _context.Tratamentos.FindAsync(id);
            if (tratamento != null)
            {
                _context.Tratamentos.Remove(tratamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TratamentoExists(int id)
        {
            return _context.Tratamentos.Any(e => e.TratamentoId == id);
        }
    }
}
