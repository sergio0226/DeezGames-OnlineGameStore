using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab4t1.Data;
using lab4t1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace lab4t1.Controllers
{
    public class JogosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostEnvironment _he;

        public JogosController(ApplicationDbContext context, IHostEnvironment he)
        {
            _context = context;
            _he = he;
        }

        // GET: Jogos

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Jogos.Include(j => j.Categoria).Include(j => j.Perfil).Include(j => j.Plataforma).Include(j => j.Produtora).ToListAsync();
            return View(await applicationDbContext);
        }

        // GET: Jogos/Details/5
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Jogos == null)
            {
                return NotFound();
            }

            var jogo = await _context.Jogos
                .Include(j => j.Categoria)
                .Include(j => j.Perfil)
                .Include(j => j.Plataforma)
                .Include(j => j.Produtora)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogo == null)
            {
                return NotFound();
            }

            return View(jogo);
        }

        // GET: Jogos/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["CategoriaID"] = new SelectList(_context.Categorias, "Id", "Name");
            ViewData["PlataformaID"] = new SelectList(_context.Plataformas, "Id", "Name");
            ViewData["ProdutoraID"] = new SelectList(_context.Produtoras, "Id", "Name");

            return View();
        }

        // POST: Jogos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Preco,Foto,PlataformaID,CategoriaID,ProdutoraID,FuncionarioID")] Jogo jogo, IFormCollection formData)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in formData.Files)
                {
                    jogo.Foto = file.FileName;
                    string dir = Path.Combine(
                        _he.ContentRootPath, "wwwroot/Jogos/", jogo.Name
                        );

                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    string des = Path.Combine(dir, Path.GetFileName(file.FileName));
                    FileStream fs = new FileStream(des, FileMode.Create, FileAccess.Write);
                    file.CopyTo(fs);
                    fs.Close();

                }
                var perfil = await _context.Perfils.FirstOrDefaultAsync(m => m.UserName == User.Identity.Name);
                jogo.FuncionarioID = perfil.Id;
                _context.Add(jogo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaID"] = new SelectList(_context.Categorias, "Id", "Name", jogo.CategoriaID);
            ViewData["PlataformaID"] = new SelectList(_context.Plataformas, "Id", "Name", jogo.PlataformaID);
            ViewData["ProdutoraID"] = new SelectList(_context.Produtoras, "Id", "Name", jogo.ProdutoraID);
            return View(jogo);
        }

        // GET: Jogos/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Jogos == null)
            {
                return NotFound();
            }

            var jogo = await _context.Jogos.FindAsync(id);
            if (jogo == null)
            {
                return NotFound();
            }
            ViewData["CategoriaID"] = new SelectList(_context.Categorias, "Id", "Name", jogo.CategoriaID);
            ViewData["PlataformaID"] = new SelectList(_context.Plataformas, "Id", "Name", jogo.PlataformaID);
            ViewData["ProdutoraID"] = new SelectList(_context.Produtoras, "Id", "Name", jogo.ProdutoraID);
            return View(jogo);
        }

        // POST: Jogos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Preco,PlataformaID,CategoriaID,ProdutoraID,FuncionarioID")] Jogo jogo)
        {
            
            if (id != jogo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var perfil = await _context.Perfils.FirstOrDefaultAsync(m => m.UserName == User.Identity.Name);
                    jogo.FuncionarioID = perfil.Id;
                    _context.Update(jogo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogoExists(jogo.Id))
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
            ViewData["CategoriaID"] = new SelectList(_context.Categorias, "Id", "Name", jogo.CategoriaID);
            ViewData["PlataformaID"] = new SelectList(_context.Plataformas, "Id", "Name", jogo.PlataformaID);
            ViewData["ProdutoraID"] = new SelectList(_context.Produtoras, "Id", "Name", jogo.ProdutoraID);
            return View(jogo);
        }

        // GET: Jogos/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Jogos == null)
            {
                return NotFound();
            }

            var jogo = await _context.Jogos
                .Include(j => j.Categoria)
                .Include(j => j.Perfil)
                .Include(j => j.Plataforma)
                .Include(j => j.Produtora)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogo == null)
            {
                return NotFound();
            }

            return View(jogo);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Jogos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Jogos'  is null.");
            }
            var jogo = await _context.Jogos.FindAsync(id);
            if (jogo != null)
            {
                _context.Jogos.Remove(jogo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JogoExists(int id)
        {
          return _context.Jogos.Any(e => e.Id == id);
        }

        public async  Task<IActionResult> JogoComprado()
        {
            return View();
        }
    }
}
