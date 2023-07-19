using lab4t1.Data;
using lab4t1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace lab4t1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        //apaga-me 
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Categorias = _context.Categorias.ToList();
            ViewBag.Plataformas = _context.Plataformas.ToList();
            var jogos = await _context.Jogos.ToListAsync();
            return View(jogos);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string searchstring, string Categoria, string Plataforma)
        {
            if (searchstring != null || Categoria != null || Plataforma != null)
            {
                var result = _context.Jogos.Where(x => x.Name.Contains(searchstring));
                if (!string.IsNullOrEmpty(Categoria))
                {
                    result = result.Where(x => x.Categoria.Name == Categoria);
                }
                if (!string.IsNullOrEmpty(Plataforma))
                {
                    result = result.Where(x => x.Plataforma.Name == Plataforma);
                }
                return View(result);
            }
            else
                return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}