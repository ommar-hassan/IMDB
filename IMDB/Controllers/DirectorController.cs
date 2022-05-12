using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IMDB.Controllers
{
    public class DirectorController : Controller
    {
        // GET: Director
        private readonly DBContext _context;


        public DirectorController(DBContext context)
        {
            _context = context;
        }
       
        public async Task<ActionResult> Index()
        {
            var allDirectors = await _context.Directors.ToListAsync();
            return View();
        }
    }
}