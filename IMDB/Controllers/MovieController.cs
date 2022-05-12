using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace IMDB.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        private readonly DBContext _context;


        public MovieController(DBContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            var allMovies = await _context.Movies.ToListAsync();
            return View();
        }
    }
}