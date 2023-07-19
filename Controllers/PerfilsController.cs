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
using Microsoft.EntityFrameworkCore.Metadata;

namespace lab4t1.Controllers
{
    public class PerfilsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _usermanager;

        public PerfilsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _usermanager = userManager;
        }

        // GET: Perfils
        public async Task<IActionResult> Index()
        {
            return View(await _context.Perfils.ToListAsync());
        }

        // GET: Perfils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Perfils == null)
            {
                return NotFound();
            }

            var perfil = await _context.Perfils
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perfil == null)
            {
                return NotFound();
            }

            return View(perfil);
        }

        // GET: Perfils/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Perfils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName")] Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perfil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(perfil);
        }

        // GET: Perfils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Perfils == null)
            {
                return NotFound();
            }

            var perfil = await _context.Perfils.FindAsync(id);
            if (perfil == null)
            {
                return NotFound();
            }
            return View(perfil);
        }

        // POST: Perfils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName")] Perfil perfil)
        {
            if (id != perfil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perfil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerfilExists(perfil.Id))
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
            return View(perfil);
        }

        // GET: Perfils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Perfils == null)
            {
                return NotFound();
            }

            var perfil = await _context.Perfils
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perfil == null)
            {
                return NotFound();
            }

            return View(perfil);
        }

        // POST: Perfils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Perfils == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Perfils'  is null.");
            }
            var perfil = await _context.Perfils.FindAsync(id);
            if (perfil != null)
            {
                _context.Perfils.Remove(perfil);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ChangeRole(string userId, string newRole)
        {
            var user = await _usermanager.FindByIdAsync(userId);
            if(user == null)
            {
                return NotFound();
            }
            var currentroles = await _usermanager.GetRolesAsync(user);
            if(currentroles.Count>1)
            {
                await _usermanager.RemoveFromRolesAsync(user, currentroles);
            }
            await _usermanager.AddToRoleAsync(user, newRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        private bool PerfilExists(int id)
        {
          return _context.Perfils.Any(e => e.Id == id);
        }
    }
}
