using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

using API.Models;

namespace API.Controllers
{
    public class AlunoModeloesController : Controller
    {
        private readonly AppDbContext _context;

        public AlunoModeloesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AlunoModeloes
        public async Task<IActionResult> Index()
        {
              return _context.AlunoModelos != null ? 
                          View(await _context.AlunoModelos.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.AlunoModelos'  is null.");
        }

        // GET: AlunoModeloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AlunoModelos == null)
            {
                return NotFound();
            }

            var alunoModelo = await _context.AlunoModelos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alunoModelo == null)
            {
                return NotFound();
            }

            return View(alunoModelo);
        }

        // GET: AlunoModeloes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AlunoModeloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Turma,Curso")] AlunoModelo alunoModelo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alunoModelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alunoModelo);
        }

        // GET: AlunoModeloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AlunoModelos == null)
            {
                return NotFound();
            }

            var alunoModelo = await _context.AlunoModelos.FindAsync(id);
            if (alunoModelo == null)
            {
                return NotFound();
            }
            return View(alunoModelo);
        }

        // POST: AlunoModeloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Turma,Curso")] AlunoModelo alunoModelo)
        {
            if (id != alunoModelo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alunoModelo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoModeloExists(alunoModelo.Id))
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
            return View(alunoModelo);
        }

        // GET: AlunoModeloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AlunoModelos == null)
            {
                return NotFound();
            }

            var alunoModelo = await _context.AlunoModelos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alunoModelo == null)
            {
                return NotFound();
            }

            return View(alunoModelo);
        }

        // POST: AlunoModeloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AlunoModelos == null)
            {
                return Problem("Entity set 'AppDbContext.AlunoModelos'  is null.");
            }
            var alunoModelo = await _context.AlunoModelos.FindAsync(id);
            if (alunoModelo != null)
            {
                _context.AlunoModelos.Remove(alunoModelo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoModeloExists(int id)
        {
          return (_context.AlunoModelos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
